using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Bird : Animal{
	
	// The constructor initializes all objects
	
	public Bird(){
		// We set the Flys interface polymorphically
		// This sets the behavior as a non-flying Animal
		
		this.flyingType = new ItFlys();
	}

        protected override void MakeSound()
        {
            Console.WriteLine("Tweet");
        }
    }
}
