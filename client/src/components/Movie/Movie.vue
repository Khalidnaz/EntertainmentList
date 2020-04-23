<template>
  <v-card raised class="card">
    <v-card-title>{{ movie.title }}</v-card-title>
    <v-img class="white--text align-end" height="200px" v-bind:src="photoUrl" />

    <v-row class="details">
      <v-col cols="5">
        <label>Release Date:</label>
        <p>{{ new Date(movie.release_date).toDateString() }}</p>
      </v-col>
      <v-col cols="3">
        <label>Rating:</label>
        <p>{{ movie.vote_average }}</p>
      </v-col>
      <v-col cols="3">
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn dark v-on="on">
              <v-icon>mdi-plus-circle-outline</v-icon>
            </v-btn>
          </template>
          <span>Add to watchlist</span>
        </v-tooltip>
      </v-col>
    </v-row>

		<Genres v-bind:movieGenres='movieGenres' />

    <v-card-text class="text--primary">
      <div>{{ movie.overview }}</div>
    </v-card-text>
  </v-card>
</template>

<script>
import Genres from './Genres';
import { mapGetters } from 'vuex';

export default {
	name: 'Movie',
	components: {
		Genres
	},
  props: ['movie'],
  computed: {
    ...mapGetters(['genres']),
    photoUrl() {
      const baseUrl = 'http://image.tmdb.org/t/p/w185/';
      return `${baseUrl}${this.movie.poster_path}`;
    },
    movieGenres() {
      return this.movie.genre_ids.map((id) => this.genres[id]);
    },
  },
};
</script>

<style scoped>
.card {
  min-height: 300px;
  max-height: 450px;
  height: 100%;
  overflow-x: hidden;
}

.details {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

</style>
