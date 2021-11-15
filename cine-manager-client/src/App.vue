<template>
  <v-app class="app">
    <nav-bar />
    <router-view />
  </v-app>
</template>

<script>
import NavBar from "./components/NavBar.vue";

export default {
  name: "App",
  components: {
    NavBar,
  },

  data: () => ({
    //
  }),
};
</script>

<style lang="css">
body {
  /* margin-top: 64px; */
}
/* fazer margin-top=52 se a tela for menor que 945 */ 

.app {
  display: flex;
  justify-content: space-between;
  /* background: rgb(196, 196, 196); */
}

#app {
  /* background: rgb(196, 196, 196); */
}

a{
  text-decoration: none;
  color: white;
}

</style>
