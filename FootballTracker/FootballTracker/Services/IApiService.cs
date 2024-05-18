using FootballTracker.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballTracker.Services
{
    internal interface IApiService
    {
        Task<List<Match>> GetMatches();
        Task<JToken> GetApiResult();
    }
}
