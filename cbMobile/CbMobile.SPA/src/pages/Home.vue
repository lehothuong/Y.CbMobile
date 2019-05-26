<template>
  <div class="container">
    <div class="row">
      <div class="col-lg-8">
        <Banner></Banner>
      </div>
      <div class="col-lg-4">
        <HomeNews></HomeNews>
      </div>
    </div>
  </div>
</template>
<script>
import Banner from "../components/Banner";
import HomeNews from "../components/HomeNews";
export default {
  components: {
    Banner,
    HomeNews
  }
};
</script>