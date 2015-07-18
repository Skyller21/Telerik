namespace Abstraction.Validation
{
    using System;
    using Abstraction.Exceptions;

    public static class Validator
    {
        public static void ValidateDimension(double dimension,string name)
        {
            if (dimension <= 0)
            {
                throw new FigureException(String.Format("The {0} must be a positive number!",name));
            }
        }
    }
}
