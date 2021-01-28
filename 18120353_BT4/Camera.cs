using System;
using SharpGL;

namespace ObjectBuilder
{
     /*
      * To calculate transform of camera we create a transparent sphere 
      * That shere placed in center of world coordinate (0,0) with 3 orthogonal axes: X, Y, Z
      * fields: "theta" is angle between X and Z, "phi" is between angle Y and GidMap, "radius" is radius of the sphere. 
      */
    public class Camera
    {
        //Camera's feilds
        private Vector EyeCoord;
        private Vector LookAtCoord;
        
        //weight of transform
        private float CameraUnit;

        //transparent sphere's feilds
        private double radius;
        private double theta;
        private double phi;

   
        //constructors
        public Camera()
        {
            CameraUnit = 1;
            EyeCoord = new Vector(10, 10, 10);
            LookAtCoord = new Vector();

            UpdateValue();
        }

        public Camera(float unit)
        {
            CameraUnit = unit;

            EyeCoord = new Vector(3.16f, 3.16f, 3.16f);
            LookAtCoord = new Vector();

            UpdateValue();
        }

        //properties
        public double EyeCoordX
        {
            get => EyeCoord.X;
        }
        public double EyeCoordY
        {
            get => EyeCoord.Y;
        }
        public double EyeCoordZ
        {
            get => EyeCoord.Z;
        }


        //string mode: In/Out
        public void ZoomCamera(string ZoomMode)
        {
            switch (ZoomMode)
            {
                case "In":
                    EyeCoord.X += -CameraUnit * EyeCoord.X;
                    EyeCoord.Y += -CameraUnit * EyeCoord.Y;
                    EyeCoord.Z += -CameraUnit * EyeCoord.Z;
                    break;
                case "Out":
                    EyeCoord.X += CameraUnit * EyeCoord.X;
                    EyeCoord.Y += CameraUnit * EyeCoord.Y;
                    EyeCoord.Z += CameraUnit * EyeCoord.Z;
                    break;
                default:
                    break;
            }
            
            //update sphere's feilds
            UpdateValue();
        }


        private void UpdateValue()
        {
            //update angle between X and Z
            theta = Math.Atan((EyeCoord.X - LookAtCoord.X) / (EyeCoord.Z - LookAtCoord.Z));

            //update angle between Y and GridMap
            phi = Math.Asin((EyeCoord.Y - LookAtCoord.Y) / radius);

            //update radius of the sphere
            radius = Math.Sqrt(Math.Pow(EyeCoord.X - LookAtCoord.X, 2)
                     + Math.Pow(EyeCoord.Y - LookAtCoord.Y, 2)
                     + Math.Pow(EyeCoord.Z - LookAtCoord.Z, 2));
        }

        /*
         * string mode: Right/Left/Up/Down
         * Using theta and phi to calculate rotate transform of the camera using vector.
         * ref: https://stackoverflow.com/questions/20759214/rotating-a-3d-vector-without-a-matrix-opengl
         */
        public void RotateCamera(string RotateMode)
        {
            switch (RotateMode)
            {
                case "Right":
                    theta += CameraUnit;
                    EyeCoord.X = LookAtCoord.X + radius * Math.Cos(phi) * Math.Sin(theta);
                    EyeCoord.Z = LookAtCoord.Z + radius * Math.Cos(phi) * Math.Cos(theta);
                    break;

                case "Left":
                    theta -= CameraUnit;
                    EyeCoord.X = LookAtCoord.X + radius * Math.Cos(phi) * Math.Sin(theta);
                    EyeCoord.Z =LookAtCoord.Z + radius * Math.Cos(phi) * Math.Cos(theta);
                    break;
                case "Up":
                    phi += CameraUnit;
                    EyeCoord.Y = LookAtCoord.Y + radius * Math.Sin(phi);
                    EyeCoord.X = LookAtCoord.X + radius * Math.Cos(phi) * Math.Sin(theta);
                    EyeCoord.Z = LookAtCoord.Z + radius * Math.Cos(phi) * Math.Cos(theta);
                    break;

                case "Down":
                    phi -= CameraUnit;
                    EyeCoord.Y = LookAtCoord.Y + radius * Math.Sin(phi);
                    EyeCoord.X = LookAtCoord.X + radius * Math.Cos(phi) * Math.Sin(theta);
                    EyeCoord.Z = LookAtCoord.Z + radius * Math.Cos(phi) * Math.Cos(theta);
                    break;
                default:
                    break;
            }
        }

        public void UpdateLookAt(OpenGL gl)
        {
            gl.LookAt(EyeCoord.X, EyeCoord.Y, EyeCoord.Z, LookAtCoord.X, LookAtCoord.Y, LookAtCoord.Z, 0.0f, 1.0f, 0.0f);
        }
    }
}
