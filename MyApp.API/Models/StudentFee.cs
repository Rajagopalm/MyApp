using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.API.Models
{
    public partial class StudentFee
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? StudentSemId { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FeesAmount { get; set; }
        public string FeesDesc { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public string ChequeNumber { get; set; }
        public string BankDetails { get; set; }

        public PaymentType PaymentType { get; set; }
        public Student Student { get; set; }
    }
}
