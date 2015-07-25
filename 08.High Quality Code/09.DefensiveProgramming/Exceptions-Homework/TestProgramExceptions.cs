using System;
using System.Collections.Generic;
using System.Text;
using Exceptions_Homework.Utils;

class ExceptionsHomework
{
    static void Main()
    {
        var substr = Utilities.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(Utilities.ExtractEnding("I love C#", 2));
        Console.WriteLine(Utilities.ExtractEnding("Nakov", 4));
        Console.WriteLine(Utilities.ExtractEnding("beer", 4));
        //Console.WriteLine(Utilities.ExtractEnding("Hi", 100)); //Throws an exception

        Utilities.CheckPrime(23);

        Utilities.CheckPrime(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
