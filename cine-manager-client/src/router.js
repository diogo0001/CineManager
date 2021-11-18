import Vue from "vue";
import Router from "vue-router";
import Login from "./components/Login";
import Movies from "./components/Movies";
import Sessions from "./components/Sessions";
import Rooms from "./components/Rooms";

Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "login",
      component: Login,
    },
    {
      path: "/movies",
      name: "movies",
      component: Movies,
    },
    {
      path: "/sessions",
      name: "sessions",
      component: Sessions,
    },
    {
        path: "/rooms",
        name: "rooms",
        component: Rooms,
      },
  ],
});
