namespace Strategy
{
    using System;

    public class Bird : Animal
    {
        // The constructor initializes all objects
        public Bird()
        {
            this.FlyingType = new ItFlys();
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Tweet");
        }
    }
}