namespace AbstractFactory
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // EnemyShipBuilding handles orders for new EnemyShips
            // You send it a code using the orderTheShip method &
            // it sends the order to the right factory for creation

            EnemyShipBuilding makeUfOs = new UfoEnemyShipBuilding();

            var theGrunt = makeUfOs.OrderTheShip("UFO");
            Console.WriteLine(theGrunt);

            var theBoss = makeUfOs.OrderTheShip("UFO BOSS");
            Console.WriteLine(theBoss);
        }
    }
}