using Wiki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.ResponseModels
{
    public class StorageApiResponseModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

    }
}