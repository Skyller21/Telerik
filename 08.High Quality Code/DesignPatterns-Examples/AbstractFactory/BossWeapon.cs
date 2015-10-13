namespace AbstractFactory
{
    using Contracts;

    public class BossWeapon : IWeapon
    {
        public override string ToString()
        {
            return "40 damage";
        }
    }
}