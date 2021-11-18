<template>
  <div class="container">
    <div class="bg"></div>
    <v-card class="mx-auto login" :elevation="2">
      <v-card-text>
        <v-text-field label="Email" type="email" v-model="userName" />
        <v-text-field
          v-model.trim="password"
          label="Senha"
          :type="showPassord ? 'text' : 'password'"
          @click:append="showPassord = !showPassord"
          :append-icon="showPassord ? 'mdi-eye' : 'mdi-eye-off'"
        />
        <v-btn class="login-btn" color="indigo" outlined @click="login()">
          Login
        </v-btn>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
import { required } from "vuelidate/lib/validators";

export default {
  name: "login",
  props: ["isLogged"],
  data() {
    return {
      userName: "",
      password: "",
      showPassord: false,
    };
  },
  validations: {
    username: { required },
    password: { required },
  },
  methods: {
    login() {
      // console.log("Logging..." + this.isLogged);
      // this.isLogged = true;
    },
  },
};
</script>

<style scoped>
.container {
  height: 100%;
  width: 100%;
  z-index: 5;
  /* background: rgb(101, 195, 224); */
}

.login {
  max-width: 374px;
  position: relative;
  top: 25%;
}

.login-btn {
  margin: 10px 0;
  width: 100%;
}
</style>
