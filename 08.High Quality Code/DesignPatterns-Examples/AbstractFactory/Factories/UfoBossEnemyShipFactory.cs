namespace AbstractFactory.Factories
{
    using Contracts;

    internal class UfoBossEnemyShipFactory : IEnemyShipFactory
    {
        public IWeapon AddEsGun()
        {
            return new BossWeapon();
        }

        public IEngine AddEsEngine()
        {
            return new BossEngine();
        }
    }
}