using System;
using SharpGL;
using static ObjectBuilder.ObjectBuilder.Constants;

namespace ObjectBuilder
{
     /*
      * To calculate transform of camera we create a transparent sphere 
      * That shere placed in center of world coordinate (0,0) with 3 orthogonal axes: X, Y, Z
      * fields: "theta" is angle between X and Z, "phi" is between angle Y and GidMap, "radius" is radius of the sphere. 
      */
    public sealed class Camera
    {
        //Camera's feilds
        public Vector EyeCoord => _eyeCoord;
        private readonly Vector _eyeCoord;

        private readonly Vector _lookAtCoord;
        
        //weight of transform
        private readonly float _cameraUnit;

        //transparent sphere's fields
        private double _radius;
        private double _theta;
        private double _phi;

        public Camera(float unit)
        {
            _cameraUnit = unit;

            _eyeCoord = new Vector(3.16f, 3.16f, 3.16f);
            _lookAtCoord = Vector.Default;

            CalculateSphereFields();
        }

        public void Zoom(CameraZoom mode)
        {
            switch (mode)
            {
                case CameraZoom.In:
                    EyeCoord.X += -_cameraUnit * EyeCoord.X;
                    EyeCoord.Y += -_cameraUnit * EyeCoord.Y;
                    EyeCoord.Z += -_cameraUnit * EyeCoord.Z;
                    break;

                case CameraZoom.Out:
                    EyeCoord.X += _cameraUnit * EyeCoord.X;
                    EyeCoord.Y += _cameraUnit * EyeCoord.Y;
                    EyeCoord.Z += _cameraUnit * EyeCoord.Z;
                    break;

                default:
                    throw new NotImplementedException($"{mode}");
            }

            CalculateSphereFields();
        }

        private void CalculateSphereFields()
        {
            //update angle between X and Z
            _theta = Math.Atan((EyeCoord.X - _lookAtCoord.X) / (EyeCoord.Z - _lookAtCoord.Z));

            //update angle between Y and GridMap
            _phi = Math.Asin((EyeCoord.Y - _lookAtCoord.Y) / _radius);

            //update radius of the sphere
            _radius = Math.Sqrt(Math.Pow(EyeCoord.X - _lookAtCoord.X, 2)
                     + Math.Pow(EyeCoord.Y - _lookAtCoord.Y, 2)
                     + Math.Pow(EyeCoord.Z - _lookAtCoord.Z, 2));
        }

         // ref: https://stackoverflow.com/questions/20759214/rotating-a-3d-vector-without-a-matrix-opengl
        public void Rotate(CameraRotate mode)
        {
            switch (mode)
            {
                case CameraRotate.Right:
                    _theta += _cameraUnit;
                    EyeCoord.X = _lookAtCoord.X + _radius * Math.Cos(_phi) * Math.Sin(_theta);
                    EyeCoord.Z = _lookAtCoord.Z + _radius * Math.Cos(_phi) * Math.Cos(_theta);
                    break;

                case CameraRotate.Left:
                    _theta -= _cameraUnit;
                    EyeCoord.X = _lookAtCoord.X + _radius * Math.Cos(_phi) * Math.Sin(_theta);
                    EyeCoord.Z =_lookAtCoord.Z + _radius * Math.Cos(_phi) * Math.Cos(_theta);
                    break;

                case CameraRotate.Up:
                    _phi += _cameraUnit;
                    EyeCoord.Y = _lookAtCoord.Y + _radius * Math.Sin(_phi);
                    EyeCoord.X = _lookAtCoord.X + _radius * Math.Cos(_phi) * Math.Sin(_theta);
                    EyeCoord.Z = _lookAtCoord.Z + _radius * Math.Cos(_phi) * Math.Cos(_theta);
                    break;

                case CameraRotate.Down:
                    _phi -= _cameraUnit;
                    EyeCoord.Y = _lookAtCoord.Y + _radius * Math.Sin(_phi);
                    EyeCoord.X = _lookAtCoord.X + _radius * Math.Cos(_phi) * Math.Sin(_theta);
                    EyeCoord.Z = _lookAtCoord.Z + _radius * Math.Cos(_phi) * Math.Cos(_theta);
                    break;

                default:
                    throw new NotImplementedException($"{mode}");
            }
        }

        public void UpdateLookAt(OpenGL gl)
        {
            gl.LookAt(EyeCoord.X, EyeCoord.Y, EyeCoord.Z, _lookAtCoord.X, _lookAtCoord.Y, _lookAtCoord.Z, 0.0f, 1.0f, 0.0f);
        }
    }
}
