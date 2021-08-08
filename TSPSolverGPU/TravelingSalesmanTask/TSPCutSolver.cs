using Cloo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPSolverGPU
{
    static class TSPCutSolver 
    {
        /// <summary>
        /// Kernel program text using SIMD to OpenCL
        /// </summary>
        static string kernelTask_simd = @"__kernel void
 floatVectorSum(__global float * array,
                __global int * taskSize,
                __global int * elementPosition,
                __global float * distancesArray
                )
            {
                int id = get_global_id(0);
               
                int _elemPos = elementPosition[0]; // Порядковый номер искомого элемента
                int _taskSize = taskSize[0]; // Размерность  задачи
                int elementIndex = id * (_elemPos + 2) + _elemPos; // индекс позиции искомого элемента в общем массиве 
                int newPointId = id % (int)(_taskSize - _elemPos);
                for (int i = 0, counter = 0; i < _taskSize; i++)
                {
                    bool hasValue = false;
                    for (int j = elementIndex - _elemPos; j < elementIndex; j++)
                    {
                        if (array[j] == i)
                        {
                            hasValue = true;
                            break;
                        }

                    }
                    if (hasValue == false)
                    {
                        if (counter == newPointId)
                        {
                            array[elementIndex] = i;
                            array[elementIndex + 1] = array[elementIndex + 1] + distancesArray[(int)array[elementIndex - 1] * _taskSize + i];
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                }
                    }";
        /// <summary>
        /// Kernel program text not using OpenCL
        /// </summary>
        static string kernelTask = @"__kernel void
 floatVectorSum(__global float * array,
                __global int * taskSize,
                __global int * elementPosition,
                __global float * distancesArray
                )
            {
                int id = get_global_id(0); // wirk-item id
                int _elemPos = elementPosition[0]; // Порядковый номер искомого элемента
                int _taskSize = taskSize[0]; // Размерность  задачи
                int countRowsToEdit = _taskSize - _elemPos; // Количество строк, которое обрабатывает кернел
                int elementIndex = id * countRowsToEdit * (_elemPos + 2) + _elemPos; // индекс позиции искомого элемента в общем массиве 
               
                for (int i = 1; i < _taskSize; i++)
                {
                    bool hasValue = false;
                    for (int j = (elementIndex - _elemPos + 1); j < elementIndex; j++)
                    {
                        if (array[j] == i)
                        {
                            hasValue = true;
                            break;
                        }

                    }
                    if (hasValue == false)
                    {
                        array[elementIndex] = i;
                        array[elementIndex + 1] = array[elementIndex + 1] + distancesArray[(int)array[elementIndex - 1] * _taskSize + i];
                        elementIndex = elementIndex + (_elemPos + 2);
                    }
                }
            }";

        /// <summary>
        /// Solve TSP problem on cut method using one-thread CPU 
        /// </summary>
        /// <param name="select">Number of options to save</param>
        /// <param name="data">The TSP problem data</param>
        /// <returns>TSPSolveResult instance</returns>
        static TSPSolveResult SolveCPU(int select, TSPInitialData data)
        {
            Stopwatch sw = new Stopwatch();
            int solutionIndex = 2;
            int multiplier = 0;
            float[,] solutionMatrix = new float[data.Dimension - 1, 3];
            sw.Start();
            do
            {
                sw.Start();
                for (int i = 0; i < solutionMatrix.GetLength(0);)
                {
                    int lastPoint = (int)solutionMatrix[i, solutionMatrix.GetLength(1) - 3];
                    List<int> notVisitedPoint = new List<int>();
                    for (int j = 1; j < data.Dimension; j++)
                        notVisitedPoint.Add(j);
                    for (int j = 0; j < solutionMatrix.GetLength(1) - 1; j++)
                        notVisitedPoint.Remove((int)solutionMatrix[i, j]);
                    for (int l = 0; l < notVisitedPoint.Count; l++)
                    {
                        int newPoint = notVisitedPoint[l];
                        solutionMatrix[i, solutionMatrix.GetLength(1) - 2] = (float)newPoint;
                        solutionMatrix[i, solutionMatrix.GetLength(1) - 1] += data.DistancesMatrix[lastPoint, newPoint];
                        i++;
                    }
                }
                sw.Stop();
                solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);

                multiplier = data.Dimension - solutionIndex;
                if (solutionMatrix.GetLength(0) > select)
                    solutionMatrix = CutSolutionMatrix(solutionMatrix, select);

                if (multiplier < 1)
                {
                    solutionMatrix = GetNewMatrix(solutionMatrix, 1);
                    solutionMatrix = GetLastSolution(solutionMatrix, data);
                    solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);
                    break;
                }
                solutionMatrix = GetNewMatrix(solutionMatrix, multiplier);
                solutionIndex++;
            }
            while (solutionIndex <= data.Dimension);
            float[] result = new float[data.Dimension + 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = solutionMatrix[0, i];
            }
            int[] route = new int[result.Length-1];
            for (int i = 0; i < route.Length; i++)
                route[i] = (int)result[i];
            return new TSPSolveResult(route, result[result.Length-1], sw.ElapsedMilliseconds);
        }

        static void SelectNextPoint(float[,] array, int i, TSPInitialData data)
        {
            int lastPoint = (int)array[i, array.GetLength(1) - 3];
            List<int> notVisitedPoint = new List<int>();
            for (int j = 1; j < data.Dimension; j++)
                notVisitedPoint.Add(j);
            for (int j = 0; j < array.GetLength(1) - 1; j++)
                notVisitedPoint.Remove((int)array[i, j]);
            for (int l = 0; l < notVisitedPoint.Count; l++)
            {
                int newPoint = notVisitedPoint[l];
                array[i, array.GetLength(1) - 2] = (float)newPoint;
                array[i, array.GetLength(1) - 1] += data.DistancesMatrix[lastPoint, newPoint];
                i++;
            }
        }
        /// <summary>
        /// Solve TSP problem on cut method using multi-thread CPU 
        /// </summary>
        /// <param name="select">Number of options to save</param>
        /// <param name="data">The TSP problem data</param>
        /// <returns>TSPSolveResult instance</returns>
        static TSPSolveResult SolveParallelCPU(int select, TSPInitialData data)
        {
            Stopwatch sw = new Stopwatch();
            int solutionIndex = 2;
            int multiplier = 0;
            float[,] solutionMatrix = new float[data.Dimension - 1, 3];
            sw.Reset();
            do
            {
                sw.Start();
                int pointToSelect = data.Dimension - solutionIndex + 1;

                Parallel.ForEach(Enumerable.Range(0, (solutionMatrix.GetLength(0) / pointToSelect)).Select(i => i * pointToSelect), i =>
                  SelectNextPoint(solutionMatrix, i, data));
                sw.Stop();

                solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);
                if (solutionMatrix.GetLength(0) > select)
                    solutionMatrix = CutSolutionMatrix(solutionMatrix, select);
                multiplier = data.Dimension - solutionIndex;
                if (multiplier < 1)
                {
                    solutionMatrix = GetNewMatrix(solutionMatrix, 1);
                    solutionMatrix = GetLastSolution(solutionMatrix, data);
                    solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);
                    break;
                }

                solutionMatrix = GetNewMatrix(solutionMatrix, multiplier);
                solutionIndex++;
            }
            while (solutionIndex <= data.Dimension);
            float[] result = new float[data.Dimension + 2];
            for (int i = 0; i < result.Length; i++)
                result[i] = solutionMatrix[0, i];
            int[] route = new int[result.Length - 1];
            for (int i = 0; i < route.Length; i++)
                route[i] = (int)result[i];
            return new TSPSolveResult(route, result[result.Length - 1], sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Solve TSP problem on cut method using GPU
        /// </summary>
        /// <param name="select">Number of options to save</param>
        /// <param name="data">The TSP problem data</param>
        /// <returns>TSPSolveResult instance</returns>
        static TSPSolveResult SolveParallelGPU(int select, TSPInitialData data)
        {
            Stopwatch sw = new Stopwatch();
            int solutionIndex = 2;
            int multiplier = 0;
            float[,] solutionMatrix = new float[data.Dimension - 1, 3];
            OpenCLTemplate.CLCalc.InitCL(ComputeDeviceTypes.Gpu);
            OpenCLTemplate.CLCalc.Program.Compile(new string[] { kernelTask_simd });
            OpenCLTemplate.CLCalc.Program.Kernel VectorSum = new OpenCLTemplate.CLCalc.Program.Kernel("floatVectorSum");
            sw.Reset();
            do
            {
                //.................................................
                float[] _gpuArray = Transform2Dto1DArray(solutionMatrix); // Массив маршрутов и ЦФ
                sw.Start();
                OpenCLTemplate.CLCalc.Program.Variable gpuArray = new OpenCLTemplate.CLCalc.Program.Variable(_gpuArray);
                OpenCLTemplate.CLCalc.Program.Variable taskSize = new OpenCLTemplate.CLCalc.Program.Variable(new int[] { data.Dimension });
                OpenCLTemplate.CLCalc.Program.Variable elementPositionGPU = new OpenCLTemplate.CLCalc.Program.Variable(new int[] { solutionIndex - 1 });
                OpenCLTemplate.CLCalc.Program.Variable distancesArray = new OpenCLTemplate.CLCalc.Program.Variable(data.DistancesArray);
                int n = solutionMatrix.GetLength(0);
                OpenCLTemplate.CLCalc.Program.Variable[] args = new OpenCLTemplate.CLCalc.Program.Variable[] { gpuArray, taskSize, elementPositionGPU, distancesArray };
                // int[] workers = new int[1] { n / (Data.Dimension - solutionIndex + 1) }; to not simd
                int[] workers = new int[1] { n };
                VectorSum.Execute(args, workers);
                gpuArray.ReadFromDeviceTo(_gpuArray);
                //GPUTest(_gpuArray, new int[] { Data.Dimension }, new int[] { solutionIndex - 1 }, n, Data.DistancesArray);
                sw.Stop();
                solutionMatrix = Trandform1Dto2DArray(_gpuArray, solutionIndex + 1);
                gpuArray.Dispose();
                taskSize.Dispose();
                elementPositionGPU.Dispose();
                distancesArray.Dispose();
                foreach (var v in args)
                    v.Dispose();
                //.................................................. 
                solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);

                multiplier = data.Dimension - solutionIndex;
                if (multiplier < 1)
                {
                    solutionMatrix = GetNewMatrix(solutionMatrix, 1);
                    solutionMatrix = GetLastSolution(solutionMatrix, data);
                    solutionMatrix = solutionMatrix.OrderBy(x => x[solutionMatrix.GetLength(1) - 1]);
                    break;
                }
                if (solutionMatrix.GetLength(0) > select)
                    solutionMatrix = CutSolutionMatrix(solutionMatrix, select);
                solutionMatrix = GetNewMatrix(solutionMatrix, multiplier);
                solutionIndex++;
            }
            while (solutionIndex <= data.Dimension);
            VectorSum.Dispose();

            float[] result = new float[data.Dimension + 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = solutionMatrix[0, i];
            }
            int[] route = new int[result.Length - 1];
            for (int i = 0; i < route.Length; i++)
                route[i] = (int)result[i];
            return new TSPSolveResult(route, result[result.Length - 1], sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Get solve to TSP problem using cut method
        /// </summary>
        /// <param name="data">TSP problem data</param>
        /// <param name="mode">The solve mode</param>
        /// <param name="select">Number of rows to keep</param>
        /// <returns>
        /// TSPSolveResult instance
        /// </returns>
        public static TSPSolveResult Solve(TSPInitialData data, SolveMode mode, int select)
        {
            switch(mode)
            {
                case SolveMode.CPU:
                    return SolveCPU(select, data);
                case SolveMode.ParallelCPU:
                    return SolveParallelCPU(select, data);
                case SolveMode.ParallelGPU:
                    return SolveParallelGPU(select, data);
            }

            return new TSPSolveResult();
        }

        /// <summary>
        /// Cuts the solution matrix (select countRows best results)
        /// </summary>
        /// <param name="arr">The solution array</param>
        /// <param name="countRows">Number of rows to keep</param>
        /// <returns></returns>
        static float[,] CutSolutionMatrix(float[,] arr, int countRows)
        {
            int countColumns = arr.GetLength(1);
            float[,] newArray = new float[countRows, countColumns];
            for (int i = 0; i < countRows; i++)
            {
                for (int j = 0; j < countColumns; j++)
                {
                    newArray[i, j] = arr[i, j];
                }
            }
            return newArray;
        }

        static float[,] GetLastSolution(float[,] array, TSPInitialData data)
        {
            Parallel.For(0, array.GetLength(0), i =>
            {
                int lastPoint = (int)array[i, array.GetLength(1) - 3];
                array[i, array.GetLength(1) - 2] = 0;
                array[i, array.GetLength(1) - 1] += data.DistancesMatrix[lastPoint, 0];
                i++;
            });
            return array;
        }

        /// <summary>
        /// Resize solution matrix
        /// </summary>
        /// <param name="arr">The solution matrix</param>
        /// <param name="multiplier">The multiplier</param>
        /// <returns></returns>
        static float[,] GetNewMatrix(float[,] arr, int multiplier)
        {
            if (multiplier < 1) multiplier = 1;
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            int newRows = rows * multiplier;
            int newColums = columns + 1;
            float[,] result = new float[newRows, newColums];
            Parallel.For(0, newRows, i => {
                int oldRowIndex = i / multiplier;
                for (int j = 0; j < columns - 1; j++)
                {
                    result[i, j] = arr[oldRowIndex, j];
                }
                result[i, columns] = arr[oldRowIndex, columns - 1];
            });
            return result;
        }
        /// <summary>
        /// Trandform 1D array to 2D array.
        /// </summary>
        /// <param name="arr">Исходный массив</param>
        /// <param name="columns">Количество колонок результирующего массива</param>
        /// <returns></returns>
        static float[,] Trandform1Dto2DArray(float[] arr, int columns)
        {
            int rows = arr.Length / columns;
            float[,] res = new float[rows, columns];
            Parallel.For(0, rows, i =>
            {
                for (int j = 0; j < columns; j++)
                    res[i, j] = arr[i * columns + j];
            });
            return res;
        }

        /// <summary>
        /// Transfer array from 2D to 1D
        /// </summary>
        /// <param name="arr">The array</param>
        /// <returns></returns>
        static float[] Transform2Dto1DArray(float[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            float[] res = new float[rows * columns];
            Parallel.For(0, rows, i =>
            {
                for (int j = 0; j < columns; j++)
                    res[i * columns + j] = arr[i, j];
            });
            return res;
        }
    }
}
