<template>
  <div>
    <div class="header">
      <img
        src="@/assets/images/dota-2-icon-28.jpg"
        alt="Dota Sentry"
        width="40"
      >
    </div>
    <div class="content">
      <router-view />
    </div>
  </div>
</template>

<script>


export default {
  name: 'App',

  components: {
  },

  data: () => ({
    //
  }),
  created() {
  }
}
</script>
