import Home from "../pages/Home.vue";
import AboutUs from "../pages/AboutUs.vue";
import News from "../pages/News.vue";
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
  }
];
