namespace ObjectBuilder
{
    namespace ObjectBuilder
    {
        public static class Constants
        {
            public enum CameraZoom
            {
                In, Out, 
            }

            public enum CameraRotate
            {
                Right, Left,
                Up, Down
            }

            public const double PI = 3.14159;
            public const uint WorldUnit = 1;
            public const float CameraUnit = 0.05f;

            public static string InstructionText =
                "--------------------*Developer: Chi Cam Hao*------------------- \n \n " +
                "1. First, create some objects: cube, prism, pyramid. \n " +
                "2. Click on the object name displayed on the blue box. \n " +
                "3. When your object has an orange border. Enjoy interactive by changing camera perspective, color, texture, transformation,.. \n " +
                " - Zoom camera:  Z/X key.\n  " +
                " - Rotate camera: arrow keys.  \n ";
        }
    }
}
