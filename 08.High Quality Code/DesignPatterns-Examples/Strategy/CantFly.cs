﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class CantFly:IFly
    {
        public void Fly()
        {
            Console.WriteLine("Can't fly");
        }
    }
}
