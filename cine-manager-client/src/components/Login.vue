<template>
  <v-container :key="align">
    <v-card class="mx-auto mt-12 " max-width="374">
      <!-- <v-card-title>Login</v-card-title> -->
      <v-card-text>
        <v-text-field label="Email" type="email" />
        <v-text-field
          label="Senha"
          :type="showPassord ? 'text' : 'password'"
          @click:append="showPassord = !showPassord"
          :append-icon="showPassord ? 'mdi-eye' : 'mdi-eye-off'"
        />
      <!-- <v-divider></v-divider> -->

        <v-btn class="login-btn" color="indigo" outlined  @click="login">Login</v-btn>

      </v-card-text>
      <!-- <v-card-actions class="login-btn"> -->
        <!-- <v-spacer></v-spacer> -->
        <!-- <v-btn color="indigo  darken-1" text @click="register">Register</v-btn> -->
        <!-- <v-btn color="indigo" outlined @click="login">Login</v-btn> -->
      <!-- </v-card-actions> -->
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: "login",
  props: ["isLogged"],
  data() {
    return {
      showPassord: false,
    };
  },
  methods: {
    register() {
      console.log("Registering...");
    },
    login() {
      console.log("Logging..." + this.isLogged);
      // this.isLogged = true;
    },
  },
};
</script>

<style scoped>
.login {
  /* margin: auto;
  text-align: center; */
  width:380px;
}

.login-btn{
  margin:10px 0;
  width:100%;
}
</style>
