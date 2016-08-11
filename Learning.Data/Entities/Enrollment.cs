using System;

namespace Learning.Data.Entities {
    public class Enrollment : BaseEntity {
        public Enrollment() {
            Student = new Student();
            Course = new Course();
        }
        
        public DateTime EnrollmentDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}