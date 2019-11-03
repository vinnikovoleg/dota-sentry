<template>
  <div class="content">
    <div class="md-layout">
      <div v-if="liveMatches.length > 0">
       <div class="live-match" v-bind:key="match.matchId" v-for="match in liveMatches">
          <!-- <router-link :to="{ name: 'LiveMatch', params: { id: '15' }}">
                                Go to match
          </router-link> -->
          <span>{{match.radiant.name}}</span>
           <picture>
              <img v-bind:src="match.radiant.logo" />
            </picture>
          </br>
          <span>{{match.dire.name}}</span>
          <picture>
              <img v-bind:src="match.dire.logo" />
            </picture>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {
  StatsCard,
  ChartCard,
  NavTabsCard,
  NavTabsTable,
  OrderedTable
} from "@/components";

import { mapState } from 'vuex';

export default {
  components: {  },
  data() {
    return {
      
    };
  },
  async created() {
    await this.$store.dispatch('matches/getLiveMatches');
  },
  computed: {
    ...mapState({
            liveMatches: state => state.matches.liveMatches
        })
  }
};
</script>
