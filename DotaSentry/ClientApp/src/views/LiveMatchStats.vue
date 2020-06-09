<template>
  <div class="live-match">
    <div class="team">
      <h2>{{ liveMatch.radiant.name }}</h2>
      <div class="picks">
        <div
          v-for="pick in liveMatch.radiant.picks"
          :key="pick.id"
          class="pick"
        >
          <img :src="pick.logo">
        </div>
      </div>
      <div class="bans">
        <div
          v-for="ban in liveMatch.radiant.bans"
          :key="ban.id"
          class="ban"
        >
          <img
            :src="ban.logo"
            alt=""
          >
        </div>
      </div>
      <div class="players">
        <div
          v-for="player in liveMatch.radiant.players"
          :key="player.id"
          class="player"
        >
          <img
            :src="player.hero.logo"
            alt=""
          >
          <div>name: {{ player.name }}</div>
          <div>level: {{ player.level }}</div>
          <div>kills: {{ player.kills }}</div>
          <div>deaths: {{ player.deaths }}</div>
          <div>assists: {{ player.assists }}</div>
          <div>lastHits: {{ player.lastHits }}</div>
          <div>denies: {{ player.denies }}</div>
          <div>netWorth: {{ player.netWorth }}</div>
          <div>lastHits: {{ player.lastHits }}</div>
          <div class="items">
            <div
              v-for="item in player.items"
              :key="item.id"
              class="item"
            >
              <img
                :src="item.logo"
                alt=""
              >
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="team">
      <h2>{{ liveMatch.dire.name }}</h2>
      <div class="picks">
        <div
          v-for="pick in liveMatch.dire.picks"
          :key="pick.id"
          class="pick"
        >
          <img
            :src="pick.logo"
            alt=""
          >
        </div>
      </div>
      <div class="bans">
        <div
          v-for="ban in liveMatch.dire.bans"
          :key="ban.id"
          class="ban"
        >
          <img :src="ban.logo">
        </div>
      </div>
      <div class="players">
        <div
          v-for="player in liveMatch.dire.players"
          :key="player.id"
          class="player"
        >
          <img :src="player.hero.logo">
          <div>name: {{ player.name }}</div>
          <div>level: {{ player.level }}</div>
          <div>kills: {{ player.kills }}</div>
          <div>deaths: {{ player.deaths }}</div>
          <div>assists: {{ player.assists }}</div>
          <div>lastHits: {{ player.lastHits }}</div>
          <div>denies: {{ player.denies }}</div>
          <div>netWorth: {{ player.netWorth }}</div>
          <div>lastHits: {{ player.lastHits }}</div>
          <div class="items">
            <div
              v-for="item in player.items"
              :key="item.id"
              class="item"
            >
              <img :src="item.logo">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
import helpers from '@/lib/helpers'

export default {
  components: {},
  data() {
    return {}
  },
  async created() {
    await this.$store.dispatch('matches/getLiveMatchStats', {
      serverSteamId: this.serverSteamId
    })
  },
  // eslint-disable-next-line vue/order-in-components
  computed: {
    serverSteamId() {
      return this.$route.params.serverSteamId
    },
    ...mapGetters({
      getLiveMatch: 'matches/getLiveMatchStats'
    }),
    liveMatch() {
      return this.getLiveMatch(this.serverSteamId)
    },
    graphData() {
      if (this.liveMatch == null) {
        return null
      }

      return {
        chartOptions: {
          chart: {
            type: 'area',
            stacked: false
          },
          fill: {
            colors: ['#EEE8AA']
          },
          zoom: {
            enabled: false
          },
          stroke: {
            colors: ['#FFD700']
          },
          annotations: {
            yaxis: [
              {
                y: 0,
                strokeDashArray: 0,
                borderColor: '#000000'
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
      }
    }
  },
  methods: {
    trancate(value) {
      return helpers.truncateString(value, 16)
    },
    getNetworthWidth(player, players) {
      // eslint-disable-next-line no-new-wrappers
      const networths = players.map((p) => new Number(p.netWorth))
      // eslint-disable-next-line prefer-spread
      const maxNetworth = Math.max.apply(Math, networths)

      let maxWidth = 100
      if (maxNetworth < 6000) {
        maxWidth = 55
      }
      if (maxNetworth < 10000) {
        maxWidth = 65
      } else if (maxNetworth < 20000) {
        maxWidth = 75
      } else if (maxNetworth < 30000) {
        maxWidth = 85
      }

      const pc = player.netWorth / maxNetworth
      const width = maxWidth * pc
      return `${width}%`
    }
  }
}
</script>
