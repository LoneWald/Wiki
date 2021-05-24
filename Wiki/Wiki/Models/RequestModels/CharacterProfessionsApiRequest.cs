using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.RequestModels
{
    class CharacterProfessionsApiRequestModel
    {
        public CharacterProfessionsApiRequestModel()
        {
        }

        public CharacterProfessionsApiRequestModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
