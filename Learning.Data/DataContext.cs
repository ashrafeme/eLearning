using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Learning.Data {
    public class DataContext : DbContext {

        public DataContext() :
            base("DefaultConnection") {

            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database
                .SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Config.DataContextMigrationConfigration>());



        }

        public DbSet<Entities.Course> Course { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new Mappers.CourseMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}