using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Data.Entities {
    public class Subject : BaseEntity {
        public Subject() {
            Courses = new List<Course>();
        }

        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}