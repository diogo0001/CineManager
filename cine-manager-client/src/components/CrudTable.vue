<template>
  <v-container id="app">
    <v-app id="app">
      <span class="title">{{ fields_p.title }}</span>
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
            <v-dialog v-model="dialog" max-width="500px" 
              v-if="fields_p.crud">
              <template v-slot:activator="{ on, attrs }">
                <v-icon class="mr-2" v-bind="attrs" v-on="on">
                  mdi-plus-circle-outline
                </v-icon>
              </template>
              <v-card >
                <v-card-title>
                  <span class="text-h5">{{ formTitle }}</span>
                </v-card-title>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col
                        cols="8"
                        sm="4"
                        md="4"
                        v-for="(value, key) in editedItem"
                        :key="key"
                      >
                        <v-text-field
                          v-model="editedItem[key]"
                          :label="getEditLabels(key)"
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
                  <v-btn color="blue darken-1" text @click="save"> Salvar </v-btn>
                </v-card-actions>
              </v-card>

            </v-dialog>            
            <v-dialog  v-model="dialogDelete" max-width="510px">
              <v-card>
                <v-card-title class="text-h5"
                  >Tem certeza que deseja excluir esse item?</v-card-title
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
          <v-icon small class="mr-2" @click="editItem(item)">
            mdi-pencil
          </v-icon>
          <v-icon small @click="deleteItem(item)"> mdi-delete </v-icon>
        </template>
        <template v-slot:no-data>
          <v-btn color="primary" @click="initialize"> Resetar </v-btn>
        </template>
      </v-data-table>
    </v-app>
  </v-container>
</template>

<script>
export default {
  name: "CrudTable",
  props: {
    fields_p: {
      title: { default: "Tabela" },
      titleAddItem: { default: "Adicionar Item" },
      titleEditItem: { default: "Editar Item" },
      editedItem: {default: {}},
      defaultItem: {default: {}},
      // itemTemplate:{default: {}},
      crud:{ default: true },
    },
    options:{
      selectItems:{ default: false },
      textField:{ default: true }
    },
    headers_p: { default: [] },
    items_p: { default: [] },
  },
  data: () => ({
    search: "",
    dialog: false,
    dialogDelete: false,
    headers: [],
    items: [],
    editedIndex: -1,
    editedItem: {},
    defaultItem: {},
    editLabels:{}
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1
        ? this.fields_p.titleAddItem
        : this.fields_p.titleEditItem;
    },
  },
  watch: {
    dialog(val) {
      val || this.close();
    },
    dialogDelete(val) {
      val || this.closeDelete();
    },
    items_p() {
      this.initialize();
    },
    // headers() {},
  },
  created() {
    console.log("Table >>> created() ");
    // this.initialize();
  },
  beforeUpdate() {
    console.log("Table >>> beforeUpdate()");
    
  },

  methods: {
    initialize() {
      (this.editedItem = { ...this.fields_p.editedItem }),
        (this.defaultItem = { ...this.fields_p.defaultItem }),
        (this.headers = [...this.headers_p]);
      this.items = [...this.items_p];
      this.getLabelsFromHeader();
      // console.log(JSON.stringify(this.items ))
    },

    editItem(item) {
      this.editedIndex = this.items.indexOf(item);
      this.editedItem = Object.assign({}, item);
      // console.log(`editedItem ${JSON.stringify(this.editedItem) }`)
      this.dialog = true;
    },

    deleteItem(item) {
      this.editedIndex = this.items.indexOf(item);
      this.editedItem = Object.assign({}, item);
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      this.$emit("delete");
      this.items.splice(this.editedIndex, 1);
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
      if (this.editedIndex > -1) {
        Object.assign(this.items[this.editedIndex], this.editedItem);
        this.$emit("update");
      } else {
        this.items.push(this.editedItem);
        this.$emit("post");
        // validar se os dados não são nulos -> ver required
      }
      this.close();
    },
    details() {
      this.$emit("details");
    },
    getEditLabels(label) {
      // console.log(`getEditLabels ${label} -- ${this.fields_p.editLabels[label]}`)
      return this.editLabels[label];
    },
    getLabelsFromHeader(){
      let obj = {}
      this.headers.map((item)=>{
          obj[item.value] = item.text
      });
      // console.log(JSON.stringify(obj))
      this.editLabels = obj;
    }
  },
};
</script>

<style scoped>
/* .v-data-table,
.v-icon{
  color: rgb(38, 102, 158);
} */
.search{
  max-width: 340px;
}
.title{
  margin-top:-10px;
  padding: 16px 0 16px 18px;
  width: 100%;
  /* background: rgba(14, 66, 87, 0.959); n1 */
  
  /* background: rgba(1, 55, 77, 0.959);
  color: aliceblue; */

  /* border-radius: 6px 6px 0 0 ; */
  /* box-shadow: rgba(179, 179, 179, 0.74) 0 0 20px 1px; */
}

</style>
