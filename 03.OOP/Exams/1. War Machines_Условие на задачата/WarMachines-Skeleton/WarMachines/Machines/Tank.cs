using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank : Machine, ITank, IMachine
    {
        private const double InitialHealth = 100;
        private const double AttackPointsModifier = 40;
        private const double DefensePointsModifier = 30;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, InitialHealth, attackPoints, defensePoints)
        {
            this.ToggleDefenseMode();
            
        }
        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints += AttackPointsModifier;
                this.DefensePoints -= DefensePointsModifier;

            }
            else
            {
                this.AttackPoints-=AttackPointsModifier;
                this.DefensePoints += DefensePointsModifier;
            }
            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            string machineString =  base.ToString();

            result.AppendLine(machineString);
            result.Append(String.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return result.ToString().TrimEnd();
        }
    }
}
