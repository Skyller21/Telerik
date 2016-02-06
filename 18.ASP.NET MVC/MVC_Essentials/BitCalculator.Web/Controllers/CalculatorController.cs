using BitCalculator.Web.Data;
using BitCalculator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitCalculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private CalculatorDbContext dbContext;

        public CalculatorController()
        {
            this.dbContext = new CalculatorDbContext();
        }

        [HttpGet]
        public ActionResult Calculate()
        {
            var units = this.dbContext.Units.ToList();

            var model = new CalculatorViewModel()
            {
                Quantity = 1,
                Kilo = Kilo.Bandwidth,
                Type = "bit",
                Units = units
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Calculate(CalculatorViewModel model)
        {
            var units = this.dbContext.Units.ToList();
            var selectedUnit = units.FirstOrDefault(u => u.Type == model.Type);
            model.Units = units;

            foreach (var unit in model.Units)
            {
                unit.CalculatedValue = selectedUnit.BitValue / unit.BitValue * model.Quantity;

                if ((int)model.Kilo == 1024)
                {
                    unit.CalculatedValue *= (decimal)model.Kilo / 1000;
                }
            }

            return this.PartialView("_ResultsView", model);
        }
    }
}