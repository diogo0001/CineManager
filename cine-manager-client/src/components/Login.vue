<template>
  <div class="container">
    <div class="bg"></div>
    <v-card class="mx-auto login" :elevation="2">
      <v-card-text>
        <v-text-field label="Email" type="email" v-model="userEmail" required />
        <v-text-field
          required
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
import { login } from "../services/api";

export default {
  name: "login",
  props: ["logged"],
  data() {
    return {
      userEmail: "",
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
      // Fazer validação e tudo mais pra um login correto!!
      const user = {
        userEmail: this.userEmail,
        password: this.password,
      };
      console.log(this.$logged)

      login(user)
        .then((res) => {
          console.log(res.data);
          this.isLogged = true;
          this.$logged = true;  
          this.$router.push({name:'sessions'})
        })
        .catch((err) => {
          console.log(err);
          this.$logged = false;
        });
    },
  },
};
</script>

<style scoped>
.container {
  height: 100%;
  width: 100%;
  z-index: 5;
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
