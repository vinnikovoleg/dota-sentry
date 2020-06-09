<template>
  <div class="team">
    <span class="name">{{ model.name }}</span>
    <img
      :src="model.logo"
      :alt="model.name"
    >
  </div>
</template>

<script>
export default {
  props: {
    model: {
      type: Object,
      required: true
    }
  }
}
</script>
