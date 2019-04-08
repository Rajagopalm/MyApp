using System;
using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API.Dtos
{
    public class StudentRelationsForDetailedDto
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public String RelationType { get; set; }
        public string RelationName { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string AnnualIncome { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneWithStdcode { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public string PermanentDistrict { get; set; }
        public string PermanentState { get; set; }
        public string PermanentPincode { get; set; }
        
  
    }
}