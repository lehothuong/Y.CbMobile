<template>
  <div>
    <div v-for="(item,index) in postCategories" :key="index">
      <router-link
        class="dropdown-item"
        :to="{name : 'tin-tuc', params: { id : item.id }}"
      >{{item.name}}</router-link>
    </div>
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

