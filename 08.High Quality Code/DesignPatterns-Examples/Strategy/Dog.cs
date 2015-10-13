namespace Strategy
{
    using System;

    public class Dog : Animal
    {
        public void DigHole()
        {
            Console.WriteLine("Dug a hole");
        }

        public Dog()
        {
            this.FlyingType = new CantFly();
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }
}