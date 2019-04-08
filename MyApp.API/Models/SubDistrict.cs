using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class SubDistrict
    {
        public SubDistrict()
        {
            StudentAcademics = new HashSet<StudentAcademic>();
            StudentRelations = new HashSet<StudentRelation>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public District District { get; set; }
        public ICollection<StudentAcademic> StudentAcademics { get; set; }
        public ICollection<StudentRelation> StudentRelations { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
