import axios from 'axios'

export default {
    getLiveMatches() {
        return axios.get(`/api/live`)
    },
    getLiveMatchStats(serverSteamId) {
        return axios.get(`/api/live/${serverSteamId}`)
    }
}