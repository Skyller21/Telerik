using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public abstract class EnemyShip
    {
        public string Name { get; set; }
        public double Damage { get; set; }

        public void FollowLeaderShip()
        {
            Console.WriteLine("{0} follows the leader", this.Name);
        }

        public void EnemyShipShoots()
        {
            Console.WriteLine("{0} attacks and get {1} damage", this.Name, this.Damage);
        }


    }
}
