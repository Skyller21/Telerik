using System;
using AbstractFactory.Contracts;

namespace AbstractFactory
{
    public class UfoEngine : IEngine
    {
        public override string ToString()
        {
            return "1000 kmph";
        }
    }
}
