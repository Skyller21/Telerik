using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private IList<string> targets; 

        public Machine(string name,double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name cannot be null");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("The pilot cannot be null");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.healthPoints = value;
            }
        }

        public double AttackPoints{get; protected set;}

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get { return new List<string>(targets); }
            set { this.targets = value; }
        }

        public void Attack(string target)
        {
            if (string.IsNullOrEmpty(target))
            {
                throw new ArgumentNullException("Target cannot be null or empty");
            }
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("- {0}", this.Name));
            sb.AppendLine(String.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(String.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(String.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(String.Format(" *Defense: {0}", this.DefensePoints));
            sb.Append(String.Format(" *Targets: {0}", this.Targets.Count==0? "None":string.Join(", ",this.Targets)));
            

            return sb.ToString();


        }
    }
}
