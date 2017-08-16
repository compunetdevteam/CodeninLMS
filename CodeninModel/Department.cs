using System.Collections.Generic;
using LMSModel;

namespace CodeninModel
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}