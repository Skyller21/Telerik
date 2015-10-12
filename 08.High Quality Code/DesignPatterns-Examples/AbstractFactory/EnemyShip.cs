using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public abstract class EnemyShip
    {
        protected string name;

        protected IWeapon weapon;

        protected IEngine engine;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public abstract void MakeShip();

        public void DisplayEnemyShip()
        {
            Console.WriteLine("{0} is on the screen", this.Name);
        }

        public void FollowHeroShip()
        {
            Console.WriteLine("{0} followeing the hero at {1}", this.Name, this.engine );
        }

        public void EnemyShipShoots()
        {
            Console.WriteLine("{0} attacks and makes {1}", this.Name, this.weapon);
        }

        public override string ToString()
        {
	        string infoOnShip = "The " + this.Name + " has a top speed of " + this.engine +
	                " and an attack power of " + this.weapon;
	         
	        return infoOnShip;
	    }
    }
}
