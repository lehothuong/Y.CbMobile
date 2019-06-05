import Vue from "vue";
import MainApp from "./layouts/MainApp.vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
import { routes } from "./js/routes";
import jQuery from "jquery";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
import Slick from "vue-slick";
import "./assets/Style/Style.css";
import "../node_modules/slick-carousel/slick/slick.css";
global.jQuery = jQuery;
global.$ = jQuery;

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
