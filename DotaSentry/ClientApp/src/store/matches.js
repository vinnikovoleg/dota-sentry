import api from '@/lib/api'

export default {
  namespaced: true,
  state: {
    liveMatches: []
  },
  mutations: {
    setLiveMatches(state, matches) {
      state.liveMatches = matches;
    }
  },
  actions: {
    async getLiveMatches({ commit }) {
      const response = await api.getLiveMatches()
      commit('setLiveMatches', response.data)
    }
  }
}
