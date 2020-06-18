<template>
  <router-link
    class="match"
    :to="{ name: 'LiveMatch', params: { serverSteamId: model.serverSteamId }}"
  >
    <LiveTeam :model="model.radiant" />

    <div class="score-container">
      <h5>{{ model.league.name }}</h5>
      <div class="score">
        <span>{{ model.radiant.score }}</span>
        <span>{{ model.dire.score }} </span>
      </div>
      <div class="lead">
        <div>
          <span v-if="model.radiant.lead > 0">{{ model.radiant.lead }}</span>
        </div>
        <div>
          <span v-if="model.dire.lead > 0">
            {{ model.dire.lead }}
          </span>
        </div>
      </div>
    </div>

    <LiveTeam :model="model.dire" />
  </router-link>
</template>

<script>
import LiveTeam from './LiveTeam.vue'

export default {
  components: {
    LiveTeam
  },
  props: {
    model: {
      type: Object,
      required: true
    }
  }
}
</script>
