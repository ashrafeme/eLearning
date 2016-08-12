using Learning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Services {
   public interface IStudentService : IBaseService<Student> {
        IEnumerable<Student> GetAllStudentsWithEnrollments();
        IEnumerable<Student> GetAllStudentsSummary();

        IEnumerable<Student> GetEnrolledStudentsInCourse(int courseId);
        Student GetStudentEnrollments(string userName);
        Task<Student> GetStudentAsync(int id);

        bool LoginStudent(string userName, string password);

        
    }
}
