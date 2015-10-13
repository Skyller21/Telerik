namespace FactoryPattern
{
    internal class RocketEnemyShip : EnemyShip
    {
        public RocketEnemyShip()
        {
            this.Name = "Rocket Enemy Ship";
            this.Damage = 30;
        }
    }
}