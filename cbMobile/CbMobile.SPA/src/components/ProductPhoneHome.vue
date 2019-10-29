<template>
  <div class="allProductInHome">
    <div
      class="d-flex justify-content-between align-items-center borderInfoProduct paddingInfoProduct"
    >
      <h6 class="mb-0 text-uppercase font-weight-500">Điện thoại</h6>
      <div class="d-flex categoryPhone">
        <div v-for="(item,index) in manufacturers" :key="index">
          <router-link to="/">{{item.name}}</router-link>
        </div>
      </div>
    </div>
    <div class="showAllProduct">
      <div class="row mx-0">
        <div class="col-lg-25 px-0" v-for="(item,index) in productPhoneInHome" :key="index">
          <div class="listProduct text-center">
            <router-link class="borderRight borderBottom p-3"  v-bind:to="{ name: 'chi-tiet-san-pham', params: {id : item.id},target: '_blank'}">
              <div class="img-1-1 slider">
                <img class="img-small" :alt="item.name" :data-src="item.avatarUrl" />
              </div>
              <p class="nameProductInHomeHot mt-lg-3 mb-0">{{item.name}}</p>
              <div class="priceProductInHomeHot mt-lg-2">
                <p class="realPrice">{{formatPrice(item.valuePromotion)}}</p>
              </div>
            </router-link>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import ManufacturerAppService from "../api/manufacturer";
import ProductAppService from "../api/product";
export default {
  data() {
    return {
      manufacturers: [],
      productPhoneInHome: {},
      id: this.$route.params.id
    };
  },
  methods: {
    getManufacturerInHome() {
      ManufacturerAppService.getManufacturerInHome().then(resp => {
        this.manufacturers = resp.data;
      });
    },
    getPhoneProductInHome() {
      ProductAppService.getPhoneProductInHome().then((resp, data) => {
        this.productPhoneInHome = resp.data;
      });
    }
  },
  created() {
    this.getPhoneProductInHome();
    this.getManufacturerInHome();
  }
};
</script>

<style lang="scss" scoped>
.paddingInfoProduct {
  padding: 0.75rem 0 0.75rem 0.75rem;
}
.showAllProduct {
  border: 1px;
}
.categoryPhone {
  a {
    padding: 0.25rem 1rem;
    color: #288ad6;
    transition: color ease 0.2s;
    &:hover {
      color: #f30;
    }
  }
}
.allProductInHome {
  background: #fff;
}
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
.borderInfoProduct {
  border-bottom: 1px solid #eee;
}
.borderRight {
  border-right: 1px solid #eee;
}
.borderBottom {
  border-bottom: 1px solid #eee;
}
.listProduct {
  a {
    transition: box-shadow ease 0.2s;
    &:hover {
      -webkit-box-shadow: 0 0 7px rgba(0, 0, 0, 0.3);
      box-shadow: 0 0 7px rgba(0, 0, 0, 0.3);
      box-sizing: border-box;
      z-index: 1;
      position: relative;
    }
  }
}
</style>

