using System.Data.Entity.ModelConfiguration;

namespace Learning.Data.Mappers {
    internal class StudentMapper : BaseMapper<Entities.Student> {
        public StudentMapper() {

            this.ToTable("Students");

            this.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);


            this.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(s => s.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            this.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.Gender)
                .IsOptional();
            this.Property(s => s.DateOfBirth)
                .IsRequired()
                .HasColumnType("smalldatetime");

            this.Property(s => s.RegistrationDate)
                .IsOptional()
                .HasColumnType("smalldatetime");

            this.Property(s => s.LastLoginDate)
                .IsOptional()
                .HasColumnType("smalldatetime");

        }
    }
}