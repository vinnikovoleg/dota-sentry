import axios from 'axios'
import jsonBigInt from 'json-bigint'

export default {
    getLiveMatches() {
        return axios.get(`/api/live`, { 
            transformResponse: [data  => {
                var matches = jsonBigInt.parse(data);
                if (matches.length > 0) {
                  matches.forEach(match => {
                    match.serverSteamId = match.serverSteamId.toString();
                  });
                }
            }] 
        })
    },
    getLiveMatchStats(serverSteamId) {
        return axios.get(`/api/live/${serverSteamId}`, {
            transformResponse: [data  => {
                var liveMatchStats = jsonBigInt.parse(data);
                liveMatchStats.match.serverSteamId = liveMatchStats.match.serverSteamId.toString();
            }] 
        })
    }
}