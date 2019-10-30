<template>
  <div class="content">
    <div class="md-layout">
       <div v-bind:key="match.matchId" v-for="match in liveMatches">
         <span>{{match.radiant.name}}</span>
           </br>
         <span>{{match.dire.name}}</span>
           </br>
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
