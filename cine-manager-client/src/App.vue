<template>
  <v-app>
    <router-view />
    <nav-bar />
  </v-app>
</template>

<script>
import NavBar from './components/NavBar.vue'

export default {
  name: 'App',

  components: {
    NavBar,
  },

  data: () => ({
    //
  }),
};
</script>

<style lang="css">

body{
  margin-top:64px;
}

</style>