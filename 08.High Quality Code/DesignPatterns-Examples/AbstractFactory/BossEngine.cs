using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class BossEngine : IEngine
    {
        public override string ToString()
        {
            return "2000 kmph";
        }
    }
}
