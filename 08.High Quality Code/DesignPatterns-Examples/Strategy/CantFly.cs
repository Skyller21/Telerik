namespace Strategy
{
    using System;

    public class CantFly : IFly
    {
        public void Fly()
        {
            Console.WriteLine("Can't fly");
        }
    }
}