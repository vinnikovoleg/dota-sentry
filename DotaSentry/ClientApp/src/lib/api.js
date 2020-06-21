import axios from 'axios'
import jsonBigInt from 'json-bigint'

export default {
  live: {
    baseUrl: '/api/livematch',
    get() {
      return axios.get(`${this.baseUrl}/`, {
        transformResponse: [
          // eslint-disable-next-line consistent-return
          (data) => {
            const matches = jsonBigInt.parse(data)
            if (matches.length > 0) {
              matches.forEach((match) => {
                match.serverSteamId = match.serverSteamId.toString()
              })
              return matches
            }
          }
        ]
      })
    },
    getById(serverSteamId) {
      return axios.get(`${this.baseUrl}/stats/${serverSteamId}`, {
        transformResponse: [
          (data) => {
            const liveMatchStats = jsonBigInt.parse(data)
            liveMatchStats.serverSteamId = liveMatchStats.serverSteamId.toString()
            return liveMatchStats
          }
        ]
      })
    }
  }
}
