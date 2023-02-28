namespace EntityFramework02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactsTable")]
    public partial class ContactsTable
    {
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Count { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Kind { get; set; }
    }
}
