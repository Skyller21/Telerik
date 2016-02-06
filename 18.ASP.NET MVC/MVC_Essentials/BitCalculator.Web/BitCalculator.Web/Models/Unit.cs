using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitCalculator.Web.Models
{
    public class Unit
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Symbol { get; set; }

        public decimal BitValue { get; set; }

        [DisplayFormat(DataFormatString = "{0:G10}", ApplyFormatInEditMode = true)]
        public decimal CalculatedValue { get; set; }
    }
}