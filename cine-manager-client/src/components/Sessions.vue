<template>
  <div class="app">
    <side-bar/>
    <v-container id="app">
      <crud-table
        :headers_p="headers"
        :items_p="items"
        :fields_p="fields"
        @post="post"
        @update="update"
        @delete="remove"
      />
    </v-container>
  </div>
</template>

<script>
import { SessionsApi } from "../helpers/api";
import CrudTable from "./CrudTable.vue";
import SideBar from "./SideBar.vue";

const itemInitial = {
  date: null,
  ini_time: null,
  end_time: null,
  ticket_price: null,
  animation: [],
  audio: [],
  room: [],
  movie: [],
};

// Implementar o tipo de input dinamicamente na tabela posteriormente
// const itemTemplate = {
//   date: "date",
//   ini_time: "time",
//   end_time: "time",
//   ticket_price: "number",
//   animation: "array",
//   audio: "array",
//   room: "array",
//   movie: "array",
// };

export default {
  name: "Sessions",
  components: {
    CrudTable,
    SideBar,
  },
  props: {},
  data: () => ({
    headers: [],
    items: [],
    fields: {
      title: "Sessões",
      titleAddItem: "Adicionar Sessão",
      titleEditItem: "Editar Sessão",
      editedItem: itemInitial,
      defaultItem: itemInitial,
      // itemTemplate: itemTemplate,
      crud: true,
    },
    headers_p: { default: [] },
    items_p: { default: [] },
  }),
  computed: {},
  watch: {},
  created() {
    this.loadData();
    console.log("Sessions >>> created()");
  },
  beforeUpdate() {
    console.log("Sessions >>> beforeUpdate()");
  },

  methods: {
    loadData() {
      this.items = SessionsApi.getSessions();
      this.headers = [
        {
          text: "Filme",
          align: "start",
          value: "movie",
        },
        {
          text: "Sala",
          align: "start",
          value: "room",
        },
        {
          text: "Data",
          align: "start",
          value: "date",
        },
        {
          text: "Início",
          align: "start",
          sortable: false,
          value: "ini_time",
        },
        {
          text: "Término",
          align: "start",
          sortable: false,
          value: "end_time",
        },
        {
          text: "Ingresso (R$)",
          align: "start",
          value: "ticket_price",
        },
        {
          text: "Animação",
          align: "start",
          value: "animation",
        },
        {
          text: "Áudio",
          align: "start",
          value: "audio",
        },
        { text: "Operações", value: "actions", sortable: false },
      ];
    },
    post(e) {
      console.log("Sessions >>> POST " + e);
    },
    update(e) {
      console.log("Sessions >>> UPDATE " + e);
    },
    remove(e) {
      console.log("Sessions >>> DELETE " + e);
    },
    getItem(e) {
      console.log("Sessions >>> GET ITEM " + e);
    },
  },
};
</script>

<style scoped>

</style>
