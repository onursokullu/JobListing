namespace JobListing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmployeeDetails
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Cv { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public int? ExperienceId { get; set; }

        public int? UserId { get; set; }

        public virtual Users Users { get; set; }
    }
}
