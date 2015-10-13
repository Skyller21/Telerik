namespace AbstractFactory
{
    using Contracts;

    public class UfoGun : IWeapon
    {
        public override string ToString()
        {
            return "20 damage";
        }
    }
}