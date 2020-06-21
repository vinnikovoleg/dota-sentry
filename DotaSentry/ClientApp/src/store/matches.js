import api from '@/lib/api'

let trackingStarted = false

export default {
  namespaced: true,
  state: {
    liveMatches: [],
    liveMatchStats: []
  },
  mutations: {
    setLiveMatches(state, matches) {
      state.liveMatches = matches
    },
    setLiveMatchStats(state, liveMatchStats) {
      const existing = state.liveMatchStats
        .find((m) => m.serverSteamId === liveMatchStats.serverSteamId)
      if (existing != null) {
        const index = state.liveMatchStats.indexOf(existing)
        state.liveMatchStats.splice(index, 1)
      }

      state.liveMatchStats.push(liveMatchStats)
    }
  },
  actions: {
    async getLiveMatches({ commit }) {
      const getLive = async () => {
        const response = await api.live.get()
        commit('setLiveMatches', response.data)
      }
      await getLive()
      if (!trackingStarted) {
        trackingStarted = true
        setInterval(getLive, 3000)
      }
    },
    async getLiveMatchStats({ commit }, { serverSteamId }) {
      const response = await api.live.getById(serverSteamId)
      commit('setLiveMatchStats', response.data)
    }
  },
  getters: {
    getLiveMatchStats: (state) => (serverSteamId) => {
      const match = state.liveMatches.find((m) => m.serverSteamId == serverSteamId)
      const matchStats = state.liveMatchStats.find((m) => m.serverSteamId == serverSteamId)
      if (match != null && matchStats != null) {
        matchStats.radiant.score = match.radiant.score
        matchStats.dire.score = match.dire.score
        matchStats.radiant.lead = match.radiant.lead
        matchStats.dire.lead = match.dire.lead
      }

      return matchStats
    }
  }
}
