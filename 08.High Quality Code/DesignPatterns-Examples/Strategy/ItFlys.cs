namespace Strategy
{
    using System;

    public class ItFlys : IFly
    {
        public void Fly()
        {
            Console.WriteLine("It flies");
        }
    }
}