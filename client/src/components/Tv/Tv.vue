<template>
  <v-card raised class="card">
    <v-card-title>{{ tv.name }}</v-card-title>
    <v-img class="white--text align-end" height="200px" v-bind:src="photoUrl" />

    <v-row class="details">
      <v-col cols="5">
        <label>Original Release Date:</label>
        <p>{{ new Date(tv.first_air_date).toDateString() }}</p>
      </v-col>
      <v-col cols="3">
        <label>Rating:</label>
        <p>{{ tv.vote_average }}</p>
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

    <tvGenres v-bind:tvgenres="tvgenres" />

    <v-card-text class="text--primary">
      <div>{{ tv.overview }}</div>
    </v-card-text>
  </v-card>
</template>

<script>
import TvGenres from "./TvGenres";
import { mapGetters } from "vuex";

export default {
  name: "Tv",
  components: {
    TvGenres,
  },
  props: ["tv"],
  computed: {
    ...mapGetters(["tvgenres"]),
    photoUrl() {
      const baseUrl = "http://image.tmdb.org/t/p/w185/";
      return `${baseUrl}${this.tv.poster_path}`;
    },
    tvGenres() {
      return this.tv.genre_ids.map((id) => this.genres[id]);
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
