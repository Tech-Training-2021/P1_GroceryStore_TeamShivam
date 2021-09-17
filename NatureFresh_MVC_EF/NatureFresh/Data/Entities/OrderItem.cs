namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        public int Id { get; set; }

        public int? Orders { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int Weight { get; set; }

        public int? Units { get; set; }

        public virtual Order Order { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
