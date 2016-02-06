using BitCalculator.Web.Data;
using BitCalculator.Web.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BitCalculator.Web.App_Start
{
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            var db = new CalculatorDbContext();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CalculatorDbContext, Configuration>());
            db.Database.Initialize(true);
        }
    }
}