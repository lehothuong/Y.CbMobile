<template>
  <div id="app">
    <Header></Header>
    <div class="content">
      <router-view :key="$route.fullPath"></router-view>
    </div>
    <Footer v-bind:isActive="isActive"></Footer>
  </div>
</template>
<script>
import Header from "../components/Header";
import Footer from "../components/Footer";

export default {
  name: "app",
  components: { Header, Footer },
  data: function() {
    return {
      isActive: false
    };
  },
  watch: {
    $route: function(newV, oldV) {
      if (this.$route.path == "/") {
        this.isActive = true;
      } else {
        this.isActive = false;
      }
    }
  },
  created() {
    if (this.$route.path == "/") {
      this.isActive = true;
    }
  }
};
</script>
