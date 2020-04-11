<template>
  <v-app-bar app clipped-left>
    <v-app-bar-nav-icon @click="toggleDrawer" v-bind:disabled="!user" />
    <v-toolbar-title>Entertainment List</v-toolbar-title>
    <v-spacer></v-spacer>

    <v-btn text v-if="!user" to="/login">
      <v-icon class="hidden-sm-only" left>mdi-login</v-icon>Sign In
    </v-btn>

    <!-- make a profile option -->
    <v-btn text v-if="user" @click="handleSignout">
      <v-icon class="hidden-sm-only" left>mdi-logout</v-icon>Sign out
    </v-btn>
  </v-app-bar>
</template>

<script>
export default {
  name: 'Navbar',
  props: ['user', 'toggleDrawer'],
  methods: {
    handleSignout() {}
  }
};
</script>
