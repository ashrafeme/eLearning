using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class CourseMapper :
        BaseMapper<Entities.Course> {

        public CourseMapper() : base(){

            this.ToTable("Courses");

            this.Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();

            this.Property(c => c.Description)
                .HasMaxLength(1000)
                .IsOptional();

            this.Property(c => c.Duration)
                .IsRequired();

            this.HasRequired(c => c.CourseSubject)
                .WithMany()
                .Map(s => s.MapKey("SubjectID"));

            this.HasRequired(c => c.CourseTutor)
                .WithMany()
                .Map(s => s.MapKey("TutorID"));
        }
    }
}
