<template>
  <v-navigation-drawer v-model="sideDrawer" app clipped>
    <v-list dense>
      <v-list-item link>
        <v-list-item-action>
          <v-icon>mdi-view-dashboard</v-icon>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>Movies</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-list-item link>
        <v-list-item-action>
          <v-icon>mdi-settings</v-icon>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>Settings</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
export default {
  name: "Navbar",
  props: ["drawer"],
  computed: {
    sideDrawer() {
      console.log('dd', this.drawer)
      return this.drawer;
    }
  },
  created() {
    console.log("this", this);
  }
};
</script>