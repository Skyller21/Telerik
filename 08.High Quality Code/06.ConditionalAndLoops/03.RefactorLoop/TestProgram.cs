namespace _03.RefactorLoop
{
    using System;

    public class TestProgram
    {
        public static void Main(string[] args)
        {
            const int Divisor = 10;
            const int ExpectedValue = 20;
            bool isValueFound = false;
            int index = -1;
            int[] array = new[] { 1, 2, 3, 4, 5, 6, 20 };

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % Divisor == 0)
                {
                    if (array[i] == ExpectedValue)
                    {
                        isValueFound = true;
                        index = i;
                        break;
                    }
                }
            }

            if (isValueFound)
            {
                Console.WriteLine("The searched value {0} was found at index {1}", ExpectedValue, index);
            }
            else
            {
                Console.WriteLine("The value was not found in the array");
            }
        }
    }
}
