using System;
using System.Collections.Generic;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class Vehiclesdetail
    {
        public Vehiclesdetail()
        {
            Policydetails = new HashSet<Policydetail>();
        }

        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ChasisNumber { get; set; }
        public int? VehicleAge { get; set; }

        public virtual ICollection<Policydetail> Policydetails { get; set; }
    }
}
