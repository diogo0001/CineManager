<template>
  <v-app-bar app dark color="light-blue darken-4 ">
    <img
      alt="popcorn"
      width="38"
      src="../assets/clapperboard-white.png"
      style="margin-right: 20px"
    />
    <v-toolbar-title>CineManager</v-toolbar-title>
    <v-spacer></v-spacer>
    <div >
      <v-btn text rounded>Sair</v-btn>
    </div>
  </v-app-bar>
</template>


<script>
export default {
  name: "NavBar",
  components: {

},
  data(){
    return {
    //   appTitle: 'CineManager',
    //   sidebar: false,
    //   menuItems: [
    //       { title: 'Home', path: '/home', icon: 'home' },
    //       { title: 'Sign Up', path: '/signup', icon: 'face' },
    //       { title: 'Sign In', path: '/signin', icon: 'lock_open' }
    //  ]
    }
  },
};
</script>

<style lang="css" scoped>

</style>
