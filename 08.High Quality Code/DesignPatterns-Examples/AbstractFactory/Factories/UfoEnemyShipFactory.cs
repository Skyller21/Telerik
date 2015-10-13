namespace AbstractFactory.Factories
{
    using Contracts;

    public class UfoEnemyShipFactory : IEnemyShipFactory
    {
        public IWeapon AddEsGun()
        {
            return new UfoGun();
        }

        public IEngine AddEsEngine()
        {
            return new UfoEngine();
        }
    }
}