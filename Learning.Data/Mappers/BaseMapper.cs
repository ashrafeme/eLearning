using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Learning.Data.Mappers {
    public class BaseMapper<TEntity> : EntityTypeConfiguration<TEntity> 
        where TEntity : Entities.BaseEntity
        {

        public BaseMapper() {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                 .IsRequired();

            this.Property(c=>c.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            this.Property(c => c.CreatedDate)
                .HasColumnType("smalldatetime")
                .IsOptional();

            this.Property(c => c.UpdatedDate)
                .HasColumnType("smalldatetime")
                .IsOptional();


        }
    }
}