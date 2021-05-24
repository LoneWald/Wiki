using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models.RequestModels;
using Wiki.Models.ResponseModels;
using Wiki.Servises;

namespace Wiki.Servises
{
    class CharacterProfessionApiServises : ApiServises
    {

        public string _selectAllPath;
        public string _addProfessionPath;

        public CharacterProfessionApiServises()
            : base()
        {
            _selectAllPath = "api/CharacterProfessions";
            _addProfessionPath = "api/CharacterProfessions/add";
        }

        public async Task<ObservableCollection<CharacterProfessionsApiResponseModel>> SelectCharacterProfessionsAsync()
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAllPath);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsoncontent = JsonConvert.DeserializeObject<ObservableCollection<CharacterProfessionsApiResponseModel>>(jsonString, new JsonSerializerSettings
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

        public async Task<CharacterProfessionsApiResponseModel> AddCharacterProfessionAsync(string name, string description)
        {
            try
            {
                CharacterProfessionsApiRequestModel professionRequestModel = new CharacterProfessionsApiRequestModel(name, description);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _addProfessionPath);
                var content = new StringContent(JsonConvert.SerializeObject(professionRequestModel), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsoncontent = JsonConvert.DeserializeObject<CharacterProfessionsApiResponseModel>(jsonString, new JsonSerializerSettings
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
    }
}
