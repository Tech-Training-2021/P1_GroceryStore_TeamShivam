namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        public int? InventoryItems { get; set; }

        public int? Outlets { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Weight { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }

        public virtual Outlet Outlet { get; set; }
    }
}
