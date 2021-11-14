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
import { RoomsApi } from "../helpers/api";
import CrudTable from './CrudTable.vue'

const itemInitial = {
        name:null,
        seats_number:null,
      }

const itemLabels = {
        name:'Sala 01',
        seats_number:100,
      }

export default {
  name:"Rooms",
  components:{
    CrudTable,
  },
  props: {

  },
  data: () => ({
    headers:[],
    items:[],
    fields:{
      title: "Salas",
      titleAddItem: "Adicionar Sala" ,
      titleEditItem: "Editar Sala" ,
      editLabels: itemLabels,
      editedItem: itemInitial,
      defaultItem: itemInitial,
      crud:false,
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
    console.log("Rooms >>> created() ")
  },
  beforeUpdate(){
    console.log("Rooms >>> beforeUpdate()")
  },

  methods: {
    loadData(){
      this.items = RoomsApi.getRooms();
      this.headers = [
        {
          text: "Sala",
          align: "start",
          value: "name",
        },
        {
          text: "Número de Assentos",
          align: "start",
          value: "seats_number",
        }
      ];
    },
    post(e){
      console.log("Rooms >>> POST "+ e);
    },
    update(e){
      console.log("Rooms >>> UPDATE "+ e);
    },
    remove(e){
      console.log("Rooms >>> DELETE "+ e);
    },
    getItem(e){
      console.log("Rooms >>> GET ITEM "+ e);
    }
  },
};
</script>

<style scoped></style>
