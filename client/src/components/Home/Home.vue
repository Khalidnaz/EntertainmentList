<template>
  <v-container v-if="movieLoading" class="loading-container">
    <v-progress-circular
      :size="300"
      :width="7"
      indeterminate
      color="accent"
    ></v-progress-circular>
  </v-container>
  <v-container v-else>
    <h1>Now Playing in Theaters</h1>
    <v-row>
      <v-col cols="3" v-for="now in nowPlaying" v-bind:key="now.id">
        <Movie v-bind:movie="now" />
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Movie from '../Movie/Movie.vue';
import { mapGetters } from 'vuex';
export default {
  name: 'Home',
  components: {
    Movie,
  },
  computed: {
    ...mapGetters(['user', 'nowPlaying', 'movieLoading', 'topRated', 'genres']),
  },
  created() {
    if (!this.user) {
      this.$router.push('/login');
    }
    this.$store.dispatch('getGenres');
    this.$store.dispatch('fetchNowPlaying');
  },
};
</script>

<style scoped>
.loading-container {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>
