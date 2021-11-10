<template>
  <v-app>
    <v-app-bar app dark color="light-blue darken-4 ">
      <img
        alt="popcorn"
        width="38"
        src="./assets/clapperboard-white.png"
        style="margin-right: 20px"
      />
      <v-toolbar-title>CineManager</v-toolbar-title>
      <v-spacer></v-spacer>
      <div v-if="isLogged">
        <v-btn text rounded>Logout</v-btn>
      </div>
    </v-app-bar>
    <v-content>
      <login :isLogged="isLogged" />
    </v-content>
  </v-app>
</template>

<script>
import Login from "./components/Login.vue";
export default {
  name: "App",
  components: {
    Login,
  },
  data: () => ({
    isLogged: false,
  }),
};
</script>
