namespace JobListing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CompanyDetails
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string CompanyName { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [StringLength(50)]
        public string Logo { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        public int? UserId { get; set; }

        public int? JobId { get; set; }

        public virtual Jobs Jobs { get; set; }

        public virtual Users Users { get; set; }
    }
}
