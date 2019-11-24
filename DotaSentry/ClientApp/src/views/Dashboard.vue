<template>
  <div class="content">
      <div
          v-if="liveMatches != null && liveMatches.length > 0"
        >
          <div
            @click="navigate(match.serverSteamId)"
            v-bind:key="match.matchId"
            v-for="match in liveMatches"
          >
            <div>
              <picture>
                <img v-bind:src="match.radiant.logo" />
              </picture>
              <h4>{{ match.radiant.name }}</h4>
            </div>

            <div>
              <h2>{{ match.radiant.score }}</h2>
              <h2>{{ match.dire.score }}</h2>

              <div
                v-if="match.dire.lead > 0 || match.radiant.lead > 0"
              >
                <i class="material-icons md-light">trending_up</i>
                <h4>
                  {{
                    match.dire.lead > 0 ? match.dire.lead : match.radiant.lead
                  }}
                </h4>
              </div>
            </div>

            <div>
              <picture>
                <img v-bind:src="match.dire.logo" />
              </picture>
              <h4>{{ match.dire.name }}</h4>
            </div>
            <div>{{ match.gameTime.totalMinutes }}</div>
          </div>
        </div>
  </div>
</template>

<script>

import { mapState } from "vuex";

export default {
  components: {},
  data() {
    return {};
  },
  computed: {
    ...mapState({
      liveMatches: state => state.matches.liveMatches
    })
  },
  methods: {
    navigate(serverSteamId) {
      this.$router.push({
        name: "LiveMatch",
        params: { serverSteamId: serverSteamId }
      });
    }
  }
};
</script>
