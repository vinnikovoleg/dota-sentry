<template>
  <div class="dashboard">
    <div
      v-if="liveMatches != null && liveMatches.length > 0"
      class="matches"
    >
      <div
        v-for="match in liveMatches"
        :key="match.matchId"
        class="match"
      >
        <router-link
          class="team"
          :to="{ name: 'LiveMatch', params: { serverSteamId: match.serverSteamId }}"
        >
          <LiveTeam :model="match.radiant" />
        </router-link>
        <router-link
          class="team"
          :to="{ name: 'LiveMatch', params: { serverSteamId: match.serverSteamId }}"
        >
          <LiveTeam :model="match.dire" />
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>

import { mapState } from 'vuex'
import LiveTeam from '../components/LiveTeam.vue'

export default {
  components: {
    LiveTeam
  },
  data() {
    return {}
  },
  computed: {
    ...mapState({
      liveMatches: (state) => state.matches.liveMatches
    })
  },
  created() {
    this.$store.dispatch('matches/getLiveMatches')
  },

  methods: {
    navigate(serverSteamId) {
      this.$router.push({
        name: 'LiveMatch',
        params: { serverSteamId }
      })
    }
  }
}
</script>
