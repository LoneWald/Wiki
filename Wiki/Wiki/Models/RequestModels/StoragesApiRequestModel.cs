using Wiki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.ResponseModels
{
    public class StoragesApiRequestModel
    {
        public StoragesApiRequestModel(string name)
        {
            this.Name = name + "'s storage";
        }

        public string Name { get; set; }
    }
}
