<template>
  <v-container fluid>
    <Loading v-bind:loading="tvLoading" />
    <v-container v-if="!tvLoading" fluid>
      <h1>{{ header }}</h1>
      <v-row>
        <v-col sm="12" md="3" lg="3" v-for="tv in tv" v-bind:key="tv.id">
          <tv v-bind:tv="tv" />
        </v-col>
      </v-row>
    </v-container>
  </v-container>
</template>

//
<script>
import { mapGetters } from "vuex";
import Loading from "../Loading/Loading";
import Tv from "./Tv";
export default {
  name: "TvList",
  components: {
    Loading,
    Tv,
  },
  computed: {
    ...mapGetters(["tvLoading", "user", "tv", "tvGenres"]),
    header() {
      return this.$route.query.section === "top_rated"
        ? "Top Rated Tv"
        : this.$route.query.section === "airing_today"
        ? "Tv Airing Today"
        : "Airing Tv Shows";
    },
  },
  created() {
    if (!this.user) {
      this.$router.push("/logic");
    }

    const param = this.$route.query.section;
    this.$store.dispatch("getGenres");
    this.$store.dispatch("fetchTv", param);
  },
};
</script>
