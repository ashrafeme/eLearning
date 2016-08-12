using Learning.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Services {
    public interface ICourseService : IBaseService<Course> {


        

        IEnumerable<Course> GetAllCourses();
    }
}
