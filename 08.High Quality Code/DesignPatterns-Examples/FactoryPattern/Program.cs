namespace FactoryPattern
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of ship");
            var input = Console.ReadLine();

            var factory = new EnemyShipFactory();

            var ship = factory.MakeEnemyShip(input);
            if (ship != null)
            {
                DoStuff(ship);
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }

        private static void DoStuff(EnemyShip enemyShip)
        {
            Console.WriteLine(enemyShip.Name + " created");
            enemyShip.FollowLeaderShip();
            enemyShip.EnemyShipShoots();
        }
    }
}