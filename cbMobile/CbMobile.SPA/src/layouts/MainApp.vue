<template>
  <div id="app">
    <Header v-if="!$route.meta.hideHeaderFooter"></Header>
    <div class="content">
      <router-view :key="$route.fullPath" ref="router"></router-view>
      <div v-if="!$route.meta.hideCart" class="support-cart">
        <router-link to="/cart">
          <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 435.104 435.104" style="enable-background:new 0 0 435.104 435.104;" xml:space="preserve" width="30px" height="30px">
            <g>
              <circle cx="154.112" cy="377.684" r="52.736" data-original="#000000" class="active-path" data-old_color="#Ffffff" fill="#FFFFFF"></circle>
              <path d="M323.072,324.436L323.072,324.436c-29.267-2.88-55.327,18.51-58.207,47.777c-2.88,29.267,18.51,55.327,47.777,58.207     c3.468,0.341,6.962,0.341,10.43,0c29.267-2.88,50.657-28.94,47.777-58.207C368.361,346.928,348.356,326.924,323.072,324.436z" data-original="#000000" class="active-path" data-old_color="#F8F8F8" fill="#FFFFFF"></path>
              <path d="M431.616,123.732c-2.62-3.923-7.059-6.239-11.776-6.144h-58.368v-1.024C361.476,54.637,311.278,4.432,249.351,4.428     C187.425,4.424,137.22,54.622,137.216,116.549c0,0.005,0,0.01,0,0.015v1.024h-43.52L78.848,50.004     C77.199,43.129,71.07,38.268,64,38.228H0v30.72h51.712l47.616,218.624c1.257,7.188,7.552,12.397,14.848,12.288h267.776     c7.07-0.041,13.198-4.901,14.848-11.776l37.888-151.552C435.799,132.019,434.654,127.248,431.616,123.732z M249.344,197.972     c-44.96,0-81.408-36.448-81.408-81.408s36.448-81.408,81.408-81.408s81.408,36.448,81.408,81.408     C330.473,161.408,294.188,197.692,249.344,197.972z" data-original="#000000" class="active-path" data-old_color="#F8F8F8" fill="#FFFFFF"></path>
              <path d="M237.056,118.1l-28.16-28.672l-22.016,21.504l38.912,39.424c2.836,2.894,6.7,4.55,10.752,4.608     c3.999,0.196,7.897-1.289,10.752-4.096l64.512-60.928l-20.992-22.528L237.056,118.1z" data-original="#000000" class="active-path" data-old_color="#F8F8F8" fill="#FFFFFF"></path>
            </g>
          </svg>
          <div class="animated infinite pulse kenit-alo-circle-fill"></div>
          <div class="animatedCircle infinite circle "></div>
          <div class="numberProduct">{{totalQuantity}}</div>
        </router-link>
      </div>
    </div>
    <Footer v-if="!$route.meta.hideHeaderFooter" v-bind:isActive="isActive"></Footer>
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
      isActive: false,
      cart:[],
      totalQuantitys:0
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
  mounted(){
  },
  created() {
    if (this.$route.path == "/") {
      this.isActive = true;
    }
  },
  computed: {
    totalQuantity(){
      if(this.$store.state.totalQuantity){
        return this.$store.state.totalQuantity;
      }else{
        this.cart = JSON.parse(localStorage.getItem('cart'));
        if(this.cart){
          this.totalQuantitys = this.cart.map(p => p.amount).reduce((acc,curentValue) => acc + curentValue,0);
          this.$store.commit('SET_TOTALQUANTITY',this.totalQuantitys)
          return this.$store.state.totalQuantity 
        }
        return 0;
      }
    }
  },
};
</script>
<style lang="scss" scoped>

.support-cart{
    position: fixed;
    z-index: 999;
    right: 15px;
    bottom: 80px;
    top: auto !important;
    .numberProduct{
      position: absolute;
      top: -18px;
      right: -15px;
      width: 25px;
      height: 25px;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 13px;
      background-color: #f30;
      border-radius: 50%;
      border:1.5px solid #fff;
      color: #fff;
    }
    .animated{
      background-color: rgba(255,51,0,0.5);
    }
    .animated.infinite {
        animation-iteration-count: infinite;
    }
    .animatedCircle{
      border-radius: 50%;
      border:1px solid red;
      opacity: .75;
      position: absolute;
      width: 100%;
      height: 100%;
      animation: 0.9s pulse3 infinite linear;
    }
    .pulse{
      animation: 1.5s .1s pulse2 infinite linear;
    }
    .kenit-alo-circle-fill {
      width: 60px;
      height: 60px;
      top: -10px;
      position: absolute;
      transition: all 0.1s ease-in-out;
      border-radius: 100%;
      border: 2px solid transparent;
      transition: all .1s;
      background-color: rgba(255,51,0,0.5);
      opacity: .75;
      right: -10px;
    }
    a{
      position: relative;
      margin: 20px 10px;
      text-align: left;
      width: 40px;
      height: 40px;
      cursor: pointer;
      display: block;
    }
    svg {
      position: absolute;
      top: 50%;
      transform: translate(0, -50%);
      z-index: 1;
      left: 0;
      right: 0;
      margin: 0 auto;
    }
}

@keyframes pulse2 {
	0% {transform: scale(1.1)  }
	50% { transform: scale(1) }
  100% { transform: scale(1.1) }
}

@keyframes pulse3 {
	0% {transform: scale(0)  }
	50% { transform: scale(1.1) }
  100% { transform: scale(1.3) }
}
</style>
