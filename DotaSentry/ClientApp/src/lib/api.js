import axios from 'axios'

export default {
    getLiveMatches() {
        return axios.get(`/api/matches/live`)
    }
}