<template>
  <div class="mt-lg-3">
    <router-link class="slickOption" to="/">
      <slick ref="slick" :options="slickOptions">
        <img width="100" src="/src/assets/Images/slider_1.jpg" alt>
        <img width="100" src="/src/assets/Images/slider_1.jpg" alt>
        <img width="100" src="/src/assets/Images/slider_1.jpg" alt>
        <img width="100" src="/src/assets/Images/slider_1.jpg" alt>
        <img width="100" src="/src/assets/Images/slider_1.jpg" alt>
      </slick>
    </router-link>
  </div>
</template>
<script>
import Slick from "vue-slick";

export default {
  components: { Slick },
  data() {
    return {
      slickOptions: {
        dots: true,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        appendDots: $(".slick-dots li").html(
          '<a href="#"><img src="slide-dot.png" /></a>'
        )
      }
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
    }
  }
};
</script>

