using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGuardian.ConsoleClient
{
    public class Input
    {
        public string Search { get; set; }

        public string Category { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? PageSize { get; set; }
    }
}
