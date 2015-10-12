using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Dog : Animal{
	     
	    public void DigHole(){

	        Console.WriteLine("Dug a hole");
	         
	    }
	     
	    public Dog()
	    {
	        
	        // We set the Flys interface polymorphically
	        // This sets the behavior as a non-flying Animal
	         
	        flyingType = new CantFly();
	         
	    }

        protected override void MakeSound()
        {
            Console.WriteLine("Bark");
        }

        /* BAD
	    * You could override the fly method, but we are breaking
	    * the rule that we need to abstract what is different to
	    * the subclasses
	    *
	    public void fly(){
	         
	        System.out.println("I can't fly");
	         
	    }
	    */
	     
	}
}
