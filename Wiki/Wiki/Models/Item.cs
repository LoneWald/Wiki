using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ItemtypeId { get; set; }
        public int? SetsId { get; set; }

        public virtual Itemtype Itemtype { get; set; }
        public virtual Set Sets { get; set; }
    }
}
