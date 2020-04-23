<template>
  <v-container fluid>
    <Loading v-bind:loading="movieLoading" />
    <!-- replace this with my watch list -->
    <!-- <v-container v-if="!movieLoading">
      <h1>Now Playing in Theaters</h1>
      <v-row>
        <v-col cols="3" v-for="now in nowPlaying" v-bind:key="now.id">
          <Movie v-bind:movie="now" />
        </v-col>
      </v-row>
    </v-container> -->
  </v-container>
</template>

<script>
import Loading from "../Loading/Loading";
// import Movie from "../Movie/Movie.vue";
import { mapGetters } from "vuex";
export default {
  name: "Home",
  components: {
    //Movie,
    Loading
  },
  computed: {
    ...mapGetters(["user", "genres"])
  },
  created() {
    if (!this.user) {
      this.$router.push("/login");
    }

    // this.$store.dispatch("getGenres");
  }
};
</script>

<style scoped>
.loading-container {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
</style>
