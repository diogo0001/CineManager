import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'

Vue.config.productionTip = false

const logged = Vue.observable({ logged: false })

Object.defineProperty(Vue.prototype, '$logged', {
  get () {
    return logged.logged
  },
  
  set (value) {
    logged.logged = value
  }
})

new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
