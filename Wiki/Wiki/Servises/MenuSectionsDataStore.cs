using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wiki.Models;

namespace Wiki.Services
{
    public class MenuSectionsDataStore : IDataStore<MenuSection>
    {
        readonly List<MenuSection> menuSections;

        public MenuSectionsDataStore()
        {
            menuSections = new List<MenuSection>()
            {
                new MenuSection { Id = "Characters", Text = "Characters", PathToImage="icon_character.png" },
                new MenuSection { Id = "Guilds", Text = "Guilds", PathToImage="icon_guild.png" },
                new MenuSection { Id = "Classes", Text = "Classes", PathToImage="icon_class.png"},
                new MenuSection { Id = "Items", Text = "Items", PathToImage="icon_item.png"},
                new MenuSection { Id = "Accounts", Text = "Accounts", PathToImage="icon_account.png"},
                new MenuSection { Id = "Settings", Text = "Settings", PathToImage="icon_settings.png"}
                
            };
        }

        public async Task<bool> AddItemAsync(MenuSection menuitem)
        {
            menuSections.Add(menuitem);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(MenuSection menuitem)
        {
            var oldItem = menuSections.Where((MenuSection arg) => arg.Id == menuitem.Id).FirstOrDefault();
            menuSections.Remove(oldItem);
            menuSections.Add(menuitem);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = menuSections.Where((MenuSection arg) => arg.Id == id).FirstOrDefault();
            menuSections.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<MenuSection> GetItemAsync(string id)
        {
            return await Task.FromResult(menuSections.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MenuSection>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(menuSections);
        }
    }
}