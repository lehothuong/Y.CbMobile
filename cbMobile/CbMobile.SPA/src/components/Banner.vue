<template>
  <div class="mt-lg-3">
    <router-link class="bannerSlick" to="/">
      <div v-for="(item,index) in banners" :key="index">
           <div
            class="img-background img-18-9"
            :style="{ backgroundImage: 'url(\'' + item.bannerUrl + '\')' }"
          ></div>
      </div>
    </router-link>
  </div>
</template>
<script>
import Slick from "vue-slick";
import BannerAppService from '../api/banner'
import { BannerCategory } from '../api/enum/enum'

export default {
  components: { Slick },
  data() {
    return {
      banners:[]
    };
  },
  mounted(){
    this.getBannerHome();
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
    getBannerHome(){
      BannerAppService.getBannerHome(BannerCategory.BannerHomeTop).then(resp => {
        this.banners = resp.data;
      })
    }
  },
   updated() {
    $(".bannerSlick").slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      dots: true,
      infinite: true,
      autoplay: true,
      autoplaySpeed: 2000,
      appendDots: $(".slick-dots li").html(
        '<a href="#"><img src="slide-dot.png" /></a>'
      ),
    });
  },
};
</script>

