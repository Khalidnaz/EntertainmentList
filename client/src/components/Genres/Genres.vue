<template>
  <v-container>
    <v-chip
      class="chip"
      v-for="genre in movieGenres"
      v-bind:key="genre"
      color="secondary"
      text-color="white"
    >
      {{ genre }}
    </v-chip>
  </v-container>
</template>

<script>
export default {
  Name: "Genres",
  props: ["movieGenres"],
};
</script>

<style scoped>
.chip {
  margin: 5px;
}
</style>
