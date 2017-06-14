using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("CustomerId", this.CustomerId.ToString()));
            return userIdentity;
        }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<DashBoard> DashBoards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FieldRegulation> FieldRegulations { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<SetDataField> SetDataFields { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SetDataField>()
                        .HasKey(e => e.FieldId);

            // Configure StudentId as FK for StudentAddress
            modelBuilder.Entity<Field>()
                        .HasOptional(s => s.SetDataField)
                        .WithRequired(ad => ad.Field);
        }
    }
}
