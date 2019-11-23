<template>
  <div class="row">
    <div class="col-sm-6 col-lg-4" v-for="(item,index) in categoryProduct" :key="index">
      <router-link v-bind:to="'/products/' + item.id ">
        <h5 class="titleCategoryProduct">{{item.name}}</h5>
      </router-link>
      <div v-for="(items,index) in item.listManufacturer" :key="index">
        <router-link
          :to="{name: 'productManufacrurers', params:{id : items.id}, query: { idCategory : item.id }}"
          class="itemCategoryProduct"
        >{{items.name}}</router-link>
      </div>
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
    // getManuByCategoryProduct(id) {
    //   CategoryProductAppService.getMenuCategoryProduct().then(resp => {
    //     this.categoryProduct = resp.data;
    //   });
    // }
  },

  created() {
    this.getMenuCategoryProduct();
  }
};
</script>

