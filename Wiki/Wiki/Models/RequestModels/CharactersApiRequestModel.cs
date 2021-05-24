using Wiki.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki.Models.ResponseModels
{
    public class CharactersApiRequestModel
    {

        public CharactersApiRequestModel()
        {

        }

        public CharactersApiRequestModel(string accountId, string name, string level, string hp, string mp, string strength, string agility, string intelligence, string characterclassId, string characterprofessionId, string guildId, string storageId)
        {
            this.AccountId = int.Parse(accountId);
            this.Name = name;
            this.Level = int.Parse(level);
            this.Hp = int.Parse(hp);
            this.Mp = int.Parse(mp);
            this.Strength = int.Parse(strength);
            this.Agility = int.Parse(agility);
            this.Intelligence = int.Parse(intelligence);
            this.CharacterclassId = int.Parse(characterclassId);
            this.CharacterprofessionId = int.Parse(characterprofessionId);
            this.GuildId = int.Parse(guildId);
            this.StorageId = int.Parse(storageId);
        }


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
    }
}
