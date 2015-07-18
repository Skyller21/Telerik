namespace InheritanceAndPolymorphism
{
    using System;

    public static class Validator
    {
        public static void ValidateIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(string.Format("The {0} cannot be null or whitespace", name));
            }
        }
    }
}
