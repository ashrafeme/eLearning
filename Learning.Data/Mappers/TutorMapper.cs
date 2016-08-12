using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class TutorMapper :
        BaseMapper<Entities.Tutor>{

        public TutorMapper() {
            this.ToTable("Tutors");
           
            this.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(50);

            this.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

            this.Property(c => c.UserName)
               .IsRequired()
               .HasMaxLength(255)
               .IsUnicode(false);

            this.Property(c => c.Password)
               .IsRequired()
               .HasMaxLength(255);

            this.Property(c => c.Gender)
               .IsOptional();


        }
    }
}