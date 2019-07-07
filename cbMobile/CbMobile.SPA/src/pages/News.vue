<template>
  <div class="container">
    <div class="row mt-lg-5">
      <div class="col-lg-9">
        <div v-for="(item,index) in news" :key="index">
          <div v-if="index == 1">
            <router-link to="/">
              <div class="featuredNews position-relative">
                <div
                  class="img-16-9 img-background"
                  :style="{ backgroundImage: 'url(\'' + item.bannerUrl + '\')' }"
                ></div>
                <div class="overNewsContent">
                  <h4 class="font-weight-500 mb-1">{{item.name}}</h4>
                  <div class="posts">Ngày đăng: {{item.createDate}}</div>
                </div>
              </div>
            </router-link>
          </div>
        </div>
        <div class="blogLaterNews mt-lg-4">
          <h2 class="mb-lg-4">Tin tức mới nhất</h2>
          <div v-for="(item,index) in news" :key="index">
            <div class="boxItems">
              <div class="row">
                <div class="col-lg-3 pr-0">
                  <div
                    class="img-16-9 img-background"
                    :style="{ backgroundImage: 'url(\'' + item.bannerUrl + '\')' }"
                  ></div>
                </div>
                <div class="col-lg-9">
                  <h5 class="titleBoxItem font-weight-500">{{item.name}}</h5>
                  <p class="timePost d-flex align-items-center">
                    <i class="fa fa-calendar-o mr-2" aria-hidden="true"></i>
                    <span>{{item.createDate}}</span>
                  </p>
                  <p class="shortDescription">{{item.shortDescription}}</p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import PostAppService from "../api/topic";
export default {
  data() {
    return {
      news: []
    };
  },
  methods: {
    getAllNews() {
      PostAppService.getAllNews().then(resp => {
        this.news = resp.data;
      });
    }
  },
  created() {
    this.getAllNews();
  }
};
</script>








