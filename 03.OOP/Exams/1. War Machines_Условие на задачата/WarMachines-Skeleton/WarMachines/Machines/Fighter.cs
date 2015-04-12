using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter, IMachine
    {
        private const double InitialHealth = 200;
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
        }
        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string machineString = base.ToString();

            result.AppendLine(machineString);
            result.Append(String.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return result.ToString().TrimEnd();
        }
    }
}
