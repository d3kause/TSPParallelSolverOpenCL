using Cloo;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TSPSolverGPU
{
    internal static class TSPBruteForceSolver
    {
        private static string kernelTask_old = @"void swap(int* a, int i, int j)
            {
                float s = a[i];
                a[i] = a[j];
                a[j] = s;
            }
            bool NextSet(int* a, int n)
            {
                int j = n - 2;
                while (j != -1 && a[j] >= a[j + 1]) j--;
                if (j == -1)
                    return false; // больше перестановок нет
                int k = n - 1;
                while (a[j] >= a[k]) k--;
                swap(a, j, k);
                int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
                while (l < r)
                    swap(a, l++, r--);
                return true;
            }

            float calcResult(float* array, int arraySize, int* way)
            {
                float res = 0;
                res += array[(int)way[0]];
                for (int i = 0; i < arraySize - 2; i++)
                {
                    res += array[(int)way[i] * arraySize + (int)way[i + 1]];
                }
                res += array[(int)way[arraySize - 2] * arraySize];
                return res;
            }

            __kernel void func(
             __global float* array, // Массив расстояний
             __global int* arraySize, // Размерность задачи
             __global int* threadLenght, // Количество перестановок, обрабатываемых потоком
             __global float* result) // массив результатов
            {

                private int lenght = threadLenght[0];
        private int id = get_global_id(0) * lenght; // id первой перестановки для анализа
        private int way[11]; // Матрица маршрутов
        private int taskSize = arraySize[0];
        private float bestRes = FLT_MAX;
        private float localRes = 0;
        private int bestId = 0;
                
                for (private int k = 1; k<taskSize; k++)
                {
                    way[k - 1] = k;
                }
    private int j = 0;
                while (j != id && NextSet(way, 11))
                {
                    j++;
                }
                for(private int i = 0; i<lenght; i++)
                {
                   localRes = calcResult(array, taskSize, way);
                   if(localRes<bestRes)
                   {
                   bestRes = localRes;
                   bestId = id+i;
                   }
                   NextSet(way,11);
                }
                result[get_global_id(0) * 2] = bestRes;
                result[get_global_id(0) * 2 + 1] = bestId;
}";

        /// <summary>
        /// Text program on C99 language to OpenCL work
        /// </summary>
        private static string kernelTask = @"
             __kernel void func(
             __global __read_only  int* size, // Длина маршрута (без начального пункта)
             __global __read_only int* ways, // Массив маршрутов
             __global __read_only float* distArray, // Массив расстояний
             __global __write_only float * results)  // Массив результатов
            {
                int id = get_global_id(0);
                int sizeLocal = size[0];
                int distSize = sizeLocal + 1;
                int startId = sizeLocal * id;
                float res = distArray[ways[startId]];
                for (int i = startId + 1; i < startId + sizeLocal; i++)
                {
                   res += distArray[ways[i - 1] * distSize + ways[i]];
                }
                res += distArray[ways[startId + sizeLocal-1]];
                results[id] = res;
            }";

        private static void Swap(int[] a, int i, int j)
        {
            var s = a[i];
            a[i] = a[j];
            a[j] = s;
        }

        /// <summary>
        /// Gets the next permutation
        /// </summary>
        /// <param name="a">TSP route array</param>
        /// <param name="n">TSP route length</param>
        /// <returns>Are there permutations further</returns>
        private static bool NextSet(int[] a, int n)
        {
            int j = n - 2;
            while (j != -1 && a[j] >= a[j + 1])
            {
                j--;
            }

            if (j == -1)
            {
                return false; // больше перестановок нет
            }

            int k = n - 1;
            while (a[j] >= a[k])
            {
                k--;
            }

            Swap(a, j, k);
            int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
            {
                Swap(a, l++, r--);
            }

            return true;
        }

        /// <summary>
        /// Gets objective function value to way route.
        /// </summary>
        /// <param name="way">The TSP route</param>
        /// <param name="data">The TSP data</param>
        /// <returns></returns>
        private static float CalcResult(int[] way, TSPInitialData data)
        {
            float result = data.DistancesMatrix[0, way[0]];
            for (int i = 1; i < way.Length; i++)
            {
                result += data.DistancesMatrix[way[i - 1], way[i]];
            }
            result += data.DistancesMatrix[way[way.Length - 1], 0];
            return result;
        }

        /// <summary>
        /// Get solve to TSP problem using brute force method
        /// </summary>
        /// <param name="data">TSP problem data</param>
        /// <param name="mode">The solve mode</param>
        /// <returns>TSPSolveResult instance</returns>
        public static TSPSolveResult Solve(TSPInitialData data, SolveMode mode)
        {
            switch (mode)
            {
                case SolveMode.CPU:
                    return SolveCPU(data);
                case SolveMode.ParallelCPU:
                    return SolveParallelCPU(data);
                case SolveMode.ParallelGPU:
                    return SolveParallelGPU(data);
            }
            return new TSPSolveResult();
        }

        /// <summary>
        /// Solve TSP problem using one-thread CPU
        /// </summary>
        private static TSPSolveResult SolveCPU(TSPInitialData data)
        {
            Stopwatch sw = new Stopwatch();
            double result = double.MaxValue;
            var bestRoute = new int[data.Dimension - 1];
            int[] route = new int[data.Dimension - 1];
            for (int i = 1; i < data.Dimension; i++)
            {
                route[i - 1] = i;
            }

            sw.Start();
            do
            {
                var tempResult = CalcResult(route, data);
                if (tempResult < result)
                {
                    route.CopyTo(bestRoute, 0);
                    result = tempResult;
                }
            }
            while (NextSet(route, route.Length));
            sw.Stop();
            int[] finalRoute = new int[bestRoute.Length + 2];
            bestRoute.CopyTo(finalRoute, 1);
            return new TSPSolveResult(finalRoute, result, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Solve TSP problem using multi-thread CPU
        /// </summary>
        private static TSPSolveResult SolveParallelCPU(TSPInitialData data)
        {
            Stopwatch sw = new Stopwatch();
            double result = double.MaxValue;
            var bestRoute = new int[data.Dimension - 1];
            int[] route = new int[data.Dimension - 1];
            for (int i = 1; i < data.Dimension; i++)
            {
                route[i - 1] = i;
            }

            int solveCount = 1000000 / route.Length;
            int[][] routesArray = new int[solveCount][];
            double[] resultsArray = new double[solveCount];
            int routeIndex = 0;
            sw.Start();
            do
            {
                routesArray[routeIndex] = new int[route.Length];
                route.CopyTo(routesArray[routeIndex], 0);
                routeIndex++;
                if (routeIndex == solveCount)
                {
                    result = ParallelCPUSearchBestWay(data, result, bestRoute, routesArray, resultsArray, routeIndex);
                    routeIndex = 0;
                    routesArray = new int[solveCount][];
                    resultsArray = new double[solveCount];
                }
            }
            while (NextSet(route, route.Length));
            result = ParallelCPUSearchBestWay(data, result, bestRoute, routesArray, resultsArray, routeIndex);
            sw.Stop();
            int[] finalRoute = new int[bestRoute.Length + 2];
            bestRoute.CopyTo(finalRoute, 1);
            return new TSPSolveResult(finalRoute, result, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Parallels search best route in the N routes using CPU
        /// </summary>
        /// <param name="data">The TSP problem data</param>
        /// <param name="result">The result ref</param>
        /// <param name="bestRoute">The best route</param>
        /// <param name="routesArray">The routes array</param>
        /// <param name="resultsArray">The results array.</param>
        /// <param name="routesCount">The routes count</param>
        /// <returns>Best objective function</returns>
        private static double ParallelCPUSearchBestWay(TSPInitialData data, double result, int[] bestRoute, int[][] routesArray, double[] resultsArray, int routesCount)
        {
            Parallel.For(0, routesCount, i =>
            {
                resultsArray[i] = data.DistancesMatrix[0, routesArray[i][0]];
                for (int j = 1; j < routesArray[j].Length; j++)
                {
                    resultsArray[i] += data.DistancesMatrix[routesArray[i][j - 1], routesArray[i][j]];
                }
                resultsArray[i] += data.DistancesMatrix[routesArray[i][routesArray[i].Length - 1], 0];
            }
            );
            int bestResultIndex = -1;
            for (int i = 0; i < routesCount; i++)
            {
                if (resultsArray[i] < result)
                {
                    result = resultsArray[i];
                    bestResultIndex = i;
                }
            }
            if (bestResultIndex != -1)
            {
                routesArray[bestResultIndex].CopyTo(bestRoute, 0);
            }

            return result;
        }

        /// <summary>
        /// Solve TSP problem using GPU (SIMD)
        /// </summary>
        private static TSPSolveResult SolveParallelGPU(TSPInitialData data)
        {
            OpenCLTemplate.CLCalc.InitCL(ComputeDeviceTypes.Gpu);
            OpenCLTemplate.CLCalc.Program.Compile(new string[] { kernelTask });
            OpenCLTemplate.CLCalc.Program.Kernel Func = new OpenCLTemplate.CLCalc.Program.Kernel("func");
            Stopwatch sw = new Stopwatch();
            double result = double.MaxValue;
            var bestRoute = new int[data.Dimension - 1];
            int[] route = new int[data.Dimension - 1];
            for (int i = 1; i < data.Dimension; i++)
            {
                route[i - 1] = i;
            }

            int solveCount = 1000000 / route.Length;
            int[] routesArray = new int[solveCount * route.Length];
            float[] resultsArray = new float[solveCount];
            int routeIndex = 0;
            sw.Start();
            do
            {
                route.CopyTo(routesArray, routeIndex * route.Length);
                routeIndex++;
                if (routeIndex == solveCount)
                {
                    result = ParallelGPUSearchBestWay(data, Func, result, route, routeIndex, routesArray, resultsArray);
                    routeIndex = 0;
                    routesArray = new int[solveCount * route.Length];
                    resultsArray = new float[solveCount];
                }
            }
            while (NextSet(route, route.Length));
            result = ParallelGPUSearchBestWay(data, Func, result, route, routeIndex, routesArray, resultsArray);
            sw.Stop();
            int[] finalRoute = new int[bestRoute.Length + 2];
            bestRoute.CopyTo(finalRoute, 1);
            return new TSPSolveResult(finalRoute, result, sw.ElapsedMilliseconds);
        }
        /// <summary>
        /// Parallels search best route in the N routes using GPU
        /// </summary>
        /// <param name="data">The TSP problem data</param>
        /// <param name="Func">Kernel program to use</param>
        /// <param name="result">The result ref</param>
        /// <param name="route">The route.</param>
        /// <param name="solveCount">The solve count.</param>
        /// <param name="routesArray">The routes array</param>
        /// <param name="resultsArray">The results array.</param>
        /// <returns>Best objective function</returns>
        private static double ParallelGPUSearchBestWay(TSPInitialData data, OpenCLTemplate.CLCalc.Program.Kernel Func, double result, int[] route, int solveCount, int[] routesArray, float[] resultsArray)
        {
            OpenCLTemplate.CLCalc.Program.Variable size = new OpenCLTemplate.CLCalc.Program.Variable(new int[] { route.Length });
            OpenCLTemplate.CLCalc.Program.Variable routes = new OpenCLTemplate.CLCalc.Program.Variable(routesArray);
            OpenCLTemplate.CLCalc.Program.Variable distArray = new OpenCLTemplate.CLCalc.Program.Variable(data.DistancesArray);
            OpenCLTemplate.CLCalc.Program.Variable results = new OpenCLTemplate.CLCalc.Program.Variable(resultsArray);
            OpenCLTemplate.CLCalc.Program.Variable[] args = new OpenCLTemplate.CLCalc.Program.Variable[] { size, routes, distArray, results };
            int[] workers = new int[1] { solveCount };
            Func.Execute(args, workers);
            results.ReadFromDeviceTo(resultsArray);

            int bestResultIndex = -1;
            for (int i = 0; i < solveCount; i++)
            {
                if (resultsArray[i] < result)
                {
                    result = resultsArray[i];
                    bestResultIndex = i;
                }
            }
            if (bestResultIndex != -1)
            {
                for (int i = bestResultIndex * route.Length, j = 0; i < (bestResultIndex + 1) * route.Length; i++)
                {
                    route[j] = routesArray[i];
                    j++;
                }
            }
            return result;
        }
    }

}
