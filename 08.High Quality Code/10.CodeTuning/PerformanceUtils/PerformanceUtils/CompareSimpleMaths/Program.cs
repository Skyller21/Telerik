namespace CompareSimpleMaths
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Add\n-------------------");
            PerformanceTester.OperationTest(Operations.Add, DataType.Int);
            PerformanceTester.OperationTest(Operations.Add, DataType.Long);
            PerformanceTester.OperationTest(Operations.Add, DataType.Float);
            PerformanceTester.OperationTest(Operations.Add, DataType.Double);
            PerformanceTester.OperationTest(Operations.Add, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Subtract\n-------------------");
            PerformanceTester.OperationTest(Operations.Subtract, DataType.Int);
            PerformanceTester.OperationTest(Operations.Subtract, DataType.Long);
            PerformanceTester.OperationTest(Operations.Subtract, DataType.Float);
            PerformanceTester.OperationTest(Operations.Subtract, DataType.Double);
            PerformanceTester.OperationTest(Operations.Subtract, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Multiply\n-------------------");
            PerformanceTester.OperationTest(Operations.Multiply, DataType.Int);
            PerformanceTester.OperationTest(Operations.Multiply, DataType.Long);
            PerformanceTester.OperationTest(Operations.Multiply, DataType.Float);
            PerformanceTester.OperationTest(Operations.Multiply, DataType.Double);
            PerformanceTester.OperationTest(Operations.Multiply, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Divide\n-------------------");
            PerformanceTester.OperationTest(Operations.Divide, DataType.Int);
            PerformanceTester.OperationTest(Operations.Divide, DataType.Long);
            PerformanceTester.OperationTest(Operations.Divide, DataType.Float);
            PerformanceTester.OperationTest(Operations.Divide, DataType.Double);
            PerformanceTester.OperationTest(Operations.Divide, DataType.Decimal);
            Console.WriteLine();

            Console.WriteLine("Increment\n-------------------");
            PerformanceTester.OperationTest(Operations.Increment, DataType.Int);
            PerformanceTester.OperationTest(Operations.Increment, DataType.Long);
            PerformanceTester.OperationTest(Operations.Increment, DataType.Float);
            PerformanceTester.OperationTest(Operations.Increment, DataType.Double);
            PerformanceTester.OperationTest(Operations.Increment, DataType.Decimal);
            Console.WriteLine();
        }
    }
}
