using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class RelationType
    {
        public RelationType()
        {
            StudentRelations = new HashSet<StudentRelation>();
        }

        public int Id { get; set; }
        public string Relation { get; set; }
        public string RelationTypeDesc { get; set; }

        public ICollection<StudentRelation> StudentRelations { get; set; }
    }
}
