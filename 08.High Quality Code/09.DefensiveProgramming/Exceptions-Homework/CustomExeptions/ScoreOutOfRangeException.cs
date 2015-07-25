namespace Exceptions_Homework.CustomExeptions
{
    using System;
    
    public class ScoreOutOfRangeException : Exception
    {
        public ScoreOutOfRangeException(string msg)
            : base(msg)
        {
        }
    }
}
