<template>
  <v-app id="inspire">
    <SideDrawer v-bind:drawer='drawer' />
    <Navbar v-bind:toggleDrawer='toggleSideDrawer'/>

    <v-content>
      <v-container
        class="fill-height"
        fluid
      >
       
      </v-container>
    </v-content>

    <v-footer app>
      <span>&copy; 2020</span>
    </v-footer>
  </v-app>
</template>

<script>
  import Navbar from './components/Navigation/Navbar';
  import SideDrawer from './components/Navigation/SideDrawer';
  
  export default {
    components: {
      Navbar,
      SideDrawer
    },
    props: {
      source: String,
    },
    data: () => ({
      drawer: null,
    }),
    created () {
      this.$vuetify.theme.dark = true
    },
    methods: {
      toggleSideDrawer() {
        this.drawer = !this.drawer;
      }
    }
  }
</script>