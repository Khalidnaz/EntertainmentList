<template>
  <v-app>
    <SideDrawer
      v-bind:sideNav="sideNav"
      v-bind:sideNavOptions="sideNavOptions"
      v-bind:toggleSideDrawer="toggleSideDrawer"
    />

    <Navbar
      v-bind:user="user"
      v-bind:sideNav="sideNav"
      v-bind:toggleDrawer="toggleSideDrawer"
    />

    <!-- content -->
    <v-content>
      <v-container fluid>
        <transition name="fade">
          <router-view />
        </transition>
      </v-container>
    </v-content>

    <v-footer app>
      <span>&copy; 2020</span>
    </v-footer>
  </v-app>
</template>

<script>
import { mapGetters } from "vuex";
import Navbar from "./components/Navigation/Navbar";
import SideDrawer from "./components/Navigation/SideDrawer";

export default {
  components: {
    Navbar,
    SideDrawer,
  },
  computed: {
    ...mapGetters(["user"]),
    sideNavOptions() {
      return [
        {
          icon: "mdi-view-dashboard",
          title: "Now Playing",
          link: "/movies?section=now_playing",
        },
        {
          icon: "mdi-view-dashboard",
          title: "Top Rated",
          link: "/movies?section=top_rated",
        },
        {
          icon: "mdi-view-dashboard",
          title: "Upcoming",
          link: "/movies?section=upcoming",
        },
        {
          icon: "mdi-view-dashboard",
          title: "On The Air",
          link: "/tv?section=on_the_air",
        },
        {
          icon: "mdi-view-dashboard",
          title: "My Watch List",
          link: "/watchlist",
        },
      ];
    },
  },
  created() {
    this.$vuetify.theme.dark = true;
  },
  data: () => ({
    sideNav: false,
  }),
  methods: {
    toggleSideDrawer() {
      this.sideNav = !this.sideNav;
    },
  },
};
</script>
