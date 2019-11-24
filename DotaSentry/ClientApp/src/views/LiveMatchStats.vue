<template>
  <div class="content">
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
