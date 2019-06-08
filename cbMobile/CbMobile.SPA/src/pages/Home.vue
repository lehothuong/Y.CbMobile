<template>
  <div class="container">
    <div class="row mb-lg-4">
      <div class="col-lg-8">
        <Banner></Banner>
      </div>
      <div class="col-lg-4">
        <HomeNews></HomeNews>
      </div>
    </div>
    <ProductInHome></ProductInHome>
    <ProductPhoneHome></ProductPhoneHome>
  </div>
</template>
<script>
import Banner from "../components/Banner";
import HomeNews from "../components/HomeNews";
import ProductInHome from "../components/ProductInHome";
import ProductPhoneHome from "../components/ProductPhoneHome";
export default {
  components: {
    Banner,
    HomeNews,
    ProductInHome,
    ProductPhoneHome
  }
};
</script>