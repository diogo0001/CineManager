<template>
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
</template>

<script>
import { SessionsApi } from "../helpers/api";
import CrudTable from './CrudTable.vue'

const itemInitial = {
        date:null,
        ini_time:null,
        end_time:null,
        ticket_price:null,
        animation:null,
        audio:null,
        movie:null,
        room:null
      }

const itemLabels = {
        date:'14/11/2021',
        ini_time:'13:00',
        end_time:'14:30',
        ticket_price:'30,00',
        animation:'2D',
        audio:'Dublado',
        movie:'Hulk',
        room:'Sala 01'
      }

export default {
  name:"Sessions",
  components:{
    CrudTable,
  },
  props: {

  },
  data: () => ({
    headers:[],
    items:[],
    fields:{
      title: "Sessões",
      titleAddItem: "Adicionar Sessão" ,
      titleEditItem: "Editar Sessão" ,
      editLabels: itemLabels,
      editedItem: itemInitial,
      defaultItem: itemInitial,
      crud:true
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
    console.log("Sessions >>> created() ")
  },
  beforeUpdate(){
    console.log("Sessions >>> beforeUpdate()")
  },

  methods: {
    loadData(){
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
          text: "Ingresso",
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
        { text: "Operações", value: "actions", sortable: false }, // colocar apenas para crud 
      ];
    },
    post(e){
      console.log("Sessions >>> POST "+ e);
    },
    update(e){
      console.log("Sessions >>> UPDATE "+ e);
    },
    remove(e){
      console.log("Sessions >>> DELETE "+ e);
    },
    getItem(e){
      console.log("Sessions >>> GET ITEM "+ e);
    }
  },
};
</script>

<style scoped></style>
