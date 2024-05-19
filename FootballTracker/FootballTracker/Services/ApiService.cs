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
        //public async Task<JToken> GetApiResult()
        //{
        //    var client = new HttpClient();
        //    var request = new HttpRequestMessage
        //    {
        //        Method = HttpMethod.Get,
        //        RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?live=all"),
        //        Headers =
        //    {
        //        { "X-RapidAPI-Key", "4cbcd3b2eemshcde42a8c44f8eadp1d2341jsncc344488b6e9" },
        //        { "X-RapidAPI-Host", "api-football-v1.p.rapidapi.com" },
        //    },
        //};
        //using (var response = await client.SendAsync(request))
        //{
        //    response.EnsureSuccessStatusCode();
        //    var body = await response.Content.ReadAsStringAsync();

        //    var json = JObject.Parse(body);


        //    var fixtures = json["response"];

        //        return fixtures;
        //}
        //}

        public async Task<List<Match>> GetMatches()
        {
            //var json = await GetApiResult();

            //var matches = new List<Match>();
            //for (int i = 0; i < json.Count(); i++)
            //{
            //    var fixture = json[i];
            //    var match = new Match()
            //    {
            //        Home = fixture["teams"]["home"]["name"].ToString(),
            //        HomeLogo = fixture["teams"]["home"]["logo"].ToString(),
            //        Away = fixture["teams"]["away"]["name"].ToString(),
            //        AwayLogo = fixture["teams"]["away"]["logo"].ToString(),
            //        GoalHome = fixture["goals"]["home"].ToString(),
            //        GoalAway = fixture["goals"]["away"].ToString(),
            //    };

            //    matches.Add(match);
            //}

            //return matches;

            var matches = new List<Match>();

            var match = new Match()
                {
                    Home = "PSG",
                    HomeLogo = "https://media.api-sports.io/football/teams/85.png",
                    Away = "BvB",
                    AwayLogo = "https://media.api-sports.io/football/teams/33.png",
                    GoalHome = "3",
                    GoalAway = "2"
                };

            var match2 = new Match()
            {
                Home = "Real",
                HomeLogo = "https://media.api-sports.io/football/teams/541.png",
                Away = "Barca",
                AwayLogo = "https://media.api-sports.io/football/teams/529.png",
                GoalHome = "1",
                GoalAway = "1"
            };

            matches.Add(match);
            matches.Add(match2);

            return matches;
        }

        public async Task<Team> GetTeamName(int id)
        {
            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri($"https://api-football-v1.p.rapidapi.com/v3/teams?id={id}"),
            //            Headers =
            //{
            //            { "X-RapidAPI-Key", "4cbcd3b2eemshcde42a8c44f8eadp1d2341jsncc344488b6e9" },
            //            { "X-RapidAPI-Host", "api-football-v1.p.rapidapi.com" },
            //},
            //        };

            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var body = await response.Content.ReadAsStringAsync();
            //            var json = JObject.Parse(body);

            //            var teamName = json["response"][0]["team"]["name"].ToString();
            //            var teamLogo = json["response"][0]["team"]["logo"].ToString();

            //            return new Team
            //            {
            //                Id = favTeam,
            //                Name = teamName,
            //                Logo = teamLogo,
            //            };

            return new Team
            {
                Id = id,
                Name = "Manchester United",
                Logo = "https://media.api-sports.io/football/teams/33.png"
            };

        }  
            public async Task<List<Match>> GetMatchByFavTeam(int id)
            {
            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?season=2023&team=33"),
            //            Headers =
            //{
            //    { "X-RapidAPI-Key", "4cbcd3b2eemshcde42a8c44f8eadp1d2341jsncc344488b6e9" },
            //    { "X-RapidAPI-Host", "api-football-v1.p.rapidapi.com" },
            //},
            //        };
            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var body = await response.Content.ReadAsStringAsync();
            //            Console.WriteLine(body);
            //            var json = JObject.Parse(body);

            //            var matches = new List<Match>();

            //            var jToken = json["response"];

            //            for (int i = 0; i < 3; i++)
            //            {
            //                var fixture = jToken[i];
            //                var match = new Match()
            //                {
            //                    Home = fixture["teams"]["home"]["name"].ToString(),
            //                    HomeLogo = fixture["teams"]["home"]["logo"].ToString(),
            //                    Away = fixture["teams"]["away"]["name"].ToString(),
            //                    AwayLogo = fixture["teams"]["away"]["logo"].ToString(),
            //                    GoalHome = fixture["goals"]["home"].ToString(),
            //                    GoalAway = fixture["goals"]["away"].ToString(),
            //                };

            //                matches.Add(match);
            //            }

            //            return matches;


            var matches = new List<Match>();

            var match = new Match()
            {
                Home = "PSG",
                HomeLogo = "https://media.api-sports.io/football/teams/85.png",
                Away = "BvB",
                AwayLogo = "https://media.api-sports.io/football/teams/33.png",
                GoalHome = "3",
                GoalAway = "2"
            };

            var match2 = new Match()
            {
                Home = "Real",
                HomeLogo = "https://media.api-sports.io/football/teams/541.png",
                Away = "Barca",
                AwayLogo = "https://media.api-sports.io/football/teams/529.png",
                GoalHome = "1",
                GoalAway = "1"
            };

            var match3 = new Match()
            {
                Home = "B",
                HomeLogo = "https://media.api-sports.io/football/teams/31.png",
                Away = "A",
                AwayLogo = "https://media.api-sports.io/football/teams/32.png",
                GoalHome = "1",
                GoalAway = "1"
            };

            matches.Add(match);
            matches.Add(match2);
            matches.Add(match3);

            return matches;
        }
    }
}
