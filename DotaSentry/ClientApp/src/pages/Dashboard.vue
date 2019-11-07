<template>
  <div class="content">
    <md-card>
      <md-card-header :data-background-color="'green'">
        <h4 class="title">Live matches</h4>
      </md-card-header>

      <md-card-content>
        <div v-if="liveMatches.length > 0" class="md-layout">
          <div class="live-match" v-bind:key="match.matchId" v-for="match in liveMatches">
          <!-- <router-link :to="{ name: 'LiveMatch', params: { id: '15' }}">
                                Go to match
          </router-link> -->
          <div class="team">
           
            <picture>
                <img v-bind:src="match.radiant.logo" />
              </picture>
             <h4>{{match.radiant.name}}</h4>
          </div>

          <div class="score">
            <h2>{{match.radiant.score}}</h2>
            <h2>{{match.dire.score}}</h2>
            <h4 v-if="match.radiant.lead > 0" class="radiang-leads">
              {{match.radiant.lead}}
            </h4>
             <h4 v-if="match.dire.lead > 0" class="dire-leads">
              {{match.dire.lead}}
            </h4>
          </div>

          <div class="team">
            <picture>
                <img v-bind:src="match.dire.logo" />
            </picture>
            <h4>{{match.dire.name}}</h4>
          </div>
        </div>
        </div>
      </md-card-content>
    </md-card>
    

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
