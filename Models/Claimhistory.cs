using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class Claimhistory
    {
        public int ClaimNo { get; set; }
        public int? PolicyNumber { get; set; }
        public long? ContactNo { get; set; }
        public string Claimreason { get; set; }
        public string IsApproved { get; set; }
        public int? ClaimId { get; set; }

        public virtual Claimreason Claim { get; set; }
        public virtual Policydetail PolicyNumberNavigation { get; set; }
    }
}
