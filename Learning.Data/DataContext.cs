using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Learning.Data {
    public class DataContext : DbContext {
        public DataContext(string nameOrConnectionString) :
           base(nameOrConnectionString) {

            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database
                .SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Config.DataContextMigrationConfigration>());


        }
        public DataContext() :
            this("DefaultConnection") {

            


        }

        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Subject> Subjects { get; set; }

        public DbSet<Entities.Student> Students { get; set; }

        public DbSet<Entities.Tutor> Tutors { get; set; }
        public DbSet<Entities.Enrollment> Enrollments { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new Mappers.CourseMapper());
            modelBuilder.Configurations.Add(new Mappers.SubjectMapper());
            modelBuilder.Configurations.Add(new Mappers.TutorMapper());
            modelBuilder.Configurations.Add(new Mappers.StudentMapper());
            modelBuilder.Configurations.Add(new Mappers.EnrollmentMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}