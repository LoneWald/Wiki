﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Wiki.Models
{
    public partial class Characterclass
    {
        public Characterclass()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
