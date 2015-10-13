namespace AbstractFactory
{
    using System;
    using Contracts;

    public class UfoEnemyShip : EnemyShip
    {
        private readonly IEnemyShipFactory shipFactory;

        public UfoEnemyShip(IEnemyShipFactory shipFactory)
        {
            this.shipFactory = shipFactory;
        }

        public override void MakeShip()
        {
            Console.WriteLine("Making enemy ship {0}", this.Name);
            this.Weapon = this.shipFactory.AddEsGun();
            this.Engine = this.shipFactory.AddEsEngine();
        }
    }
}