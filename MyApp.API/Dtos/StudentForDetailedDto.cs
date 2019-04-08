using System;
using System.Collections.Generic;
using MyApp.API.Models;

namespace MyApp.API.Dtos
{
    public class StudentForDetailedDto
    {

        public int Id { get; set; }
        public string Cfssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Caste { get; set; }
        public string MotherTongue { get; set; }
        public string Nationality { get; set; }
        public int? FirstAdmissionYear { get; set; }
        public string EmailId { get; set; }
        public string CurrentAddress { get; set; }
        public string CurrentCity { get; set; }
        public int? CurrentCityId { get; set; }
        public string CurrentDistrict { get; set; }
        public int? CurrentDistrictId { get; set; }
        public int? PinCode { get; set; }
        public string PhoneWithStdCode { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentCity { get; set; }
        public int? PermanentCityId { get; set; }
        public string PermanentDistrict { get; set; }
        public int? PermanentDistrictId { get; set; }
        public byte[] ProfilePicBinary { get; set; }
        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }
        public bool? StudentStatus { get; set; }
        public int? Marks { get; set; }
        public string PlaceOfBirth { get; set; }
        public int? PlaceOfBirthPinNo { get; set; }
        public string StateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public bool? Disability { get; set; }
        public string DisabilityType { get; set; }
        public string IsCollege { get; set; }
        public bool? IsAllSemSupport { get; set; }
        public string PrevCfssn { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOnUtc { get; set; }


        public ICollection<StudentEnrollmentsForDetailedDto> StudentEnrollments { get; set; }
        public ICollection<StudentAcademicsForDetailedDto> StudentAcademics { get; set; }
        public ICollection<StudentRelationsForDetailedDto> StudentRelations { get; set; }
    }
}