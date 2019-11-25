<template>
  <div class="content">
      <v-container
        fluid
          v-if="liveMatches != null && liveMatches.length > 0"
        >
          <v-row>
          <v-col cols="3"
            v-bind:key="match.matchId"
            v-for="match in liveMatches"
            class="match pa-3 ma-1">
           
              <v-card 
                tile
                hover
                :to="{ name: 'LiveMatch', params: {serverSteamId: match.serverSteamId}}"
                height="160px">
                <v-row>
                  
                  <v-col cols="4" class="team">
                    <v-row justify="center" align="center">
                          <v-img :src="match.radiant.logo"
                           :alt="match.radiant.name"
                           max-width="100" aspect-ratio="1"
                          />
                    </v-row>
                    <v-row  justify="center" align="center">
                       <span class="subtitle-1">{{ match.radiant.name }}</span>
                    </v-row>
                  </v-col>

                  <v-col cols="4"> 
                    <v-row justify="center" align="center">
                      <span class="headline ma-1">{{ match.radiant.score }}</span>
                      <span class="headline ma-1">:</span>
                      <span class="headline ma-1">{{ match.dire.score }}</span>
                    </v-row>
                    <v-row v-if="match.radiant.lead > 0 || match.dire.lead > 0" justify="start" align="center">
                      <v-icon class="ma-2">mdi-chart-line-variant</v-icon>
                      <span class="subtitle-1">
                        {{
                          match.dire.lead > 0 ? match.dire.lead : match.radiant.lead
                        }}
                      </span>
                    </v-row>

                  </v-col>

                  <v-col cols="4" class="team" >
                    <v-row justify="center" align="center">
                       <v-img :src="match.dire.logo"
                         aspect-ratio="1"
                          max-width="100"
                          :alt="match.dire.name"
                         />
                    </v-row>
                    <v-row justify="center" align="center">
                      <span class="subtitle-1">{{ match.dire.name }}</span>
                    </v-row>
                  </v-col>
                  <!-- <div>{{ match.gameTime.totalMinutes }}</div> -->
                </v-row>
              </v-card>
          
          </v-col>
          </v-row>
        </v-container>
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
