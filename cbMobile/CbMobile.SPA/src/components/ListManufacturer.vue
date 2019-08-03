<template>
  <div>
    <div v-for="(item,index) in manuFacturers" :key="index">
      <router-link
        :to="{name: 'productManufacrurers', params:{id : item.id, idCategory: idCategory}}"
        class="itemCategoryProduct"
      >{{item.name}}</router-link>
    </div>
  </div>
</template>
<script>
import CategoryProductAppService from "../api/categoryProduct";
export default {
  props: ["idCategory"],
  data() {
    return {
      manuFacturers: []
    };
  },
  methods: {
    getManuFacturerById() {
      CategoryProductAppService.getManuFacturerById(this.idCategory).then(
        resp => {
          this.manuFacturers = resp.data;
          console.log(this.idCategory);
        }
      );
    }
  },
  mounted() {
    this.getManuFacturerById();
  }
};
</script>

