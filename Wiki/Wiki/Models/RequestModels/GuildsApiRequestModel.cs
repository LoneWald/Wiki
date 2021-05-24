using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.RequestModels
{
    class GuildsApiRequestModel
    {

        public GuildsApiRequestModel(string name, string ep, string members, string topposition)
        {
            this.Name = name;
            this.Ep = int.Parse(ep);
            this.Numberofmembers = int.Parse(members);
            this.Topposition = int.Parse(topposition);

        }
        public string Name { get; set; }
        public int Ep { get; set; }
        public int Numberofmembers { get; set; }
        public int Topposition { get; set; }
    }
}
