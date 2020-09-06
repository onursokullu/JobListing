namespace JobListing.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JobListingContext : DbContext
    {
        public JobListingContext()
            : base("name=JobListingContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<Experiences> Experiences { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Jobs)
                .WithOptional(e => e.Categories)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<EmployeeDetails>()
                .Property(e => e.Sex)
                .IsFixedLength();

            modelBuilder.Entity<Jobs>()
                .HasMany(e => e.CompanyDetails)
                .WithOptional(e => e.Jobs)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<UserRoles>()
                .Property(e => e.RoleName)
                .IsFixedLength();

            modelBuilder.Entity<UserRoles>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserRoles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CompanyDetails)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.EmployeeDetails)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.UserId);
        }
    }
}
