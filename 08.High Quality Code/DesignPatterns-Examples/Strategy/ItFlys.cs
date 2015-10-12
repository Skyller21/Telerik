using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class ItFlys : IFly
    {
        public void Fly()
        {
            Console.WriteLine("It flies");
        }
    }
}
