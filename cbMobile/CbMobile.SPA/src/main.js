import Vue from "vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
// import "./assets/Style/Style.css";
import Slick from "vue-slick";
import "../node_modules/slick-carousel/slick/slick.css";
import { routes } from "./js/routes";
import jQuery from "jquery";
global.jQuery = jQuery;
global.$ = jQuery;
import MainApp from "./layouts/MainApp.vue";

Vue.use(VueRouter);
Vue.use(Vuex);
Vue.use(Slick);

const router = new VueRouter({
  routes,
  mode: "history"
});

new Vue({
  el: "#app",
  router: router,
  components: { Slick },
  render: h => h(MainApp)
});
