using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBuilder
{
    class Vector
    {
        double[] coord = new double [3];


        public Vector()
        {
            coord = new double[3];
        }

        public Vector(double x, double y, double z)
        {
            coord = new double[3] {x, y, z};
        }



        public Vector SetVector => this;

        public double X
        {
            get => coord[0];
            set { coord[0] = value; }
        }
        public double Y
        {
            get => coord[1];
            set { coord[1] = value; }
        }

        public double Z
        {
            get => coord[2];
            set { coord[2] = value; }
        }

    }
}
