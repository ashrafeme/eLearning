using Learning.Data.Entities;
using Learning.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Learning.Web.Controllers
{
    public class CoursesController : ApiController
    {
        ICourseService courseService;
        
        public CoursesController(ICourseService courseService) {
            this.courseService = courseService;
        }
        public IEnumerable<Course> Get() {
             var data = courseService.GetAllCourses();
            return data;
        }

        public async Task<Course> GetCourse(int id) {

            return await courseService.FindAsync(id);
        }

    }
}
