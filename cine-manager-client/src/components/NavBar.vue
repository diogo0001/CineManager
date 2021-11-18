<template>
  <nav>
    <v-toolbar dark color="rgb(6, 63, 85)">
      <img
        alt="popcorn"
        width="34"
        src="../assets/popcorn-white.png"
        style="margin-right: 20px"
      />
      <v-toolbar-title>CineManager</v-toolbar-title>
      <v-spacer></v-spacer>
      <div>
        <v-btn v-if="isLogged" text rounded>Sair</v-btn>
      </div>
    </v-toolbar>
  </nav>
</template>

<script>
export default {
  name: "NavBar",
  data() {
    return {
      isLogged: false,
    };
  },
};
</script>

<style lang="css" scoped></style>
