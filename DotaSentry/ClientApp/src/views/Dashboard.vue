<template>
  <div class="dashboard">
    <div
      v-if="liveMatches != null && liveMatches.length > 0"
      class="matches"
    >
      <LiveMatch
        v-for="match in liveMatches"
        :key="match.matchId"
        :model="match"
      />
    </div>
  </div>
</template>

<script>

import { mapState } from 'vuex'
import LiveMatch from '../components/LiveMatch.vue'

export default {
  components: {
    LiveMatch
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
