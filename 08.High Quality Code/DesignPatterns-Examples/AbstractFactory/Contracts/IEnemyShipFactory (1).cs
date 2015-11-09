namespace AbstractFactory.Contracts
{
    public interface IEnemyShipFactory
    {
        IWeapon AddEsGun();

        IEngine AddEsEngine();
    }
}