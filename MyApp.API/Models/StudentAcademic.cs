using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentAcademic
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolBoardType { get; set; }
        public string Standard { get; set; }
        public string AcademicGroup { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolCity { get; set; }
        public int? SchoolCityId { get; set; }
        public string SchoolDistrict { get; set; }
        public int? SchoolDistrictId { get; set; }
        public int? YearOfPassing { get; set; }
        public int? Marks { get; set; }
        public decimal? Percentage { get; set; }
        public string MediumOfInstruction { get; set; }

        public StudentAcademic IdNavigation { get; set; }
        public SubDistrict SchoolCityNavigation { get; set; }
        public District SchoolDistrictNavigation { get; set; }
        public Student Student { get; set; }
        public StudentAcademic InverseIdNavigation { get; set; }
    }
}
