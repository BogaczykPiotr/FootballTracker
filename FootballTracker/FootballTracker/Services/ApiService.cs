using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using FootballTracker.Models;

namespace FootballTracker.Services
{
    public class ApiService : IApiService
    {
        public async Task<JToken> GetApiResult()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?live=all"),
                Headers =
            {
                { "X-RapidAPI-Key", "4cbcd3b2eemshcde42a8c44f8eadp1d2341jsncc344488b6e9" },
                { "X-RapidAPI-Host", "api-football-v1.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(body);


            var fixtures = json["response"];

                return fixtures;
        }
        }

        public async Task<List<Match>> GetMatches()
        {
            var json = await GetApiResult();

            var matches = new List<Match>();
            for (int i = 0; i < json.Count(); i++)
            {
                var fixture = json[i];
                var match = new Match()
                {
                    Home = fixture["teams"]["home"]["name"].ToString(),
                    Away = fixture["teams"]["away"]["name"].ToString(),
                    GoalHome = fixture["goals"]["home"].ToString(),
                    GoalAway = fixture["goals"]["away"].ToString(),
                };

                matches.Add(match);
            }

            return matches;
        }
    }
}
