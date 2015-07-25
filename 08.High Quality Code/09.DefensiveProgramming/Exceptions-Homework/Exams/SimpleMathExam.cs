using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }
        private set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentOutOfRangeException("The problems solved must be in th range [0,10]");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved <=2)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (ProblemsSolved >2 && ProblemsSolved<=4)
        {
            return new ExamResult(3, 2, 6, "Average result: you should study harder.");
        }
        else if (ProblemsSolved > 4 && ProblemsSolved <= 6)
        {
            return new ExamResult(4, 2, 6, "Good result: not very bad.");
        }
        else if (ProblemsSolved > 6 && ProblemsSolved <= 8)
        {
            return new ExamResult(5, 2, 6, "Good result: almost.");
        }
        
        return new ExamResult(6, 2, 6, "Good result: You are an asian :D.");
    }
}
