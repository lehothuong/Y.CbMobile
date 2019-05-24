import Vue from "vue";
import MainApp from "./layouts/MainApp.vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
import { routes } from "./js/routes";
import jQuery from "jquery";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";
global.jQuery = jQuery;
global.$ = jQuery;

Vue.use(VueRouter);
Vue.use(Vuex);
// Vue.use(bootstrap);

const router = new VueRouter({
  routes,
  mode: "history"
});

new Vue({
  el: "#app",
  router: router,
  render: h => h(MainApp)
});
