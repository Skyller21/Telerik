using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;
        this.Comments = comments;
    }
    
    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The min grade cannot be less then zero");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The max grade cannot be less then zero");
            }

            this.maxGrade = value;
        }
    }
    public string Comments { get; private set; }

    public int Grade
    {
        get { return this.grade; }
        set
        {
            if (value <this.MinGrade || value>this.MaxGrade)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.grade = value;
        }
    }
}
