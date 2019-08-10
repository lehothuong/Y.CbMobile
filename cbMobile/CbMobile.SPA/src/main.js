import Vue from "vue";
import VueRouter from "vue-router";
import Vuex from "vuex";
import Element from "element-ui";
// import "./assets/Style/Style.css";
import Slick from "vue-slick";
import "../node_modules/slick-carousel/slick/slick.css";
import { routes } from "./js/routes";
import jQuery from "jquery";
import StarRating from "vue-star-rating";
import ProductZoomer from "vue-product-zoomer";
Vue.component("star-rating", StarRating);
Vue.use(Element);
global.jQuery = jQuery;
global.$ = jQuery;
import MainApp from "./layouts/MainApp.vue";
import * as VueGoogleMaps from "vue2-google-maps";

import {
  RadioGroup,
  RadioButton,
  Form,
  FormItem,
  Input,
  Button
} from "element-ui";

Vue.component(RadioGroup.name, RadioGroup);
Vue.component(RadioButton.name, RadioButton);
Vue.component(Form.name, Form);
Vue.component(FormItem.name, FormItem);
Vue.component(Input.name, Input);
Vue.component(Button.name, Button);

Vue.use(VueRouter);
Vue.use(Vuex);
Vue.use(Slick);
Vue.use(ProductZoomer);
Vue.use(VueGoogleMaps, {
  load: {
    key: "AIzaSyAvZTey6bHMy0afi-U-AJuplsljH86bR5U",
    libraries: "places" // This is required if you use the Autocomplete plugin
  }
});

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
