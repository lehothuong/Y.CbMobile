<template>
  <div class="container">
    <div>
      <h4 class="font-weight-500 mt-lg-4 pt-lg-3 mb-lg-4">Giới thiệu</h4>
      <div v-for="(item,index) in topics" :key="index">
        <div v-html="item.fullDescription"></div>
      </div>
    </div>
  </div>
</template>
<script>
import PostAppService from "../api/topic";
export default {
  data() {
    return {
      topics: []
    };
  },
  methods: {
    getAboutUs() {
      PostAppService.getAboutUs().then(resp => {
        console.log(resp.data);
        this.topics = resp.data;
      });
    }
  },
  created() {},
  mounted() {
    this.getAboutUs();
  }
};
</script>
