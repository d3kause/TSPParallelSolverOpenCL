namespace TSPSolverGPU
{
    /// <summary>
    /// Points\object coords struct (x,y)
    /// </summary>
    internal struct Coord
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Coord(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
