namespace JobListing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jobs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jobs()
        {
            CompanyDetails = new HashSet<CompanyDetails>();
        }

        public int Id { get; set; }

        public int? CompanyId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(100)]
        public string ShortDescription { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        public string CompanyEmail { get; set; }

        public bool IsDelete { get; set; }

        public virtual Categories Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyDetails> CompanyDetails { get; set; }
    }
}
