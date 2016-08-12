using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Mappers {
    class EnrollmentMapper :BaseMapper<Entities.Enrollment> {

        public EnrollmentMapper() {
            this.ToTable("Enrollments");

            this.Property(e => e.EnrollmentDate)
                .IsRequired()
                .HasColumnType("smalldatetime");

            this.HasOptional(e => e.Student)
                .WithMany(e => e.Enrollments)
                .Map(s => s.MapKey("StudentID"))
                .WillCascadeOnDelete(false);

            this.HasOptional(e => e.Course)
                .WithMany(e => e.Enrollments)
                .Map(s => s.MapKey("CourseID"))
                .WillCascadeOnDelete(false);

            //this.HasOptional(e => e.Course)
            //    .WithMany(e => e.Enrollments)
            //    .Map(c => c.MapKey("CourseID"))
            //    .WillCascadeOnDelete(false);

        }
    }
}
