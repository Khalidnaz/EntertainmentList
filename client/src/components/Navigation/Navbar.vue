<template>
  <v-app-bar app clipped-left>
    <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    <v-toolbar-title>Entertainment List</v-toolbar-title>
  </v-app-bar>
</template>

<script>
export default {
  name: "Navbar",
  props: ["toggleSideDrawer"],
  created() {
    console.log("props", this.props);
  }
};
</script>