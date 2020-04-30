<template>
  <v-container>
    <v-chip
      class="chip"
      v-for="tvgenre in tvGenres"
      v-bind:key="tvgenre"
      color="secondary"
      text-color="white"
    >
      {{ tvgenre }}
    </v-chip>
  </v-container>
</template>

<script>
export default {
  Name: "tvGenres",
  props: ["tvGenres"],
};
</script>

<style scoped>
.chip {
  margin: 5px;
}
</style>
