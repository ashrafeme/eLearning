using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class SubjectMapper :
        BaseMapper<Entities.Subject> {
        public SubjectMapper() {
            this.ToTable("subject");

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}