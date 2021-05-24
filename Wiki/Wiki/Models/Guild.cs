using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class Guild
    {
        public Guild()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ep { get; set; }
        public int Topposition { get; set; }
        public int Numberofmembers { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
