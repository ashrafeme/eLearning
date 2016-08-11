using System.Collections.Generic;

namespace Learning.Data.Entities {
    public class Course: BaseEntity {
        public Course() {
            Enrollments = new HashSet<Enrollment>();
            CourseTutor = new Tutor();
            CourseSubject = new Subject();
        }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public Subject CourseSubject { get; set; }

        public Tutor CourseTutor { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}