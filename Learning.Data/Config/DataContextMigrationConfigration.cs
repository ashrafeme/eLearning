using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Learning.Data.Config {
    public class DataContextMigrationConfigration : DbMigrationsConfiguration<DataContext> {
        public DataContextMigrationConfigration() {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
           
        }

#if DEBUG

        protected override void Seed(DataContext context) {

            base.Seed(context);
        }

#endif
    }
}