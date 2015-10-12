using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public abstract class Animal {
	     
	    private string name;
	    private double height;
	    private int weight;
	    private string favFood;
	    private double speed;
	     
	    // Instead of using an interface in a traditional way
	    // we use an instance variable that is a subclass
	    // of the Flys interface.
	     
	    // Animal doesn't care what flyingType does, it just
	    // knows the behavior is available to its subclasses
	     
	    // This is known as Composition : Instead of inheriting
	    // an ability through inheritance the class is composed
	    // with Objects with the right ability
	     
	    // Composition allows you to change the capabilities of
	    // objects at run time!
	     
	    public IFly flyingType;
	     
	    public string Name { get; set; }


        public int Height { get; set; }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The weight cannot be negative!");
                    return;
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public string FavFood { get; set; }

        public double Speed { get; set; }

        protected abstract void MakeSound();
        
	     
	    /* BAD
	    * You don't want to add methods to the super class.
	    * You need to separate what is different between subclasses
	    * and the super class
	    public void fly(){
	         
	        System.out.println("I'm flying");
	         
	    }
	    */
	     
	    // Animal pushes off the responsibility for flying to flyingType
	     
	    public void TryToFly(){
	         
	        flyingType.Fly();
	         
	    }
	     
	    // If you want to be able to change the flyingType dynamically
	    // add the following method
	     
	    public void SetFlyingAbility(IFly newFlyType){
	         
	        flyingType = newFlyType;
	         
	    }
	     
	}
}
