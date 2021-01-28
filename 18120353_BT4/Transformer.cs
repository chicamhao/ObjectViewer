using SharpGL;
using System;
namespace ObjectBuilder
{
    class Transformer
    {
        private Vector TranslateCoord;
        private Vector RotateCoord;
        private Vector ScaleCoord;

        public Transformer()
        {
            TranslateCoord = new Vector();
            RotateCoord = new Vector();
            ScaleCoord = new Vector(1, 1, 1);
        }

        public Vector Translate 
        {
            get => TranslateCoord;
            set { TranslateCoord = value; }
        }

        public Vector Rotate
        {
            get => RotateCoord;
            set { RotateCoord = value; }
        }

        public Vector Scale
        {
            get => ScaleCoord;
            set { ScaleCoord = value; }
        }

        public void UpdateTransform(OpenGL gl)
        {
            gl.Translate(TranslateCoord.X, TranslateCoord.Y, TranslateCoord.Z);
            gl.Rotate((float)RotateCoord.X, (float)RotateCoord.Y, (float)RotateCoord.Z);
            gl.Scale(ScaleCoord.X, ScaleCoord.Y, ScaleCoord.Z);
        }
    }
}
