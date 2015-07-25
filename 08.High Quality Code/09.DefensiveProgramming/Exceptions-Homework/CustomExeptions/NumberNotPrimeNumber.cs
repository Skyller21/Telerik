namespace Exceptions_Homework.CustomExeptions
{
    using System;
    
    public class NumberNotPrimeNumber : Exception
    {
        public NumberNotPrimeNumber(string msg)
            : base(msg)
        {
        }
    }
}
