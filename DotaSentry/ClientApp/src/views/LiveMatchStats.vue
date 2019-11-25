<template>
  <div class="content">
    <v-container v-if="liveMatch != null">
      <v-row>
        <v-col cols="4">
          <v-card rised max-width="150">
             <v-img
               aspect-ratio="1"
               max-width="150"
              :src="liveMatch.radiant.logo"></v-img>
             
          </v-card>
         <span>{{liveMatch.radiant.name}}</span>
        </v-col>
        <v-col cols="4">

        </v-col>
        <v-col cols="4">
          <v-row justify="end" align="end">
            <v-card rised width="150">
              <v-img :src="liveMatch.dire.logo"
                aspect-ratio="1"
                  max-width="150"></v-img>
            </v-card>
            <!-- <span>{{liveMatch.dire.name}}</span> -->
          </v-row>
          
        </v-col>
      </v-row>  
      <v-row>
        <v-col cols="4">
          <v-card class="pa-2" tile max-height="150" >
              <span class="subtitle-1">Bans</span>
              <v-row>
                <v-col cols="2" :key="ban.id" v-for="ban in liveMatch.radiant.bans">
                  <v-card outlined tile>
                    <v-img :src="ban.logo"></v-img>
                  </v-card>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
        <v-col cols="4">
         
        </v-col>
        <v-col cols="4">
           <v-card class="pa-2" tile max-height="150">
             <span class="subtitle-1">Bans</span>
              <v-row>
                <v-col cols="2" :key="ban.id" v-for="ban in liveMatch.dire.bans">
                  <v-card outlined tile>
                    <v-img :src="ban.logo"></v-img>
                  </v-card>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
      </v-row>
       <v-row>
        <v-col cols="4">
          <v-card class="pa-2" tile max-height="150" >
              <span class="subtitle-1">Picks</span>
              <v-row>
                <v-col cols="2" :key="pick.id" v-for="pick in liveMatch.radiant.picks">
                  <v-card outlined tile>
                    <v-img :src="pick.logo"></v-img>
                  </v-card>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
        <v-col cols="4">
          
        </v-col>
        <v-col cols="4">
           <v-card class="pa-2" tile max-height="150">
             <span class="subtitle-1">Pick</span>
              <v-row>
                <v-col cols="2" :key="pick.id" v-for="pick in liveMatch.dire.picks">
                  <v-card outlined tile>
                    <v-img :src="pick.logo"></v-img>
                  </v-card>
              </v-col>
            </v-row>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
import {  mapGetters } from "vuex";
import helpers from "@/lib/helpers";

export default {
  components: {},
  data() {
    return {};
  },
  async created() {
    await this.$store.dispatch("matches/getLiveMatchStats", {
      serverSteamId: this.serverSteamId
    });
  },
  computed: {
    serverSteamId() {
      return this.$route.params.serverSteamId;
    },
    ...mapGetters({
      getLiveMatch: 'matches/getLiveMatchStats'
    }),
    liveMatch() {
      return this.getLiveMatch(this.serverSteamId);
    },
    graphData() {
      if (this.liveMatch == null) {
        return null;
      }

      return {
        chartOptions: {
          chart: {
            type: "area",
            stacked: false
          },
          fill: {
            colors: ["#EEE8AA"]
          },
          zoom: {
            enabled: false
          },
          stroke: {
            colors: ["#FFD700"]
          },
          annotations: {
            yaxis: [
              {
                y: 0,
                strokeDashArray: 0,
                borderColor: "#000000"
              }
            ]
          },
          xaxis: {
            labels: {
              show: false
            },
            axisTicks: {
              show: false
            }
          },
          tooltip: {
            enabled: false
          }
        },
        series: [
          {
            data: this.liveMatch.goldGraph
          }
        ]
      };
    }
  },
  methods: {
    trancate(value) {
      return helpers.truncateString(value, 16);
    },
    getNetworthWidth(player, players) {
      var networths = players.map(p => new Number(p.netWorth));
      var maxNetworth =  Math.max.apply(Math, networths);

      var maxWidth = 100;
      if(maxNetworth < 6000) {
        maxWidth = 55;
      }
      if(maxNetworth < 10000) {
        maxWidth = 65;
      } else if(maxNetworth < 20000) {
         maxWidth = 75;
      } else if(maxNetworth < 30000) {
         maxWidth = 85;
      }

      var pc = player.netWorth / maxNetworth;
      var width = maxWidth * pc;
      return width + '%';
    }
  }
};
</script>
