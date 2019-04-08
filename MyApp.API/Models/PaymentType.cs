using System;
using System.Collections.Generic;

namespace MyApp.API.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            StudentFees = new HashSet<StudentFee>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string PaymentDesc { get; set; }

        public ICollection<StudentFee> StudentFees { get; set; }
    }
}
