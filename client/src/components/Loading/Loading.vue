<template>
  <v-container v-if="loading" class="loading-container">
    <v-progress-circular :size="300" :width="7" indeterminate color="accent"></v-progress-circular>
  </v-container>
</template>

<script>
export default {
  name: 'Loading',
  props: ['loading']
};
</script>

<style scoped>
.loading-container {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>