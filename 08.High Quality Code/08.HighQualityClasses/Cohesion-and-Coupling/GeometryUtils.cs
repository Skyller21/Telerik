namespace CohesionAndCoupling
{
    using System;

    public class GeometryUtils
    {
        public static double CalcDistance2D(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY)
        {
            var xDistance = CalcProjectionDistance(pointOneX, pointTwoX);
            double yDistance = CalcProjectionDistance(pointOneY, pointTwoY);
            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
            return distance;
        }

        public static double CalcDistance3D(double pointOneX, double pointOneY, double pointOneZ, double pointTwoX, double pointTwoY, double pointTwoZ)
        {
            double xDistance = CalcProjectionDistance(pointOneX, pointTwoX);
            double yDistance = CalcProjectionDistance(pointOneY, pointTwoY);
            double zDistance = CalcProjectionDistance(pointOneZ, pointTwoZ);

            double distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance + zDistance * zDistance);
            return distance;
        }

        private static double CalcProjectionDistance(double pointOneAxis, double pointTwoAxis)
        {
            double axisDistance = pointTwoAxis - pointOneAxis;
            return axisDistance;
        }
    }
}
