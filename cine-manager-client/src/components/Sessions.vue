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
              <v-spacer></v-spacer>
              <v-dialog v-model="dialog" max-width="500px">
                <template v-slot:activator="{ on, attrs }">
                  <v-icon class="mr-2" v-bind="attrs" v-on="on">
                    mdi-plus-circle-outline
                  </v-icon>
                </template>
                <v-card>
                  <v-card-title>
                    <span class="text-h5 ml-4 mt-4">{{ titleAddItem }}</span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row dense>
                        <v-col cols="6">
                          <v-select
                            v-model="selectedMovie"
                            :items="movies"
                            item-text="name"
                            item-value="id"
                            label="Filme"
                            return-object
                            outlined
                            dense
                          >
                          </v-select>
                        </v-col>
                        <v-col cols="6">
                          <v-select
                            v-model="selectedRoom"
                            :items="rooms"
                            item-text="name"
                            item-value="id"
                            label="Sala"
                            return-object
                            outlined
                            dense
                          >
                          </v-select>
                        </v-col>
                        <v-col cols="6">
                          <v-select
                            v-model="animation"
                            :items="animations"
                            label="Animação"
                            outlined
                            dense
                          >
                          </v-select>
                        </v-col>
                        <v-col cols="6">
                          <v-select
                            v-model="audio"
                            :items="audios"
                            label="Audio"
                            outlined
                            dense
                          >
                          </v-select>
                        </v-col>
                        <v-col cols="6">
                          <v-menu
                            ref="menu1"
                            v-model="menu1"
                            :close-on-content-click="false"
                            transition="scale-transition"
                            offset-y
                            max-width="290px"
                            min-width="auto"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="dateFormatted"
                                label="Data"
                                placeholder="MM/DD/AAAA"
                                v-bind="attrs"
                                v-on="on"
                                outlined
                                dense
                              ></v-text-field>
                            </template>
                            <v-date-picker
                              v-model="date"
                              @input="menu1 = false"
                            ></v-date-picker>
                          </v-menu>
                        </v-col>
                        <v-col cols="6">
                          <v-menu
                            ref="menu2"
                            v-model="menu2"
                            :close-on-content-click="false"
                            transition="scale-transition"
                            offset-y
                            max-width="290px"
                            min-width="auto"
                          >
                            <template v-slot:activator="{ on, attrs }">
                              <v-text-field
                                v-model="iniTime"
                                label="Início"
                                placeholder="hh:mm"
                                v-bind="attrs"
                                v-on="on"
                                outlined
                                dense
                              ></v-text-field>
                            </template>
                            <v-time-picker
                              v-model="iniTime"
                              class="mt-4"
                              format="24hr"
                              scrollable
                              min="8:00"
                              max="22:00"
                            ></v-time-picker>
                          </v-menu>
                        </v-col>
                        <v-col cols="6">
                          <v-text-field
                            type="text"
                            v-model="ticketPrice"
                            label="Ingresso (R$)"
                            outlined
                            dense
                            required
                          ></v-text-field>
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-text>
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="close">
                      Cancelar
                    </v-btn>
                    <v-btn color="blue darken-1" text @click="save">
                      Salvar
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-dialog>
              <v-dialog v-model="dialogDelete" max-width="510px">
                <v-card>
                  <v-card-title class="text-h6"
                    >Tem certeza que deseja excluir esta Sessão?</v-card-title
                  >
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="closeDelete"
                      >Cancel</v-btn
                    >
                    <v-btn color="blue darken-1" text @click="deleteItemConfirm"
                      >OK</v-btn
                    >
                    <v-spacer></v-spacer>
                  </v-card-actions>
                </v-card>
              </v-dialog>
            </v-toolbar>
          </template>
          <template v-slot:item.actions="{ item }">
            <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
          </template>
          <template v-slot:no-data>
            <v-progress-circular
              indeterminate
              color="primary"
              v-if="isLoading"
              class="loading my-4"
            ></v-progress-circular>
            <v-btn v-else class="my-2" color="error" @click="loadData">
              Recarregar
            </v-btn>
          </template>
        </v-data-table>
      </v-app>
    </v-container>
  </div>
