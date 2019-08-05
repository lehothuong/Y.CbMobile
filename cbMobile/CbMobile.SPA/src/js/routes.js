import Home from "../pages/Home.vue";
import AboutUs from "../pages/AboutUs.vue";
import News from "../pages/News.vue";
import DetailProduct from "../pages/DetailProduct.vue";
import IndexProduct from "../pages/IndexProduct.vue";
import IndexProductManufacrurer from "../pages/IndexProductManufacrurer.vue";
export const routes = [
  {
    path: "/",
    component: Home
  },
  {
    path: "/about-us",
    component: AboutUs
  },
  {
    path: "/news",
    component: News
  },
  {
    path: "/details/:id",
    name: "product-post",
    component: DetailProduct
  },
  {
    path: "/products/:id",
    name: "products",
    component: IndexProduct
  },
  {
    path: "/productManufacrurers/:id",
    name: "productManufacrurers",
    component: IndexProductManufacrurer,
    props(route) {
      return route.query || {};
    }
  }
];
