<template>
  <div class="genericProduct mb-lg-5 mt-lg-5 text-center">
    <h2 class="titleGenericProduct">Giá sốc cuối tuần</h2>
    <div class="gallery">
      <div v-for="(item,index) in products" :key="index">
        <router-link class="slickOption" v-bind:to="'/details/' + item.id " :title="item.name">
          <div
            class="img-background img-1-1"
            :style="{ backgroundImage: 'url(\'' + item.avatarUrl + '\')' }"
          ></div>
          <p class="nameProductInHomeHot mt-lg-3 mb-0">{{item.name}}</p>
          <div class="priceProductInHomeHot mt-lg-2">
            <p class="realPrice">{{item.value}}</p>
          </div>
        </router-link>
      </div>
    </div>
  </div>
</template>
<script>
import ProductAppService from "../api/product";
export default {
  props: ["categoryProductId"],
  data() {
    return {
      products: []
    };
  },
  methods: {
    next() {
      this.$refs.slick.next();
    },
    prev() {
      this.$refs.slick.prev();
    },
    reInit() {
      // Helpful if you have to deal with v-for to update dynamic lists
      this.$nextTick(() => {
        this.$refs.slick.reSlick();
      });
    },
    getProductGeneric() {
      ProductAppService.getProductGeneric(this.categoryProductId).then(resp => {
        this.products = resp.data;
      });
    }
  },
  updated() {
    $(".gallery").slick({
      slidesToShow: 5,
      slidesToScroll: 1,
      dots: false,
      autoplay: false,
      infinite: true,
      fade: false,
      arrows: true,
      responsive: [
        {
          breakpoint: 500,
          settings: {
            dots: false,
            arrows: false,
            infinite: false,
            slidesToShow: 2,
            slidesToScroll: 2
          }
        }
      ]
    });
  },
  created() {},
  mounted() {
    setTimeout(() => {
      this.getProductGeneric();
    }, 300);
  }
};
</script>
<style lang="scss" scoped>
.priceProductInHomeHot {
  .realPrice {
    font-weight: 700;
    color: #f30;
  }
}

.titleGenericProduct {
  display: block;
  font-size: 20px;
  margin: 0;
  color: #222;
  text-align: left;
  border-bottom: 2px solid #eee;
  padding-bottom: 24px;
  margin-bottom: 24px;
  text-transform: uppercase;
  position: relative;
  font-weight: 500;
  &:after {
    left: 0;
    bottom: -2px;
    content: "";
    width: 76px;
    height: 2px;
    display: inline-block;
    background: #f30;
    position: absolute;
  }
}
</style>