</template>

<script>
import {
  getSessions,
  getMovies,
  getRooms,
  createSession,
  deleteSession,
} from "../services/api";

import SideBar from "./SideBar.vue";

export default {
  name: "Sessions",
  components: {
    SideBar,
  },
  props: {},
  data: () => ({
    headers: [],
    items: [],
    movies: [],
    rooms: [],
    animations: ["2D", "3D"],
    audios: ["Dublado", "Legendado"],
    title: "Sessões",
    titleAddItem: "Adicionar Sessão",
    sessionId: "",
    date: new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
      .toISOString()
      .substr(0, 10),
    dateFormatted: "",
    iniTime: "13:00",
    ticketPrice: "",
    animation: "",
    audio: "",
    selectedMovie: { name: "", id: "" },
    selectedRoom: { name: "", id: "" },
    search: "",
    menu1: false,
    menu2: false,
    dialog: false,
    dialogDelete: false,
    isLoading: true,
    relationshipLoaded: false,
  }),
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
    date() {
      this.dateFormatted = this.formatMenuDate(this.date);
    },
  },
  created() {
    this.loadRelationships();
    (this.dateFormatted = this.formatMenuDate(
      new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10)
    )),
      console.log("Sessions >>> created()");
  },
  beforeUpdate() {
    console.log(`Sessions >>> beforeUpdate()`);
  },
  methods: {
    deleteItem(item) {
      this.sessionId = item.sessionId;
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      console.log("Delete session id " + this.sessionId);

      deleteSession(this.sessionId)
        .then((res) => {
          console.log(res);
          this.$notify({
            text: "Sessão deletada com sucesso!",
            type: "success",
          });
          this.loadData();
        })
        .catch((err) => {
          console.log(err);
          this.$notify({
            text: "Falha ao deletar sessão! " + err.response.data,
            type: "error",
          });
        });
      this.closeDelete();
    },
    close() {
      this.dialog = false;
      this.resetData();
    },
    closeDelete() {
      this.dialogDelete = false;
    },
    save() {
      // TODO: fazer validações

      const iniTime = this.parseSetDateTime(this.date, this.iniTime);
      const endTime = this.parseSetDateTime(
        this.date,
        this.iniTime,
        this.selectedMovie.duration
      );

      const session = {
        iniTime: iniTime,
        endTime: endTime,
        ticketPrice: this.ticketPrice,
        animation: this.animation,
        audio: this.audio,
        movieId: this.selectedMovie.id,
        roomId: this.selectedRoom.id,
      };

      console.log("Create session " + JSON.stringify(session));

      if (iniTime != "-" && (endTime != "-" || endTime != "Invalid Date")) {
        createSession(session)
          .then((res) => {
            console.log(res.data);
            const obj = this.formatData(res.data);
            this.items.push(obj);
            this.$notify({
              text: "Sessão salva com sucesso! ",
              type: "success",
            });
          })
          .catch((err) => {
            console.log(err);
            this.$notify({
              text: "Falha ao salvar sessão! " + err.response.data,
              type: "error",
            });
          })
          .finally(() => {
            this.resetData();
          });
      } else {
        console.log("Data ou horário inválidos");
        this.$notify({
          text: "Data ou horário inválidos ",
          type: "error",
        });
      }
      this.close();
    },
    formatData(item) {
      const obj = {
        sessionId: item.sessionId,
        movie: this.getRelationshipItem(item.movieId, this.movies),
        room: this.getRelationshipItem(item.roomId, this.rooms),
        date: this.parseGetDateTime(item.iniTime, false),
        iniTime: this.parseGetDateTime(item.iniTime),
        endTime: this.parseGetDateTime(item.endTime),
        ticketPrice: item.ticketPrice,
        animation: item.animation,
        audio: item.audio,
      };
      return obj;
    },
    resetData() {
      this.date = new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
        .toISOString()
        .substr(0, 10);
      (this.dateFormatted = this.formatMenuDate(
        new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
          .toISOString()
          .substr(0, 10)
      )),
        (this.iniTime = "13:00");
      this.ticketPrice = "";
      this.animation = "";
      this.audio = "";
      this.selectedMovie = { name: "", id: "" };
      this.selectedRoom = { name: "", id: "" };
    },
    loadData() {
      this.isLoading = true;
      let items = [];

      if (this.relationshipLoaded) {
        getSessions()
          .then((res) => {
            const data = res.data;
            data.map((item) => {
              const obj = this.formatData(item);
              items.push(obj);
            });
            this.items = items;
          })
          .catch((err) => {
            console.log(err);
            this.$notify({
              text: "Falha ao carregar sessões!\n " + err.response.data,
              type: "error",
            });
          })
          .finally(() => {
            this.isLoading = false;
          });
      }

      this.headers = [
        {
          text: "Filme",
          align: "start",
          value: "movie",
          width: "20%",
        },
        {
          text: "Sala",
          align: "start",
          value: "room",
          width: "10%",
        },
        {
          text: "Data",
          align: "start",
          value: "date",
          width: "12%",
        },
        {
          text: "Início",
          align: "start",
          sortable: false,
          value: "iniTime",
          width: "8%",
        },
        {
          text: "Término",
          align: "start",
          sortable: false,
          value: "endTime",
          width: "8%",
        },
        {
          text: "Ingresso (R$)",
          align: "start",
          value: "ticketPrice",
          width: "12%",
        },
        {
          text: "Animação",
          align: "start",
          value: "animation",
          width: "10%",
        },
        {
          text: "Áudio",
          align: "start",
          value: "audio",
          width: "10%",
        },
        {
          text: "Operações",
          value: "actions",
          align: "center",
          sortable: false,
          width: "10%",
        },
      ];
    },

    getRelationshipItem(id, list) {
      let name = "Não Encontrado";
      list.map((item) => {
        if (id == item.id) name = item.name;
      });
      return name;
    },

    loadRelationships() {
      // Carrega as listas das opções para ter as opções dinamicamente ao editar ou criar nova sessão
      let movies = [];
      let rooms = [];
      this.relationshipLoaded = false;
      this.isLoading = true;

      getMovies()
        .then((res) => {
          const data = res.data;
          data.map((item) => {
            let obj = {
              name: item.title,
              id: item.movieId,
              duration: item.duration,
            };
            movies.push(obj);
          });
          this.movies = movies;
        })
        .catch((err) => {
          console.log(err);
        })
        .finally(() => {
          getRooms()
            .then((res) => {
              const data = res.data;
              data.map((item) => {
                let obj = {
                  name: item.name,
                  id: item.roomId,
                };
                rooms.push(obj);
              });
              this.rooms = rooms;
            })
            .catch((err) => {
              console.log(err);
            });
        })
        .finally(() => {
          this.relationshipLoaded = true;
          this.loadData();
        });
    },

    parseGetDateTime(datetimeString, time = true) {
      const dt = new Date(datetimeString);
      if (time) {
        return `${dt.getHours()}:${dt.getMinutes()}`;
      }
      return `${dt.getDate()}/${dt.getMonth() + 1}/${dt.getFullYear()}`;
    },

    parseSetDateTime(date, time, duration = 0) {
      // TODO: usar regex e fazer validação dos campos
      try {
        // let dateSplited = date.split("/");
        let dateparsed = date; // `${dateSplited[2]}-${dateSplited[1]}-${dateSplited[0]}T`;
        let timeParsed = `T${time}:00`;
        let dtParsed = dateparsed + timeParsed;

        console.log(dtParsed);

        if (duration == 0) return dtParsed;

        let dt = new Date(dtParsed);
        const totalTime = dt.getTime() + parseInt(duration, 10) * 60 * 1000;
        dt.setTime(totalTime);
        const hours = dt.getHours();
        const min = dt.getMinutes();

        timeParsed = `T${hours}:${min}:00`;
        dtParsed = dateparsed + timeParsed;

        console.log("Termino: " + dtParsed);
        return dtParsed;
      } catch (err) {
        console.log(err);
      }
      return "-";
    },
    formatMenuDate(date) {
      if (!date) return null;
      const [year, month, day] = date.split("-");
      return `${day}/${month}/${year}`;
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
</style>
