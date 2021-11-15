<template>
  <div class="app">
    <side-bar />
    <!-- <v-container id="app"> -->
      <crud-table
        :headers_p="headers"
        :items_p="items"
        :fields_p="fields"
        @post="post"
        @update="update"
        @delete="remove"
      />
    <!-- </v-container> -->
  </div>
</template>

<script>
import { MoviesApi } from "../helpers/api";
import CrudTable from "./CrudTable.vue";
import SideBar from "./SideBar.vue";

const itemInitial = {
  title: null,
  img_url: null,
  description: null,
  duration: null,
};

const itemLabels = {
  title: "Título",
  img_url: "Imagem",
  description: "Descrição",
  duration: "Duração (min)",
};

export default {
  name: "Movies",
  components: {
    CrudTable,
    SideBar,
  },
  props: {},
  data: () => ({
    headers: [],
    items: [],
    fields: {
      title: "Filmes",
      titleAddItem: "Adicionar Filme",
      titleEditItem: "Editar Filme",
      editLabels: itemLabels,
      editedItem: itemInitial,
      defaultItem: itemInitial,
      crud: true,
    },
    headers_p: { default: [] },
    items_p: { default: [] },
  }),
  computed: {},
  watch: {},
  created() {
    this.loadData();
    console.log("Movies >>> created() ");
  },
  beforeUpdate() {
    console.log("Movies >>> beforeUpdate()");
  },

  methods: {
    loadData() {
      this.items = MoviesApi.getMovies();
      this.headers = [
        {
          text: "Título",
          align: "start",
          value: "title",
        },
        {
          text: "Imagem",
          align: "start",
          sortable: false,
          value: "img_url",
        },
        {
          text: "Descrição",
          align: "start",
          sortable: false,
          value: "description",
        },
        {
          text: "Duração (min)",
          align: "start",
          value: "duration",
        },
        { text: "Operações", value: "actions", sortable: false }, // colocar apenas para crud
      ];
    },
    post(e) {
      console.log("Movies >>> POST " + e);
    },
    update(e) {
      console.log("Movies >>> UPDATE " + e);
    },
    remove(e) {
      console.log("Movies >>> DELETE " + e);
    },
    getItem(e) {
      console.log("Movies >>> GET ITEM " + e);
    },
  },
};
</script>

<style scoped></style>
