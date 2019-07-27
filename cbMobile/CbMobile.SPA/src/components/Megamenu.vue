<template>
  <div class="row">
    <div class="col-sm-6 col-lg-4" v-for="(item,index) in categoryProduct" :key="index">
      <h5 class="titleCategoryProduct">{{item.name}}</h5>
      <!-- <a class="dropdown-item" href="#">Another action</a>
      <a class="dropdown-item" href="#">Something else here</a>
      <a class="dropdown-item" href="#">Another action</a>
      <a class="dropdown-item" href="#">Something else here</a>-->
    </div>
  </div>
</template>
<script>
import CategoryProductAppService from "../api/categoryProduct";
export default {
  data() {
    return {
      categoryProduct: []
    };
  },
  methods: {
    getMenuCategoryProduct() {
      CategoryProductAppService.getMenuCategoryProduct().then(resp => {
        this.categoryProduct = resp.data;
        console.log(this.categoryProduct);
      });
    }
  },
  mounted() {
    this.getMenuCategoryProduct();
  }
};
</script>

