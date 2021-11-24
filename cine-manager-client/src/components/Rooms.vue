<template>
  <div class="app">
    <side-bar />
    <v-container id="app">
      <v-app id="app">
        <span class="title">{{ title }}</span>
        <v-data-table
          dense
          :headers="headers"
          :items="items"
          :search="search"
          class="elevation-2"
          @click:row="handleClick"
        >
          <template v-slot:top>
            <v-toolbar flat>
              <v-text-field
                dense
                outlined
                v-model="search"
                label="Buscar"
                append-icon="mdi-manage_search"
                single-line
                hide-details
                class="mr-4 search"
              ></v-text-field>
            </v-toolbar>
          </template>
          <template v-slot:no-data>
            <v-progress-circular
              indeterminate
              color="primary"
              v-if="isLoading"
              class="loading"
            ></v-progress-circular>
            <v-btn v-else class="my-2" color="error" @click="loadData">
              Recarregar
            </v-btn>
          </template>
        </v-data-table>
        <template>
          <v-row justify="center">
            <v-dialog
              v-model="dialog"
              fullscreen
              hide-overlay
              transition="dialog-bottom-transition"
            >
              <v-card class="room">
                <v-toolbar dark color="rgb(19, 95, 124)">                                   
                  <v-icon class="mr-4">mdi-google-classroom</v-icon>
                  <v-toolbar-title>{{ selectedRow }}</v-toolbar-title>
                  <v-spacer></v-spacer>
                  <v-btn icon dark @click="dialog = false">
                    <v-icon>mdi-close</v-icon>
                  </v-btn>
                </v-toolbar>
                <img src="../assets/seats.png" alt="sala" />
              </v-card>
            </v-dialog>
          </v-row>
        </template>
      </v-app>
    </v-container>
  </div>
</template>

<script>
import { getRooms } from "../services/api";
import SideBar from "./SideBar.vue";

export default {
  name: "Rooms",
  components: {
    SideBar,
  },
  props: {},
  data: () => ({
    headers: [],
    items: [],
    title: "Salas",
    search: "",
    dialog: false,
    selectedRow: "",
    isLoading: false,
  }),

  created() {
    this.loadData();
  },
  beforeUpdate() {},
  methods: {
    loadData() {
      let items = [];
      this.isLoading = true;
      getRooms()
        .then((res) => {
          const data = res.data;
          data.map((item) => {
            let obj = {
              name: item.name,
              seatsNumber: item.seatsNumber,
            };
            items.push(obj);
          });
          this.items = items;
          this.isLoading = false;
        })
        .catch((err) => {
          console.log(err);
          this.$notify({
              text: 'Falha ao carregar a lista de salas! '+err,
              type:'error'
            });
        });

      this.headers = [
        {
          text: "Sala",
          align: "start",
          value: "name",
        },
        {
          text: "Número de Assentos",
          align: "start",
          value: "seatsNumber",
        },
      ];
    },
    handleClick(e) {
      this.selectedRow = e.name;
      this.dialog = true;
    },
  },
};
</script>

<style scoped>
.search {
  max-width: 340px;
}
.title {
  margin-top: -10px;
  padding: 16px 0 16px 18px;
  width: 100%;
}

.room > img {
  margin: 2% 0 0 25%;
  align-content: center;
}
</style>
