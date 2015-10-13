namespace AbstractFactory
{
    using Contracts;
    using Factories;

    /* This is the only class that needs to change, if you
    want to determine which enemy ships you want to
    provide as an option to build */

    public class UfoEnemyShipBuilding : EnemyShipBuilding
    {
        protected override EnemyShip MakeEnemyShip(string typeOfShip)
        {
            EnemyShip theEnemyShip = null;

            if (typeOfShip.Equals("UFO"))
            {
                IEnemyShipFactory shipPartsFactory = new UfoEnemyShipFactory();
                theEnemyShip = new UfoEnemyShip(shipPartsFactory);
                theEnemyShip.Name = "UFO Grunt Ship";
            }
            else if (typeOfShip.Equals("UFO BOSS"))
            {
                IEnemyShipFactory shipPartsFactory = new UfoBossEnemyShipFactory();
                theEnemyShip = new UfoBossEnemyShip(shipPartsFactory);
                theEnemyShip.Name = "UFO Boss Ship";
            }

            return theEnemyShip;
        }
    }
}