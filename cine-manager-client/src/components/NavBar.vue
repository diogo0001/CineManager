<template>
  <v-app id="inspire">
    <v-app-bar app dark color="rgb(19, 95, 124)">
      <img
        alt="popcorn"
        width="38"
        src="../assets/popcorn-white.png"
        style="margin-right: 20px"
      />
      <v-toolbar-title>CineManager</v-toolbar-title>
      <v-spacer></v-spacer>
      <div>
        <v-btn text rounded>Sair</v-btn>
      </div>
    </v-app-bar> 
  </v-app>
</template>

<script>

export default {
  name: "NavBar",
  components: {},
  data() {
    return {
  
    };
  },
};
</script>

<style lang="css" scoped>
</style>
