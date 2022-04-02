using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gladiator_General_InsuranceApi3.Models
{
    public partial class General_Insurance6Context : DbContext
    {
        public General_Insurance6Context()
        {
        }

        public General_Insurance6Context(DbContextOptions<General_Insurance6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Claimhistory> Claimhistories { get; set; }
        public virtual DbSet<Claimreason> Claimreasons { get; set; }
        public virtual DbSet<Insuranceduration> Insurancedurations { get; set; }
        public virtual DbSet<Insuranceplantype> Insuranceplantypes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Policydetail> Policydetails { get; set; }
        public virtual DbSet<Renew> Renews { get; set; }
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; }
        public virtual DbSet<Vehiclesdetail> Vehiclesdetails { get; set; }
        public virtual DbSet<Vehicletype> Vehicletypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("data source = PAP-LAP; initial Catalog = General_Insurance6; integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Claimhistory>(entity =>
            {
                entity.HasKey(e => e.ClaimNo)
                    .HasName("PK__claimhis__01BDA221999931EF");

                entity.ToTable("claimhistory");

                entity.Property(e => e.ClaimNo).HasColumnName("claimNo");

                entity.Property(e => e.ClaimId).HasColumnName("claimId");

                entity.Property(e => e.Claimreason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("claimreason");

                entity.Property(e => e.ContactNo).HasColumnName("contactNo");

                entity.Property(e => e.IsApproved)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("isApproved");

                entity.Property(e => e.PolicyNumber).HasColumnName("policyNumber");

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.Claimhistories)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__claimhist__claim__4BAC3F29");

                entity.HasOne(d => d.PolicyNumberNavigation)
                    .WithMany(p => p.Claimhistories)
                    .HasForeignKey(d => d.PolicyNumber)
                    .HasConstraintName("FK__claimhist__polic__4AB81AF0");
            });

            modelBuilder.Entity<Claimreason>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK__claimrea__01BDF9D39F2467F0");

                entity.ToTable("claimreasons");

                entity.Property(e => e.ClaimId).HasColumnName("claimId");

                entity.Property(e => e.Claimreason1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("claimreason");

                entity.Property(e => e.ContactNo).HasColumnName("contactNo");

                entity.Property(e => e.PolicyNumber).HasColumnName("policyNumber");
            });

            modelBuilder.Entity<Insuranceduration>(entity =>
            {
                entity.HasKey(e => e.DurationId)
                    .HasName("PK__insuranc__C3432CEBB9B4D649");

                entity.ToTable("insuranceduration");

                entity.Property(e => e.DurationId).HasColumnName("durationId");

                entity.Property(e => e.DurationValue)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("durationValue");
            });

            modelBuilder.Entity<Insuranceplantype>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PK__insuranc__A2942D387E781366");

                entity.ToTable("insuranceplantype");

                entity.Property(e => e.PlanId).HasColumnName("planId");

                entity.Property(e => e.PlanName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("planName");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("login");

                entity.Property(e => e.LoginId).HasColumnName("loginId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<Policydetail>(entity =>
            {
                entity.HasKey(e => e.PolicyNumber)
                    .HasName("PK__policyde__57AD6F2464F591EC");

                entity.ToTable("policydetails");

                entity.Property(e => e.PolicyNumber).HasColumnName("policyNumber");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Policydetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__policydet__userI__440B1D61");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Policydetails)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__policydet__vehic__4316F928");
            });

            modelBuilder.Entity<Renew>(entity =>
            {
                entity.ToTable("renew");

                entity.Property(e => e.RenewId).HasColumnName("renewId");

                entity.Property(e => e.ContactNo).HasColumnName("contactNo");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.PolicyNumber).HasColumnName("policyNumber");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__userRegi__CB9A1CFF41A205B0");

                entity.ToTable("userRegistration");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNo).HasColumnName("contactNo");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<Vehiclesdetail>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__vehicles__5B9D25F2E2EEF129");

                entity.ToTable("vehiclesdetails");

                entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

                entity.Property(e => e.ChasisNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("chasisNumber");

                entity.Property(e => e.DrivingLicenseNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("drivingLicenseNumber");

                entity.Property(e => e.EngineNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("engineNumber");

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manufacturer");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("registrationNumber");

                entity.Property(e => e.VehicleAge).HasColumnName("vehicleAge");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("vehicleType");
            });

            modelBuilder.Entity<Vehicletype>(entity =>
            {
                entity.ToTable("vehicletypes");

                entity.Property(e => e.VehicleTypeId).HasColumnName("vehicleTypeId");

                entity.Property(e => e.VehicleType1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vehicleType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
