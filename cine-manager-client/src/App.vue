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
.app{
  display: flex;
  justify-content: space-between;
  background: rgba(109, 108, 99, 0.144);
}



</style>