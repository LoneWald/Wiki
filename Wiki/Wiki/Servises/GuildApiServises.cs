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
    class GuildApiServises : ApiServises
    {

        public string _selectAllPath;
        public string _addGuildPath;

        public GuildApiServises()
            : base()
        {
            _selectAllPath = "api/Guilds";
            _addGuildPath = "api/Guilds/add";
        }

        public async Task<ObservableCollection<GuildsApiResponseModel>> SelectGuildsAsync()
        {
            try
            {
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress + _selectAllPath);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                var jsoncontent = JsonConvert.DeserializeObject<ObservableCollection<GuildsApiResponseModel>>(jsonString, new JsonSerializerSettings
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

        public async Task<GuildsApiResponseModel> AddGuildAsync(string name, string ep, string members, string topposition)
        {
            try
            {
                GuildsApiRequestModel guildRequestModel = new GuildsApiRequestModel(name, ep, members, topposition);
                using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress + _addGuildPath);
                var content = new StringContent(JsonConvert.SerializeObject(guildRequestModel), Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsoncontent = JsonConvert.DeserializeObject<GuildsApiResponseModel>(jsonString, new JsonSerializerSettings
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
