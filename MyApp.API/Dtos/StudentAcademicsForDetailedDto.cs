using System;
using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API.Dtos
{
    public class StudentAcademicsForDetailedDto
    {

        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolBoardType { get; set; }
        public string Standard { get; set; }
        public string AcademicGroup { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolCity { get; set; }
        public string SchoolDistrict { get; set; }
        public int? YearOfPassing { get; set; }
        public int? Marks { get; set; }
        public decimal? Percentage { get; set; }
        public string MediumOfInstruction { get; set; }
        
  
    }
}