import Home from "../pages/Home.vue";
import AboutUs from "../pages/AboutUs.vue";
import News from "../pages/News.vue";
import DetailProduct from "../pages/DetailProduct.vue";
import IndexProduct from "../pages/IndexProduct.vue";
import IndexProductManufacrurer from "../pages/IndexProductManufacrurer.vue";
import DetailNews from "../pages/DetailNews.vue";
import ContactUs from "../pages/ContactUs.vue";
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
    path: "/lien-he",
    name: "contactus",
    component: ContactUs
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
