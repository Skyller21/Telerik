using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitCalculator.Web.Models
{
    public class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            this.KilosList = new List<Kilo>()
            {
                Kilo.Bandwidth,
                Kilo.Storage
            };
        }

        public decimal Quantity { get; set; }

        public string Type { get; set; }

        public Kilo Kilo { get; set; }

        public IEnumerable<Kilo> KilosList { get; set; }

        public IEnumerable<Unit> Units { get; set; }
    }
}