using Wiki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.ResponseModels
{
    public class CharactersApiResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CharacterclassId { get; set; }
        public int CharacterprofessionId { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int StorageId { get; set; }
        public int? AccountId { get; set; }
        public int? GuildId { get; set; }

        public Account Account { get; set; }
        public Characterclass Characterclass { get; set; }
        public Characterprofession Characterprofession { get; set; }
        public Guild Guild { get; set; }
        public Storage Storage { get; set; }
    }
}
