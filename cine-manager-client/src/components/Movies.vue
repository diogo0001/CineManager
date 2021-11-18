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
                    <span class="text-h5 ml-12 mt-4">{{ formTitle }}</span>
                  </v-card-title>
                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col>
                          <v-text-field
                            class="mx-8"
                            type="text"
                            v-model="editedItem.title"
                            label="Título"
                            outlined
                            dense
                            required
                          ></v-text-field>
                          <v-file-input
                            class="mr-8"
                            chips
                            label="Imagem"
                            accept="image/png, image/jpeg, image/bmp"
                            prepend-icon="mdi-camera"
                            outlined
                            dense
                            required
                            @change="uploadImage($event)"
                          ></v-file-input>
                          <v-text-field
                            class="mx-8"
                            type="text"
                            v-model="editedItem.duration"
                            label="Duração (min)"
                            outlined
                            dense
                            required
                          ></v-text-field>
                          <v-textarea
                            class="mx-8"
                            type="text"
                            v-model="editedItem.description"
                            label="Descrição"
                            outlined
                            rows="1"
                            auto-grow
                            filled
                            required
                          ></v-textarea>
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
                    >Tem certeza que deseja excluir este Filme?</v-card-title
                  >
                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="closeDelete"
                      >Cancelar</v-btn
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
            <v-icon small class="mr-2" @click="editItem(item)">
              mdi-pencil
            </v-icon>
            <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
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
      </v-app>
    </v-container>
  </div>
</template>

<script>
import {
  getMovies,
  deleteMovie,
  updateMovie,
  createMovie,
} from "../services/api";
import SideBar from "./SideBar.vue";

const itemInitial = {
  movieId: null,
  title: null,
  imgUrl: null,
  description: null,
  duration: null,
};

export default {
  name: "Movies",
  components: {
    SideBar,
  },
  props: {},
  data: () => ({
    headers: [],
    items: [],
    title: "Filmes",
    titleAddItem: "Adicionar Filme",
    titleEditItem: "Editar Filme",
    editedItem: itemInitial,
    defaultItem: itemInitial,
    search: "",
    dialog: false,
    dialogDelete: false,
    editedIndex: -1,
    isloading: false,
    image: null,
  }),
  computed: {
    formTitle() {
      return this.editedIndex === -1 ? this.titleAddItem : this.titleEditItem;
    },
  },
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
    editedItem() {
      this.loadData();
    },
  },
  created() {
    this.loadData();
    console.log("Movies >>> created() ");
  },
  beforeUpdate() {
    console.log("Movies >>> beforeUpdate()");
  },
  methods: {
    editItem(item) {
      this.editedIndex = this.items.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.items.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },
    deleteItemConfirm() {
      deleteMovie(this.editedItem.movieId)
        .then((res) => {
          console.log(res);
          this.items.splice(this.editedIndex, 1);
        })
        .catch((err) => {
          console.log(err);
        });
      this.closeDelete();
    },
    close() {
      this.dialog = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    closeDelete() {
      this.dialogDelete = false;
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
        this.editedIndex = -1;
      });
    },
    save() {
      // TODO: fazer validações
      if (this.editedIndex > -1) {
        updateMovie(this.editedItem.movieId, this.editedItem)
          .then((res) => {
            console.log(res);
            Object.assign(this.items[this.editedIndex], this.editedItem);
          })
          .catch((err) => {
            console.log(err);
          });
      } else {
        this.editedItem.imgUrl = "Img"; // Provisório até corigir o upload da imagem
        const movie = {
          title: this.editedItem.title,
          imgUrl: this.editedItem.imgUrl,
          description: this.editedItem.description,
          duration: this.editedItem.duration,
        };

        console.log(JSON.stringify(movie));

        createMovie(movie)
          .then((res) => {
            console.log(res);
            this.items.push(this.editedItem);
            this.editedItem = this.defaultItem;
          })
          .catch((err) => {
            console.log(err);
          });
      }
      this.close();
    },

    // Problemas ao carregar a imagem
    uploadImage(e) {
      let data = new FormData();
      data.append("name", "my-picture");
      data.append("file", e.target.files[0]);
      this.image = data;
      console.log(`Imagem: ${data}`);
    },
    loadData() {
      let items = [];
      this.isLoading = true;
      getMovies()
        .then((res) => {
          const data = res.data;
          data.map((item) => {
            let obj = {
              movieId: item.movieId,
              title: item.title,
              imgUrl: item.imgUrl,
              description: item.description,
              duration: item.duration,
            };
            items.push(obj);
          });
          this.items = items;
          this.isLoading = false;
        })
        .catch((err) => {
          console.log(err);
        });

      this.headers = [
        {
          text: "Título",
          align: "start",
          value: "title",
          width: "15%",
        },
        {
          text: "Imagem",
          align: "start",
          sortable: false,
          value: "imgUrl",
          width: "15%",
        },
        {
          text: "Descrição",
          align: "start",
          sortable: false,
          value: "description",
          width: "40%",
        },
        {
          text: "Duração (min)",
          align: "start",
          value: "duration",
          width: "15%",
        },
        { text: "Operações", value: "actions", sortable: false, width: "15%" }, 
      ];
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
