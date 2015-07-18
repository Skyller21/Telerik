namespace Abstraction.Models
{
    using System;
    using Abstraction.Abstracts;
    using Abstraction.Validation;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                Validator.ValidateDimension(value, "radius");
                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcArea()
        {
            double area = Math.PI * this.Radius * this.Radius;
            return area;
        }
    }
}
