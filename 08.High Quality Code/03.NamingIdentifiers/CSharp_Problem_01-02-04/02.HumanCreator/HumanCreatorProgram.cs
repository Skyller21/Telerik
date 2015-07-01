using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HumanCreator
{
    class HumanCreatorProgram
    {
        static void Main(string[] args)
        {
            Human firstHuman = Human.MakeHuman(24);
            Human secondHuman = Human.MakeHuman(25);
            Console.WriteLine(firstHuman.Name);
            Console.WriteLine(secondHuman.Name);
        }
    }
}
