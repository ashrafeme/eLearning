using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Data.Entities {
    public class BaseEntity : IEntity<int> {
        
        public int Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }
    }

}