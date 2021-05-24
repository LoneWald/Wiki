using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Wiki.Models.ResponseModels
{
    class GuildsApiResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ep { get; set; }
        public int Topposition { get; set; }
        public int Numberofmembers { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
