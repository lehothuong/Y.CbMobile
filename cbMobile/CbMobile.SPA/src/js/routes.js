import Home from "../pages/Home.vue";
import AboutUs from "../pages/AboutUs.vue";
import News from "../pages/News.vue";
import DetailProduct from "../pages/DetailProduct.vue";
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
  }
];
