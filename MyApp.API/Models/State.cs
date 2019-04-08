using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class State
    {
        public State()
        {
            Districts = new HashSet<District>();
            StudentRelations = new HashSet<StudentRelation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<District> Districts { get; set; }
        public ICollection<StudentRelation> StudentRelations { get; set; }
    }
}
