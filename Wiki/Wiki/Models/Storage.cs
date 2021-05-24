using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
