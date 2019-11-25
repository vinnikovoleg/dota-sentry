<template>
  <v-app>
    <v-app-bar
      app
      dark
    >
      <div class="d-flex align-center">
        <router-link :to="{ name: 'Dashobard'}">
          <v-img
            alt="Dota Sentry"
            class="shrink mr-2"
            contain
            src="@/assets/images/dota-2-icon-28.jpg"
            transition="scale-transition"
            width="40"
          />
        </router-link>
      </div>

      <v-spacer></v-spacer>
    </v-app-bar>

    <v-content>
      <router-view></router-view>
    </v-content>
  </v-app>
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
    // this.$vuetify.theme.themes.dark.primary = '#202040'
    // this.$vuetify.theme.themes.dark.secondary = '#202040';
    // this.$vuetify.theme.themes.dark.accent = '#202040';
  }
};
</script>
