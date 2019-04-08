using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentRelation
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? RelationTypeId { get; set; }
        public string RelationName { get; set; }
        public string Occupation { get; set; }
        public string CompanyName { get; set; }
        public string AnnualIncome { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneWithStdcode { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public int? PermanentCityId { get; set; }
        public string PermanentDistrict { get; set; }
        public int? PermanentDistrictId { get; set; }
        public string PermanentState { get; set; }
        public int? PermanentStateId { get; set; }
        public string PermanentPincode { get; set; }

        public StudentRelation IdNavigation { get; set; }
        public SubDistrict PermanentCityNavigation { get; set; }
        public District PermanentDistrictNavigation { get; set; }
        public State PermanentStateNavigation { get; set; }
        public RelationType RelationType { get; set; }
        public Student Student { get; set; }
        public StudentRelation InverseIdNavigation { get; set; }
    }
}
