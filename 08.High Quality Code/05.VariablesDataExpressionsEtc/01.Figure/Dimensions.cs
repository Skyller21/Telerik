namespace _01.Dimensions
{
    using System;

    public class Dimensions
    {
        private double width;
        private double height;

        public Dimensions(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width must be a positive number");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be a positive number");
                }

                this.height = value;
            }
        }

        /// <summary>
        /// Returns the dimensions width and height after rotation with given angle in degrees.
        /// <para>Anlge in Degrees!</para>
        /// </summary>
        /// <param name="angleOfRotation">The rotation angle in degrees</param>
        /// <returns>The dimensions after rotation.</returns>
        public Dimensions GetDimensionsAfterRotate(double angleOfRotation)
        {
            double angleInRadians = angleOfRotation * Math.PI / 180;
            double newWidth = GetDimensionsAfterRotate(angleInRadians, this.Width, this.Height);
            double newHeight = GetDimensionsAfterRotate(angleInRadians, this.Height, this.Width);
            var newDimensions = new Dimensions(newWidth, newHeight);

            return newDimensions;
        }

        public override string ToString()
        {
            return string.Format("Width: {0:F2}\nHeight: {1:F2}", this.Width, this.Height);
        }

        private static double GetDimensionsAfterRotate(double angle, double dimensionWithCos, double dimensionWithSin)
        {
            double
                dimensionMultipliedByCos = Math.Abs(Math.Cos(angle)) * dimensionWithCos;
            double dimensionMultipliedBySin = Math.Abs(Math.Sin(angle)) * dimensionWithSin;

            return dimensionMultipliedBySin + dimensionMultipliedByCos;
        }
    }
}
