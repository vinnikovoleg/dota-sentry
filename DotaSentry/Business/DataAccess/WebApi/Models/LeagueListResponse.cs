using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotaSentry.Business.DataAccess.WebApi.Models
{
    public class LeagueListResponse
    {
        [JsonProperty("infos")]
        public List<League> Leagues { get; set; }
    }
}