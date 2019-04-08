using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class Semester
    {
        public Semester()
        {
            StudentSemesters = new HashSet<StudentSemester>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string SemesterDesc { get; set; }
        public string SemesterStartMonth { get; set; }
        public string SemesterEndMonth { get; set; }

        public ICollection<StudentSemester> StudentSemesters { get; set; }
    }
}
