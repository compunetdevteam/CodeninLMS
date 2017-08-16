using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeninModel
{
    public class Course
    {
        public int CourseId { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}