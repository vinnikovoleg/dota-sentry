<template>
  <div class="content">
    <div class="md-layout">
      {{id}}
    </div>
    dsafsdfasdf
  </div>
</template>

<script>

import { mapState } from 'vuex';

export default {
  components: {  },
  data() {
    return {
      
    };
  },
  async created() {
  
  },
  computed: {
      id() {
          return this.$route.params.id;
      }
  }
};
</script>
