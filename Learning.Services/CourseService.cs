using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.Data.Entities;
using Learning.Data;

namespace Learning.Services {
    public class CourseService : BaseService<Course>, ICourseService {

        private readonly IEntityRepository<Course> repository;
        public CourseService(IEntityRepository<Course> courseRepository) : base(courseRepository) {
            this.repository = courseRepository;
        }


        public IEnumerable<Course> GetAllCourses() {
            return repository.GetAll();

        }

    }
}
