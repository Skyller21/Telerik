using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Pilot:IPilot
    {

        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new List<IMachine>();
        }
        public string Name { get; set; }
        public IList<IMachine> Machines { get; set; }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("The machine cannot be null");
            }
            this.Machines.Add(machine);
            this.Machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Name);

            if (this.Machines.Count == 0)
            {
                sb.Append(" - no machines");
            }
            else
            {
                if (this.Machines.Count == 1)
                {
                    sb.AppendLine(" - 1 machine");
                }
                else
                {
                    sb.AppendLine(" - "+this.Machines.Count + " machines");
                }
            }

            foreach (var m in this.Machines)
            {
                sb.AppendLine(m.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
