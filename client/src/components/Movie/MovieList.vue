<template>
  <v-container fluid>
    <Loading v-bind:loading="movieLoading" />
    <v-container v-if="!movieLoading" fluid>
      <h1>{{ header }}</h1>
      <v-row>
        <v-col sm="12" md="3" lg="3" v-for="movie in movies" v-bind:key="movie.id">
          <Movie v-bind:movie="movie" />
        </v-col>
      </v-row>
    </v-container>
  </v-container>
</template>

<script>
import { mapGetters } from "vuex";
import Loading from "../Loading/Loading";
import Movie from "./Movie";
export default {
  name: "MovieList",
  components: {
    Loading,
    Movie
  },
  computed: {
    ...mapGetters(["movieLoading", "user", "movies", "genres"]),
    header() {
      return this.$route.query.section === "top_rated"
        ? "Top Rated Movies"
        : this.$route.query.section === "now_playing"
        ? "Now Playing in Theaters"
        : "Upcoming Movies";
    }
  },
  created() {
    if (!this.user) {
      this.$router.push('/logic')
    }

    const param = this.$route.query.section;
    this.$store.dispatch("getGenres");
    this.$store.dispatch("fetchMovies", param);
  }
};
</script>