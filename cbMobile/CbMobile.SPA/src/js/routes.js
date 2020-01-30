import Home from "../pages/Home.vue";
import AboutUs from "../pages/AboutUs.vue";
import News from "../pages/News.vue";
import DetailProduct from "../pages/DetailProduct.vue";
import IndexProduct from "../pages/IndexProduct.vue";
import IndexProductManufacrurer from "../pages/IndexProductManufacrurer.vue";
import DetailNews from "../pages/DetailNews.vue";
import ContactUs from "../pages/ContactUs.vue";
import Checkout from "../pages/Checkout.vue";
import Cart from "../pages/Cart.vue";
import Search from "../pages/Search.vue";
export const routes = [
  {
    path: "/",
    component: Home
  },
  {
    path: "/gioi-thieu",
    name: "gioi-thieu",
    component: AboutUs
  },
  {
    path: "/tin-tuc/:id",
    name: "tin-tuc",
    component: News
  },
  {
    path: "/chi-tiet-tin-tuc/:id",
    name: "chi-tiet-tin-tuc",
    component: DetailNews
  },
  {
    path: "/chi-tiet-san-pham/:id",
    name: "chi-tiet-san-pham",
    component: DetailProduct
  },
  {
    path: "/products/:id",
    name: "products",
    component: IndexProduct
  },
  {
    path: "/lien-he",
    name: "contactus",
    component: ContactUs,
  },
  {
    path: "/tim-kiem",
    name: "search",
    component: Search,
  },
  {
    path: "/dat-hang",
    name: "checkout",
    component: Checkout,
    meta: { hideHeaderFooter: true, hideCart: true }
  },
  {
    path: "/productManufacrurers/:id",
    name: "productManufacrurers",
    component: IndexProductManufacrurer,
    props(route) {
      return route.query || {};
    }
  },
  {
    path: "/gio-hang",
    name: "cart",
    component: Cart,
    meta: { hideCart: true }
  },
];
