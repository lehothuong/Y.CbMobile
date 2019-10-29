import Vue from "vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
//import Element from "element-ui";
// import "./assets/Style/Style.css";
import Slick from "vue-slick";
import "../node_modules/slick-carousel/slick/slick.css";
import { routes } from "./js/routes";
import jQuery from "jquery";
import StarRating from "vue-star-rating";
import ProductZoomer from "vue-product-zoomer";
Vue.use(ProductZoomer);
import "./js/minxin";
var VueScrollTo = require("vue-scrollto");

Vue.component("star-rating", StarRating);
//Vue.use(Element);
global.jQuery = jQuery;
global.$ = jQuery;
import MainApp from "./layouts/MainApp.vue";
//import * as VueGoogleMaps from "vue2-google-maps";

import {
  RadioGroup,
  RadioButton,
  Form,
  FormItem,
  Input,
  Button,
  Notification,
  Dialog,
  Option,
  Select,
  TabPane,
  Tabs
} from "element-ui";

Vue.component(RadioGroup.name, RadioGroup);
Vue.component(RadioButton.name, RadioButton);
Vue.component(Form.name, Form);
Vue.component(FormItem.name, FormItem);
Vue.component(Input.name, Input);
Vue.component(Button.name, Button);
Vue.component(Notification.name, Notification);
Vue.component(Dialog.name, Dialog);
Vue.component(Option.name, Option);
Vue.component(Select.name, Select);
Vue.component(TabPane.name, TabPane);
Vue.component(Tabs.name, Tabs);

Vue.use(VueRouter);
Vue.use(VueScrollTo, {
  container: "body",
  duration: 1000,
  easing: "ease",
  offset: 0,
  force: true,
  cancelable: true
});
Vue.use(Vuex);
Vue.use(Slick);

// Vue.use(VueGoogleMaps, {
//   load: {
//     key: "AIzaSyAvZTey6bHMy0afi-U-AJuplsljH86bR5U",
//     libraries: "places" // This is required if you use the Autocomplete plugin
//   }
// });

const router = new VueRouter({
  routes,
  mode: "history"
});

new Vue({
  el: "#app",
  router: router,

  render: h => h(MainApp)
});
