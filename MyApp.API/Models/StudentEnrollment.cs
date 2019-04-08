using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentEnrollment
    {
        public StudentEnrollment()
        {
            StudentSemesters = new HashSet<StudentSemester>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int CollegeId { get; set; }
        public int? EnrollmentYear { get; set; }
        public string EnrollmentDesc { get; set; }

        public College College { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public ICollection<StudentSemester> StudentSemesters { get; set; }
    }
}
