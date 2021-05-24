using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Wiki.Models.Register;
using System.IO;
using Xamarin.Essentials;
using Wiki.Models.Login;
using Wiki.Models.ResponseModels;
using System.Collections.ObjectModel;

namespace Wiki.Servises
{

    class CharacterApiServises : ApiServises
    {

        public string _selectAllPath;
        public string _selectAccountsCharactersPath;
        public string _addCharactersPath;
        public string _addStoragesPath;
        public string _selectStoragePath;

        public CharacterApiServises()
            : base()
        {
            _selectAllPath = "api/Characters";
            _selectAccountsCharactersPath = "api/Characters/by-account-id";
            _addCharactersPath = "api/Characters/add";
            _addStoragesPath = "api/Storages/add";
            _selectStoragePath = "api/Storages/by-name";
        }

        public async Task<ObservableCollection<CharactersApiResponseModel>> SelectAccountsCharactersAsync(int accountId)
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAccountsCharactersPath + $"?accountId={accountId}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsoncontent = JsonConvert.DeserializeObject<ObservableCollection<CharactersApiResponseModel>>(jsonString, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
                return jsoncontent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ObservableCollection<CharactersApiResponseModel>> SelectAllCharactersAsync()
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAllPath);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsoncontent = JsonConvert.DeserializeObject<ObservableCollection<CharactersApiResponseModel>>(jsonString, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
                return jsoncontent;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CharactersApiResponseModel> AddCharacterAsync(string accountId, string name, string level, string hp, string mp, string strength, string agility, string intelligence, string characterclassId, string characterprofessionId, string guildId)
        {
            try
            {
                StoragesApiRequestModel storageRequestModel = new StoragesApiRequestModel(name);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _addStoragesPath);
                var content = new StringContent(JsonConvert.SerializeObject(storageRequestModel), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var storagecontent = JsonConvert.DeserializeObject<StorageApiResponseModel>(jsonString, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

                CharactersApiRequestModel characterRequestModel = new CharactersApiRequestModel(accountId, name, level, hp, mp, strength, agility, intelligence, characterclassId, characterprofessionId, guildId, storagecontent.Id.ToString());
                using HttpRequestMessage request_2 = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _addCharactersPath);
                
                content = new StringContent(JsonConvert.SerializeObject(characterRequestModel), Encoding.UTF8, "application/json");

                request_2.Content = content;
                response = await client.SendAsync(request_2);
                response.EnsureSuccessStatusCode();
                jsonString = await response.Content.ReadAsStringAsync();
                var jsoncontent = JsonConvert.DeserializeObject<CharactersApiResponseModel>(jsonString, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
                return jsoncontent;
                /*
                var response = await client.PostAsync(client.BaseAddress + _addCharactersPath, content);
                response.EnsureSuccessStatusCode();
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(stream))
                using (var json = new JsonTextReader(reader))
                {
                    var jsoncontent = _serialazer.Deserialize<CharactersApiResponseModel>(json);
                    return jsoncontent;
                }
                */
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }


}
