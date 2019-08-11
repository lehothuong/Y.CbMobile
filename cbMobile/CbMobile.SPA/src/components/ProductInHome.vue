<template>
  <div class="productInHomeHot mb-lg-5 text-center">
    <div class="titleProductInHome">Giá sốc cuối tuần</div>
    <div class="gallery">
      <div v-for="(item,index) in products" :key="index">
        <router-link v-bind:to="'/details/' + item.id " class="slickOption" :title="item.name">
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
  data() {
    return {
      products: [],
      id: this.$route.params.id
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
    getProductInHomeHot() {
      ProductAppService.getProductHotInHome().then(resp => {
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
  created() {
    console.log(this.$route);
  },
  mounted() {
    setTimeout(() => {
      this.getProductInHomeHot();
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
.productInHomeHot {
  padding: 1rem 2rem 2rem 2rem;
  background-color: #fff;
  border: 1px solid #f30;
}

.titleProductInHome {
  display: inline-block;
  color: #fff;
  background-color: #f30;
  padding: 4px 30px;
  font-weight: 500;
  font-size: 25px;
  position: relative;
  top: -39px;
  text-transform: uppercase;
  &::before {
    left: 100%;
    top: 50%;
    border: solid transparent;
    content: " ";
    height: 0;
    width: 0;
    position: absolute;
    pointer-events: none;
    border-left-color: #f30;
    border-width: 22.5px;
    margin-top: -23px;
  }
  &::after {
    right: 100%;
    top: 50%;
    border: solid transparent;
    content: " ";
    height: 0;
    width: 0;
    position: absolute;
    pointer-events: none;
    border-right-color: #f30;
    border-width: 22.5px;
    margin-top: -23px;
  }
}
</style>

