using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class Renew
    {
        public long RenewId { get; set; }
        public int? PolicyNumber { get; set; }
        public long? ContactNo { get; set; }
        public string Email { get; set; }
    }
}
