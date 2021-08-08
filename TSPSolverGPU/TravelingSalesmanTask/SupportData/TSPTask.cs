namespace TSPSolverGPU
{
    internal class TSPTask
    {
        #region Properties
        public string TaskName { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public int? Dimension { get; set; }
        public string EdgeWeightType { get; set; }
        public string DisplayDataType { get; set; }
        public Coord[] Coords { get; set; }
        public float[,] DistanceMatrix { get; set; }
        #endregion
    }
}
