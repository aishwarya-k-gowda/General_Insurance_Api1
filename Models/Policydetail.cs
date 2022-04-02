using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class Policydetail
    {
        public Policydetail()
        {
            Claimhistories = new HashSet<Claimhistory>();
        }

        public int PolicyNumber { get; set; }
        public string Model { get; set; }
        public string RegistrationNumber { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public int? VehicleId { get; set; }

        public virtual UserRegistration User { get; set; }
        public virtual Vehiclesdetail Vehicle { get; set; }
        public virtual ICollection<Claimhistory> Claimhistories { get; set; }
    }
}
