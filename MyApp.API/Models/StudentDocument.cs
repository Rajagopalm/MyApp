using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class StudentDocument
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentDesc { get; set; }
        public byte[] DocumentBinary { get; set; }

        public Student DocumentType { get; set; }
    }
}
