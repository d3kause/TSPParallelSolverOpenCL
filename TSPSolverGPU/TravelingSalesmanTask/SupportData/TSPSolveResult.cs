using System.Text;

namespace TSPSolverGPU
{
    internal struct TSPSolveResult
    {
        /// <summary>
        /// Gets the TSP route.
        /// </summary>
        /// <value>
        /// The route array.
        /// </value>
        public int[] Route { get; private set; }
        /// <summary>
        /// Gets the TSP result.
        /// </summary>
        /// <value>
        /// The TSP result.
        /// </value>
        public double? Result { get; private set; }
        /// <summary>
        /// Gets the time to solve.
        /// </summary>
        /// <value>
        /// The time to solve in millisecond
        /// </value>
        public long? EllapsedTime { get; private set; }
        /// <summary>
        /// Gets the string representation of the route
        /// </summary>
        /// <value>
        /// String representation of the route
        /// </value>
        public string StringRoute
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < Route.Length; i++)
                {
                    sb.Append(Route[i]);
                    sb.Append('-');
                }
                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TSPSolveResult"/> struct.
        /// </summary>
        /// <param name="route">The route</param>
        /// <param name="res">Objective function value</param>
        /// <param name="time">Elapsed time (millisecond)</param>
        public TSPSolveResult(int[] route, double? res, long? time)
        {
            Route = route;
            Result = res;
            EllapsedTime = time;
        }
    }
}
