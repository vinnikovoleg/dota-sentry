<template>
  <div class="content">
    <md-card>
      <md-card-header :data-background-color="'green'">
        <div class="live-stats-header" v-if="liveMatch != null">
          <span class="radiant">{{ liveMatch.radiant.name }}</span>
          <span class="score"
            >{{ liveMatch.radiant.score }} vs {{ liveMatch.dire.score }}</span
          >
          <span class="dire">{{ liveMatch.dire.name }}</span>
        </div>
      </md-card-header>

      <md-card-content>
        <div class="md-layout live-stats" v-if="liveMatch != null">
          <div class="radiant">
            <div class="heroes">
              <div
                class="hero-container"  
                v-bind:key="player.id"
                v-for="player in liveMatch.radiant.players">
                    <div
                  class="hero"
                >
                  <span class="hero-title">{{ trancate(player.name, 16) }}</span>
                  <!-- <span class="level">{{ player.level }}</span> -->

                  <picture class="hero-image">
                    <img
                      v-bind:src="player.hero.logo"
                      v-bind:alt="player.hero.name"
                    />
                  </picture>

                  <div class="stats">
                    <span class="label">K/D/A</span>
                    <span class="info"
                      >{{ player.kills }}/{{ player.deaths }}/{{
                        player.assists
                      }}</span
                    >
                    <span class="label">LH/DN</span>
                    <span class="info"
                      >{{ player.lastHits }}/{{ player.denies }}</span
                    >
                  </div>
                  <!-- <div class="items">
                    <div
                      class="item"
                      v-bind:key="index"
                      v-for="(item, index) in player.items"
                    >
                      <picture>
                        <img v-bind:src="item.logo" v-bind:alt="item.name" />
                      </picture>
                    </div>
                  </div> -->
                  <!-- 
                  <span class="networth">{{ player.netWorth }}</span> -->
                </div>

                <div class="networth">
                  <div v-bind:style="{ width: getNetworthWidth(player, liveMatch.radiant.players)}" class="networth-bar"></div>
                  <div class="networth-value">{{ player.netWorth }}</div>
                </div>
              </div>
            
            </div>
            <!-- <h2>Picks</h2>
            <ul>
              <li class="hero" v-bind:key="pick.id" v-for="pick in liveMatch.radiant.picks">
                <h4>{{pick.localizedName}}</h4>
                 <picture>
                    <img v-bind:src="pick.logo" />
                </picture>
              </li>
            </ul>-->
          </div>
          <div class="graph">
            <apexchart
              width="400"
              type="line"
              :options="graphData.chartOptions"
              :series="graphData.series"
            ></apexchart>
          </div>

          <div class="dire">
            <div class="heroes">
              <div
                v-bind:key="player.id"
                v-for="player in liveMatch.dire.players"
                class="hero-container">
                <div class="hero"
                >
                  <!-- <span class="level">{{ player.level }}</span> -->
                  <span class="hero-title">{{ trancate(player.name, 16) }}</span>
                  <div class="stats">
                    <span class="label">K/D/A</span>
                    <span class="info"
                      >{{ player.kills }}/{{ player.deaths }}/{{
                        player.assists
                      }}</span
                    >
                    <span class="label">LH/DN</span>
                    <span class="info"
                      >{{ player.lastHits }}/{{ player.denies }}</span
                    >
                  </div>

                  <picture class="hero-image">
                    <img v-bind:src="player.hero.logo" />
                  </picture>

                </div>

                 <div class="networth">
                  <div v-bind:style="{ width: getNetworthWidth(player, liveMatch.radiant.players)}" class="networth-bar"></div>
                  <div class="networth-value">{{ player.netWorth }}</div>
                </div>
              </div>
         
            </div>
          </div>
        </div>
      </md-card-content>
    </md-card>
  </div>
</template>

<script>
import { mapState } from "vuex";
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
    ...mapState({
      liveMatch: state => state.matches.liveMatchStats
    }),
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
    showItems(player) {
      if (player.displayItems) {
        player.displayItems = false;
      } else {
        player.displayItems = true;
      }
    },
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
