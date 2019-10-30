import axios from 'axios'

const host = 'https://localhost:44333';

export default {
    getLiveMatches() {
        return axios.get(`/api/matches/live`)
    }
}