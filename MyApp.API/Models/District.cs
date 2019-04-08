using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class District
    {
        public District()
        {
            Colleges = new HashSet<College>();
            StudentAcademics = new HashSet<StudentAcademic>();
            StudentRelations = new HashSet<StudentRelation>();
            Students = new HashSet<Student>();
            SubDistricts = new HashSet<SubDistrict>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<College> Colleges { get; set; }
        public ICollection<StudentAcademic> StudentAcademics { get; set; }
        public ICollection<StudentRelation> StudentRelations { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<SubDistrict> SubDistricts { get; set; }
    }
}
