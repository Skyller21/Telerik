namespace AbstractFactory
{
    using System;
    using Contracts;

    public class UfoBossEnemyShip : EnemyShip
    {
        private readonly IEnemyShipFactory shipFactory;

        public UfoBossEnemyShip(IEnemyShipFactory shipFactory)
        {
            this.shipFactory = shipFactory;
        }

        public override void MakeShip()
        {
            Console.WriteLine("Making enemy ship " + this);

            this.Weapon = this.shipFactory.AddEsGun();
            this.Engine = this.shipFactory.AddEsEngine();
        }
    }
}