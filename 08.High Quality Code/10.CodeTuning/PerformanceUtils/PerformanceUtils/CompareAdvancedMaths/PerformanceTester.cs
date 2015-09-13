namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public static class PerformanceTester
    {
        private const float FloatNumber = 1000.0F;
        private const double DoubleNumber = 1000.0;
        private const decimal DecimalNumber = 1000.0m;
        private const int OpertaionsCount = 10000000;

        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void OperationTest(Functions operation, DataType dataType)
        {
            dynamic result = 0;

            switch (dataType)
            {
                case DataType.Float:
                    result = FloatNumber;
                    break;
                case DataType.Double:
                    result = DoubleNumber;
                    break;
                case DataType.Decimal:
                    result = DecimalNumber;
                    break;
            }

            Stopwatch.Start();

            for (int i = 0; i < OpertaionsCount; i++)
            {
                switch (operation)
                {
                    case Functions.Sin:
                        result = Math.Sign((double)result);
                        break;
                    case Functions.Log:
                        result = Math.Log((double)result);
                        break;
                    case Functions.Sqrt:
                        result = Math.Sqrt((double)result);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            var elapsedType = Stopwatch.Elapsed;
            Console.WriteLine("Used type: {0,-10} -> Elapsed Time for {1} operations: {2,20}", (Enum)dataType, OpertaionsCount, elapsedType);
        }
    }
}
