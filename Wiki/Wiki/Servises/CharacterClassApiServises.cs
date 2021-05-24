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
    class CharacterClassApiServises : ApiServises
    {

        public string _selectAllPath;
        public string _addClassPath;

        public CharacterClassApiServises()
            : base()
        {
            _selectAllPath = "api/CharacterClasses";
            _addClassPath = "api/CharacterClasses/add";
        }

        public async Task<ObservableCollection<CharacterClassesApiResponseModel>> SelectCharacterClassesAsync()
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAllPath);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsoncontent = JsonConvert.DeserializeObject<ObservableCollection<CharacterClassesApiResponseModel>>(jsonString, new JsonSerializerSettings
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

        public async Task<CharacterClassesApiResponseModel> AddCharacterClassAsync(string name, string description)
        {
            try
            {
                CharacterClassesApiRequestModel classRequestModel = new CharacterClassesApiRequestModel(name, description);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _addClassPath);
                var content = new StringContent(JsonConvert.SerializeObject(classRequestModel), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsoncontent = JsonConvert.DeserializeObject<CharacterClassesApiResponseModel>(jsonString, new JsonSerializerSettings
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
