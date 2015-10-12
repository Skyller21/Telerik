using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of ship");
            var input = Console.ReadLine();

           EnemyShipFactory factory = new EnemyShipFactory();

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
