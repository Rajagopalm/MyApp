using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentPlacement
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Organisation { get; set; }
        public string PlacementStartDate { get; set; }
        public string PlacementDesc { get; set; }

        public Student Student { get; set; }
    }
}
