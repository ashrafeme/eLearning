using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class TutorMap :
        EntityTypeConfiguration<Entities.Tutor>{

        public TutorMap() {
            this.ToTable("Tutors");

            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

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