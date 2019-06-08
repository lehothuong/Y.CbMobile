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
        <div class="col-lg-2 px-0">
          <div></div>
          <!-- <div class="gallery text-center">
            <div v-for="(item,index) in products" :key="index">
            <router-link class="borderRight borderBottom" to="/">
              <div
                class="img-background img-1-1"
                style="background-image:url('/src/assets/Images/samsung.png')"
              ></div>
              <p class="nameProductInHomeHot mt-lg-3 mb-0">Samsung Galaxy S10e</p>
              <div class="priceProductInHomeHot mt-lg-2">
                <p class="realPrice">15.990.000₫</p>
              </div>
            </router-link>
            </div>
          </div>-->
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import ManufacturerAppService from "../api/manufacturer";
export default {
  data() {
    return {
      manufacturers: []
    };
  },
  methods: {
    getManufacturerInHome() {
      ManufacturerAppService.getManufacturerInHome().then(resp => {
        this.manufacturers = resp.data;
      });
    }
  },
  mounted() {
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
.gallery {
  a {
    transition: box-shadow ease 0.2s;
    &:hover {
      -webkit-box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
      box-shadow: 0 0 50px rgba(0, 0, 0, 0.1);
      box-sizing: border-box;
      z-index: 1;
    }
  }
}
</style>

