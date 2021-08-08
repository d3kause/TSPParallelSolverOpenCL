using System;
using System.Linq;

namespace TSPSolverGPU
{
    internal class TSPInitialData
    {
        /// <summary>
        /// Gets the distances matrix.
        /// </summary>
        /// <value>
        /// The distances matrix.
        /// </value>
        public float[,] DistancesMatrix { get; private set; } // Матрица расстояний        
        /// <summary>
        /// Gets the task dimension.
        /// </summary>
        /// <value>
        /// Task dimension.
        /// </value>
        public int Dimension { get { return DistancesMatrix.GetLength(0); } } // Количество пунктов назначения        
        /// <summary>
        /// Gets the distances array.
        /// </summary>
        /// <value>
        /// The distances array.
        /// </value>
        public float[] DistancesArray { get { return DistancesMatrix.Cast<float>().ToArray(); } }// Массив расстояний        
        /// <summary>
        /// Gets or sets the points coords.
        /// </summary>
        /// <value>
        /// The points coords.
        /// </value>
        public Coord[] Coords { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="TSPInitialData"/> class.
        /// </summary>
        /// <param name="coords">The coordinates array</param>
        public TSPInitialData(Coord[] coords)
        {
            Coords = coords;
            int n = coords.Length;
            DistancesMatrix = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                DistancesMatrix[i, i] = 0;
                for (int j = 0; j < n; j++)
                {
                    DistancesMatrix[i, j] = DistancesMatrix[j, i] = Convert.ToSingle(Math.Sqrt(Math.Pow(coords[j].X - coords[i].X, 2) + Math.Pow(coords[j].Y - coords[i].Y, 2)));
                }
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TSPInitialData"/> class.
        /// </summary>
        /// <param name="distancesMatrix">The distances matrix.</param>
        /// <exception cref="Exception">TravelingSalesmanInitialData exeption. Incorrect dimension of input data</exception>
        public TSPInitialData(float[,] distancesMatrix)
        {
            if (distancesMatrix.GetLength(0) != distancesMatrix.GetLength(0))
            {
                throw new Exception("TravelingSalesmanInitialData exeption. Incorrect dimension of input data");
            }

            DistancesMatrix = distancesMatrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TSPInitialData"/> class.
        /// </summary>
        /// <param name="path">The file path.</param>
        public TSPInitialData(string path) : this(TSPFileReader.Parse(path).Coords) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TSPInitialData"/> class.
        /// </summary>
        /// <param name="task">The TSPTask instances.</param>
        public TSPInitialData(TSPTask task) : this(task.Coords) { }

        #region TempMethods
        // temp

        public void PrintData()
        {
            Console.WriteLine("Distances matrix:");
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    Console.Write($"{DistancesMatrix[i, j]:f2}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"\nDimension: {Dimension}");
            Console.WriteLine("\nDistances array");
            for (int i = 0; i < DistancesArray.Length; i++)
            {
                Console.Write($"{DistancesArray[i]:f2}\t");
            }
        }
        #endregion
    }
}
