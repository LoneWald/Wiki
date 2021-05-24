using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.ResponseModels;

namespace Wiki.Services
{
    public class CharactersDataStore : IDataStore<CharactersApiResponseModel>
    {
        readonly List<CharactersApiResponseModel> characters;

        public CharactersDataStore()
        {
            characters = new List<CharactersApiResponseModel>()
            {
            };
        }

        public async Task<bool> AddItemAsync(CharactersApiResponseModel menuitem)
        {
            characters.Add(menuitem);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CharactersApiResponseModel menuitem)
        {
            var oldItem = characters.Where((CharactersApiResponseModel arg) => arg.Id == menuitem.Id).FirstOrDefault();
            characters.Remove(oldItem);
            characters.Add(menuitem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = characters.Where((CharactersApiResponseModel arg) => arg.Id == int.Parse(id)).FirstOrDefault();
            characters.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<CharactersApiResponseModel> GetItemAsync(string id)
        {
            return await Task.FromResult(characters.FirstOrDefault(s => s.Id == int.Parse(id)));
        }

        public async Task<IEnumerable<CharactersApiResponseModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(characters);
        }

    }
}
