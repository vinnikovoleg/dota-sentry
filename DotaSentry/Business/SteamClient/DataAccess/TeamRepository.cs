﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DotaSentry.Models.SteamClient;

namespace DotaSentry.Business.SteamClient.DataAccess
{
    public class TeamRepository  : SteamBaseRepository
    {
        public TeamRepository(JsonClient jsonClient) : base(jsonClient)
        {
        }

        public async Task<GetTeamInfoResponse> GetTeamInfoAsync(long teamId)
        {
            var parameters = new Dictionary<string, string>
            {
                { "teams_requested", "1" },
                { "start_at_team_id", teamId.ToString() }
            };
            var requestUrl = GetRequestUrl("IDOTA2Match_570", "GetTeamInfoByTeamID", parameters);
            return await JsonClient.GetAsync<GetTeamInfoResponse>(requestUrl);
        }
    }
}