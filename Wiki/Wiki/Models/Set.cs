using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class Set
    {
        public Set()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
