using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class SubjectMap : EntityTypeConfiguration<Entities.Subject> {
        public SubjectMap() {
            this.ToTable("subject");

            this.HasKey(c => c.Id);

            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(c => c.Id).IsRequired();

            this.Property(e => e.Name).IsRequired();
            this.Property(e => e.Name).HasMaxLength(255);

        }
    }
}