<template>
  <v-app>
    <v-navigation-drawer
      dark
      v-model="drawer"
      :mini-variant.sync="mini"
      permanent
    >
      <v-list-item class="px-2">
        <v-list-item-avatar>
          <v-icon large>mdi-account-circle</v-icon>
        </v-list-item-avatar>
        <v-list-item-title>Administrador</v-list-item-title>
        <v-btn icon @click.stop="mini = !mini">
          <v-icon>mdi-chevron-left</v-icon>
        </v-btn>
      </v-list-item>
      <v-divider></v-divider>
      <v-list dense class="nav">
        <v-list-item v-for="item in items" :key="item.title" link>
          <v-list-item-icon>
            <router-link :to="{ name: item.path }">
              <v-icon>{{ item.icon }}</v-icon>
            </router-link>
          </v-list-item-icon>
          <v-list-item-content>
            <router-link dark :to="{ name: item.path }">
              <v-list-item-title>
                {{ item.title }}
              </v-list-item-title>
            </router-link>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-app>
</template>

<script>
export default {
  name: "SideBar",
  components: {},
  data() {
    return {
      drawer: true,
      items: [
        { title: "Salas", icon: "mdi-google-classroom", path: "rooms" },
        { title: "Filmes", icon: "mdi-filmstrip", path: "movies" },
        { title: "Sessões", icon: "mdi-movie-open", path: "sessions" },
      ],
      mini: true,
    };
  },
};
</script>

<style lang="css" scoped>
.v-navigation-drawer {
  background: rgb(6, 63, 85);
}

.router-link,
.router-link-active {
  color: rgb(240, 238, 238) !important;
  color: inherit;
}

a {
  text-decoration: none;
}
</style>
