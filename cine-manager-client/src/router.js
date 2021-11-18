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
    { path: "*", redirect: "/" },
  ],
});


// router.beforeEach((to, from, next) => {
//   // redirect to login page if not logged in and trying to access a restricted page
//   const { authorize } = to.meta;
//   const currentUser = authenticationService.currentUserValue;

//   if (authorize) {
//       if (!currentUser) {
//           // not logged in so redirect to login page with the return url
//           return next({ path: '/login', query: { returnUrl: to.path } });
//       }

//       // check if route is restricted by role
//       if (authorize.length && !authorize.includes(currentUser.role)) {
//           // role not authorised so redirect to home page
//           return next({ path: '/' });
//       }
//   }

//   next();
// })