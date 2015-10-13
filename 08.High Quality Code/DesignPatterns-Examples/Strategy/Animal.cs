namespace Strategy
{
    using System;

    public abstract class Animal
    {
        private int weight;

        private IFly flyingType;

        public string Name { get; set; }

        public int Height { get; set; }

        public int Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The weight cannot be negative!");
                    return;
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public string FavFood { get; set; }

        public double Speed { get; set; }

        public IFly FlyingType
        {
            get { return flyingType; }
            set { flyingType = value; }
        }

        public void TryToFly()
        {
            this.flyingType.Fly();
        }

        public void SetFlyingAbility(IFly newFlyType)
        {
            this.flyingType = newFlyType;
        }

        protected abstract void MakeSound();
    }
}