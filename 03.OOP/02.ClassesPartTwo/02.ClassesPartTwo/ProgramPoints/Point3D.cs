namespace ProgramPoints
{
    using System;
    
    public struct Point3D
    {
        public double XCoord { get; set; }
        public double YCoord { get; set; }
        public double ZCoord { get; set; }

        private static readonly Point3D centerPoint = new Point3D();

        public static Point3D CenterPoint
        {
            get { return centerPoint; }
        } 


        public Point3D(double xCoord, double yCoord, double zCoord)
            : this()
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }


        public override string ToString()
        {
            return String.Join(",",this.XCoord,this.YCoord,this.ZCoord);
        }
    }
}
