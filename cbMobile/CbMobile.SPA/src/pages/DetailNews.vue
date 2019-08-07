<template>
  <div class="container">
    <div class="row mt-5">
      <div class="col-lg-9">
        <h4 class="font-weight-600">{{news.name}}</h4>
        <div class="d-flex mb-lg-1">
          <p class="postByTitle">
            Đăng bởi
            <span class="font-weight-bold">Nguyễn Bảo Chung</span>
            vào lúc 26/02/2019
          </p>
        </div>
        <p class="shortDesNews">{{news.shortDescription}}</p>
        <p class="full-description mb-5" v-html="news.fullDescription"></p>
      </div>
    </div>
  </div>
</template>
<script>
import NewAppService from "../api/news";
export default {
  data() {
    return {
      id: this.$route.params.id,
      news: []
    };
  },
  methods: {
    getDetailById() {
      NewAppService.getDetailById(this.id).then(resp => {
        this.news = resp.data;
      });
    }
  },
  created() {
    this.getDetailById();
  }
};
</script>

