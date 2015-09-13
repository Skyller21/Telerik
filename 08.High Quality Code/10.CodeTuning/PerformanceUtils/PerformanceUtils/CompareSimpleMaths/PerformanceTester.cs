namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public static class PerformanceTester
    {
        private const int Integer = 1;
        private const long LongInteger = 1L;
        private const float FloatNumber = 1.0F;
        private const double DoubleNumber = 1.0;
        private const decimal DecimalNumber = 1.0m;
        private const int OpertaionsCount = 10000000;

        private static readonly Stopwatch Stopwatch = new Stopwatch();

        public static void OperationTest(Operations operation, DataType dataType)
        {
            dynamic result = 0;

            switch (dataType)
            {
                case DataType.Int:
                    result = Integer;
                    break;
                case DataType.Long:
                    result = LongInteger;
                    break;
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
                    case Operations.Add:
                        result += Integer;
                        break;
                    case Operations.Subtract:
                        result -= Integer;
                        break;
                    case Operations.Multiply:
                        result *= Integer;
                        break;
                    case Operations.Divide:
                        result /= Integer;
                        break;
                    case Operations.Increment:
                        result++;
                        break;
                    default: throw new InvalidOperationException();
                }
            }

            var elapsedType = Stopwatch.Elapsed;
            Console.WriteLine("Used type: {0,-10} -> Elapsed Time for {1} operations: {2,20}", (Enum)dataType, OpertaionsCount, elapsedType);
        }
    }
}
