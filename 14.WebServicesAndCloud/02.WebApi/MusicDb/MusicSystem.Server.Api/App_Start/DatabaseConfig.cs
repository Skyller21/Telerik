using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicSystem.Server.Api.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicSystemContext, Configuration>());

            // Only when creating db
            MusicSystemContext.Create().Database.Initialize(true);
        }
    }
}