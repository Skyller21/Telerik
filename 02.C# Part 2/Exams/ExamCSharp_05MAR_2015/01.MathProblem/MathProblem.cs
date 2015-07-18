namespace _01.MathProblem
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class MathProblem
    {
        public static void Main(string[] args)
        {
            string[] textArray = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var sum = ProcessCharsToDecimal(textArray, 23);

            var numberToBaseSystem = ProcessToBase(sum, 23);

            Console.WriteLine("{0} = {1}", numberToBaseSystem, sum);
        }

        private static string ProcessToBase(BigInteger sum, int systemBase)
        {
            BigInteger tempSum = sum;
            string dec = string.Empty;

            while (tempSum > 0)
            {
                dec = dec + (char)((tempSum % systemBase) + 'a');
                tempSum = tempSum / systemBase;
            }

            return String.Join("",dec.Reverse()) ;
        }

        private static BigInteger ProcessCharsToDecimal(string[] text, int systemBase)
        {
            BigInteger sum = new BigInteger();

            foreach (var item in text)
            {
                BigInteger newNumToAdd = new BigInteger();
                int factor = 1;

                for (int i = item.Length - 1; i >= 0; i--)
                {
                    newNumToAdd += (item[i] - 'a') * factor;
                    factor *= systemBase;
                }

                sum += newNumToAdd;
            }

            return sum;
        }
    }
}
