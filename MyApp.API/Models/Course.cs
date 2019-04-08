using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentEnrollments = new HashSet<StudentEnrollment>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
