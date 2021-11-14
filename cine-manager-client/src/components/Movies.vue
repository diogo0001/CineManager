<template>
  <v-container id="app">
    <custom-table
      :headers_p="headers"
      :items_p="items"
      :fields_p="fields"
    />
  </v-container>
</template>

<script>
import { MoviesApi } from "../helpers/api";
import CustomTable from './CustomTable.vue'

const itemInitial = {
        title:null,
        img_url:null,
        description:null,
        duration:null,
      }

const itemLabels = {
        title:'Título',
        img_url:'Imagem',
        description:'Descrição',
        duration:'Duração',
      }

export default {
  name:"Movies",
  components:{
    CustomTable,
  },
  props: {

  },
  data: () => ({
    headers:[],
    items:[],
    fields:{
      title: "Filmes",
      titleAddItem: "Adicionar Filme" ,
      titleEditItem: "Editar Filme" ,
      editLabels: itemLabels,
      editedItem: itemInitial,
      defaultItem: itemInitial,
    },
    headers_p:{default:[]},
    items_p:{default:[]},
  }),
  computed: {
  },
  watch: {

  },
  created() {
    this.loadData();
    console.log("Movies >>> created() ")
  },
  beforeUpdate(){
    console.log("Movies >>> beforeUpdate()")
  },

  methods: {
    loadData(){
      this.items = MoviesApi.getMovies();
      this.headers = [
        {
          text: "Título",
          align: "start",
          sortable: false,
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
          text: "Duração",
          align: "start",
          sortable: false,
          value: "duration",
        },
        { text: "Actions", value: "actions", sortable: false },
      ];

    }
  },
};
</script>

<style scoped></style>
