using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClinic.Data.Layers.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; 
            //AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SimpleClinic.Data.Layers.AppDbContext";
            CommandTimeout = 0;
        }
    }
}
