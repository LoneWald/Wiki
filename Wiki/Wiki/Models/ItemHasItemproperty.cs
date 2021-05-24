using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class ItemHasItemproperty
    {
        public int ItemId { get; set; }
        public int ItempropertyId { get; set; }
        public int? Value { get; set; }

        public virtual Item Item { get; set; }
        public virtual Itemproperty ItemNavigation { get; set; }
    }
}
