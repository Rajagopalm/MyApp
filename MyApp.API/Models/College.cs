using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class College
    {
        public College()
        {
            StudentEnrollments = new HashSet<StudentEnrollment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PinCode { get; set; }
        public string ContactNumber { get; set; }
        public string District { get; set; }
        public int? DistrictId { get; set; }

        public District CollegeDistrictNavigation { get; set; }
        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
    }
}
