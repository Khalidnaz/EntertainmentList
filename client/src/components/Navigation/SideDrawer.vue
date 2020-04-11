<template>
  <v-navigation-drawer app clipped v-model="openSideNav">
    <v-list dense>
      <v-list-item
        link
        v-for="option in sideNavOptions"
        v-bind:key="option.title"
        v-bind:to="option.link"
      >
        <v-list-item-action>
          <v-icon>{{ option.icon }}</v-icon>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>{{ option.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
export default {
  name: 'Navbar',
  props: ['sideNav', 'sideNavOptions', 'toggleSideDrawer'],
  computed: {
    openSideNav: {
      get() {
        return this.sideNav;
      },
      set(val) {
        this.$emit('sideNav', val);
      }
    }
  }
};
</script>
