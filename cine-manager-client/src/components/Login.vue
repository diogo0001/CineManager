<template>
  <div class="container">
    <v-card class="mx-auto login"  :elevation="2">
      <v-card-text>
        <v-text-field label="Email" type="email" />
        <v-text-field
          label="Senha"
          :type="showPassord ? 'text' : 'password'"
          @click:append="showPassord = !showPassord"
          :append-icon="showPassord ? 'mdi-eye' : 'mdi-eye-off'"
        />
        <v-btn class="login-btn" color="indigo" outlined @click="login()"
          >Login</v-btn
        >
      </v-card-text>
    </v-card>
  </div>
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
  background: rgba(101, 196, 224, 0.116);
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
