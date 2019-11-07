<template>
  <div class="content">
    <div class="md-layout">
      {{serverSteamId}}
      <div v-if="liveMatch != null">
        {{liveMatch.match.matchId}}
      </div>
    </div>
    dsafsdfasdf
  </div>
</template>

<script>

import { mapState } from 'vuex';

export default {
  components: {  },
  data() {
    return {
      
    };
  },
  async created() {
    await this.$store.dispatch('matches/getLiveMatchStats', {serverSteamId: this.serverSteamId });
  },
  computed: {
      serverSteamId() {
          return this.$route.params.serverSteamId;
      },
      ...mapState({
            liveMatchStats: state => state.matches.liveMatchStats
      }),
      liveMatch() {
        if (this.liveMatchStats.hasOwnProperty(this.serverSteamId )) {
          return this.liveMatchStats[this.serverSteamId];
        }

        return null;
      }
  }
};
</script>
