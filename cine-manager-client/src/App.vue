<template>
  <v-app class="app">
    <div class="bg"></div>
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
};
</script>

<style lang="css">
.bg {
  position: absolute;
  top: 64px;
  bottom: 0;
  left: 0;
  right: 0;
  background-image: url("./assets/movies-bg.jpg");
  background-size: cover;
  opacity: 0.4;
  z-index: -1;
}

.app {
  display: flex;
  justify-content: space-between;
}
</style>
