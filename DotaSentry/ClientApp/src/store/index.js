import Vue from "vue";
import Vuex from "vuex";

import matches from "./matches";

Vue.use(Vuex);

const modules = {
  matches
};

const store = new Vuex.Store({
  modules,
  state: {},
  mutations: {},
  actions: {}
});

export default store;
