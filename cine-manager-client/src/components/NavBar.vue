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
        <v-btn v-if="isLogged" text rounded @click="logout">Sair</v-btn>
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
  watch: {
    $logged() {
      this.isLogged = this.$logged;
    },
  },
  methods:{
    logout(){
      this.$logged = false;
      this.isLogged = false;
      this.$router.push({path:'/'})
    }
  }
};
</script>

<style lang="css" scoped>
</style>
