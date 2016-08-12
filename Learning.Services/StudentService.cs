using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Data.Entities;
using Learning.Data;

namespace Learning.Services {
    public class StudentService : BaseService<Student>, IStudentService {
        private readonly IEntityRepository<Student> studentRepository;
        public StudentService(IEntityRepository<Student> studentRepository) : base(studentRepository) {
            this.studentRepository = studentRepository;
        }


        public IEnumerable<Student> GetAllStudentsSummary() {
            return studentRepository.GetAll();
        }

        public IEnumerable<Student> GetAllStudentsWithEnrollments() {

            return studentRepository.AllIncluding(e => e.Enrollments);
        }

        public IEnumerable<Student> GetEnrolledStudentsInCourse(int courseId) {
            return studentRepository.AllIncluding(e => e.Enrollments)
                 .Where(e => e.Enrollments.Any(c => c.Id == courseId));
        }

        public async Task<Student> GetStudentAsync(int id) {
            return await studentRepository.GetSingleAsync(id);
        }

        public Student GetStudentEnrollments(string userName) {
            return studentRepository.FindBy(e => e.UserName == userName).FirstOrDefault();
        }

        public bool LoginStudent(string userName, string password) {
            return (studentRepository
                .FindBy(e => e.UserName == userName
                && e.Password == password)
                .FirstOrDefault() != null);
        }
    }
}
