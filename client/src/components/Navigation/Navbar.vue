<template>
  <v-app-bar app clipped-left>
    <v-app-bar-nav-icon @click="toggleDrawer" v-bind:disabled="!user" />
    <v-toolbar-title>Entertainment List</v-toolbar-title>
    <v-spacer></v-spacer>

    <v-btn text v-if="!user" to="/login">
      <v-icon class="hidden-sm-only" left>mdi-login</v-icon>Sign In
    </v-btn>

    <v-menu
      v-if="user"
      bottom
      origin="center center"
      transition="scale-transition"
    >
      <template v-slot:activator="{ on }">
        <v-btn text color="white" dark v-on="on"
          >Hello {{ user.firstName }}</v-btn
        >
      </template>

      <v-list>
        <v-list-item
          v-for="(item, i) in userOptions"
          :key="i"
          @click="item.callback"
        >
          <v-list-item-title>
            <v-icon>{{ item.icon }}</v-icon>
            {{ item.text }}
          </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
  </v-app-bar>
</template>

<script>
export default {
  name: 'Navbar',
  props: ['user', 'toggleDrawer'],
  computed: {
    userOptions() {
      if (this.user) {
        return [
          {
            text: 'Settings',
            icon: 'mdi-cog-outline',
            callback: () => this.$router.push('/settings'),
          },
          {
            text: 'Sign Out',
            icon: 'mdi-logout',
            callback: () => this.$store.dispatch('logout'),
          },
        ];
      } else {
        return [];
      }
    },
  },
};
</script>
