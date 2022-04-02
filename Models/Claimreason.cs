using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class Claimreason
    {
        public Claimreason()
        {
            Claimhistories = new HashSet<Claimhistory>();
        }

        public int ClaimId { get; set; }
        public int? PolicyNumber { get; set; }
        public long? ContactNo { get; set; }
        public string Claimreason1 { get; set; }

        public virtual ICollection<Claimhistory> Claimhistories { get; set; }
    }
}
