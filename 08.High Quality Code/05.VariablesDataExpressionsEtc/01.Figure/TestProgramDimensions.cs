namespace _01.Dimensions
{
    using System;

    public class TestProgramDimensions
    {
        public static void Main(string[] args)
        {
            Dimensions dimensions = new Dimensions(5.15, 8.25);
            Dimensions dimensionsAfterRotate = dimensions.GetDimensionsAfterRotate(27.5);

            Console.WriteLine(dimensions);
            Console.WriteLine(dimensionsAfterRotate);
        }
    }
}
