<template>
  <div>
    <a
      class="dropdown-item"
      href="#"
      v-for="(item,index) in postCategories"
      :key="index"
    >{{item.name}}</a>
  </div>
</template>
<script>
import CategoryAppService from "../api/categories";
export default {
  data() {
    return {
      postCategories: {}
    };
  },
  methods: {
    getCategoryNewMenu() {
      CategoryAppService.getCategoryNewMenu().then(resp => {
        this.postCategories = resp.data;
      });
    }
  },
  created() {
    this.getCategoryNewMenu();
  }
};
</script>

