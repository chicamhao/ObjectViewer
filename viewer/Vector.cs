namespace ObjectBuilder
{
    public sealed class Vector
    {
        private readonly double[] _coord = new double[3];

        public static Vector Default => new Vector(0.0, 0.0, 0.0);

        public Vector(double x, double y, double z)
        {
            _coord = new double[3] {x, y, z};
        }

        public double X
        {
            get => _coord[0];
            set { _coord[0] = value; }
        }
        public double Y
        {
            get => _coord[1];
            set { _coord[1] = value; }
        }

        public double Z
        {
            get => _coord[2];
            set { _coord[2] = value; }
        }
    }
}
