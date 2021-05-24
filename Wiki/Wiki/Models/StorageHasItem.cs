using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class StorageHasItem
    {
        public int StorageId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
