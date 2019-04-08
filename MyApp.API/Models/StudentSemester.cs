using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentSemester
    {
        public int Id { get; set; }
        public int StudentEnrollId { get; set; }
        public int SemesterId { get; set; }
        public decimal? SemesterGrade { get; set; }

        public Semester Semester { get; set; }
        public StudentEnrollment StudentEnroll { get; set; }
    }
}
