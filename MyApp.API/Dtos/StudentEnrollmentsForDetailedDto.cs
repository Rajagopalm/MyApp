using System;
using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API.Dtos
{
    public class StudentEnrollmentsForDetailedDto
    {

        
        public int StudentId { get; set; }
        public int? EnrollmentYear { get; set; }
        public string EnrollmentDesc { get; set; }

        public String CourseName { get; set; }
        public String CollegeName { get; set; }    
  
    }
}