namespace Exceptions_Homework.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Validator
    {
        public static void IsStringNull(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("The {0} cannot be null or empty", name);
            }
        }

        public static void IsArrayNullOrEmpty<T>(IEnumerable<T> value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("The array cannot be null");
            }

            if (value.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The array is empty");
            }
        }

    }
}
