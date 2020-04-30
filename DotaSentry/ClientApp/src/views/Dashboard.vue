<template>
  <div class="dashboard">
    <div v-if="liveMatches != null && liveMatches.length > 0"> 
      <div v-bind:key="match.matchId"
             v-for="match in liveMatches">
        <!--  :to="{ name: 'LiveMatch', params: {serverSteamId: match.serverSteamId}}" -->
        <div>
          {{match.radiant.name}}
        </div>
      </div>
    </div>
  </div>
</template>

<script>

//import store from "@/store/index"; 
import { mapState } from "vuex";

export default {
  components: {},
  data() {
    return {};
  },
  created() {
    this.$store.dispatch('matches/getLiveMatches');
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
