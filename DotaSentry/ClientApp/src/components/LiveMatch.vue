<template>
  <div
    class="match"
  >
    <router-link
      class="team"
      :to="{ name: 'LiveMatch', params: { serverSteamId: model.serverSteamId }}"
    >
      <LiveTeam :model="model.radiant" />
    </router-link>
    <router-link
      class="team"
      :to="{ name: 'LiveMatch', params: { serverSteamId: model.serverSteamId }}"
    >
      <LiveTeam :model="model.dire" />
    </router-link>
  </div>
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
