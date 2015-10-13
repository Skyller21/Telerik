namespace AbstractFactory
{
    public abstract class EnemyShipBuilding
    {
        public EnemyShip OrderTheShip(string typeOfShip)
        {
            var enemyShip = this.MakeEnemyShip(typeOfShip);

            enemyShip.MakeShip();
            enemyShip.DisplayEnemyShip();
            enemyShip.FollowHeroShip();
            enemyShip.EnemyShipShoots();

            return enemyShip;
        }

        protected abstract EnemyShip MakeEnemyShip(string typeOfShip);
    }
}