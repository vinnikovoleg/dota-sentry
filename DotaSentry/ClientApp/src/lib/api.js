import axios from "axios";
import jsonBigInt from "json-bigint";

export default {
  live: {
    baseUrl: `/api/live`,
    get() {
      return axios.get(this.baseUrl, {
        transformResponse: [
          data => {
            var matches = jsonBigInt.parse(data);
            if (matches.length > 0) {
              matches.forEach(match => {
                match.serverSteamId = match.serverSteamId.toString();
              });
              return matches;
            }
          }
        ]
      });
    },
    getById(serverSteamId) {
      return axios.get(`${this.baseUrl}/${serverSteamId}`, {
        transformResponse: [
          data => {
            var liveMatchStats = jsonBigInt.parse(data);
            liveMatchStats.serverSteamId = liveMatchStats.serverSteamId.toString();
            return liveMatchStats;
          }
        ]
      });
    }
  }
};
