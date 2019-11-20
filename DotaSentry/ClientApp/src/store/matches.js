import api from "@/lib/api";

export default {
  namespaced: true,
  state: {
    liveMatches: [],
    liveMatchStats: null
  },
  mutations: {
    setLiveMatches(state, matches) {
      state.liveMatches = matches;
    },
    setLiveMatchStats(state, liveMatchStats) {
      state.liveMatchStats = liveMatchStats;
    }
  },
  actions: {
    async getLiveMatches({ commit }) {
      const response = await api.getLiveMatches();
      commit("setLiveMatches", response.data);
    },
    async getLiveMatchStats({ commit }, { serverSteamId }) {
      const response = await api.getLiveMatchStats(serverSteamId);
      commit("setLiveMatchStats", response.data);
    }
  }
};
