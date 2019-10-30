<template>
  <div class="mt-lg-3">
    <div class="headerTitleNews">
      <router-link :to="{name : 'tin-tuc', params: { id : categoriesId }}">
        <p class="mb-0">Tin công nghệ</p>
      </router-link>
    </div>
    <div v-for="(item,index) in newTechnology" :key="index">
      <router-link
        class="linkHomeBoxNews"
        :to="{ name: 'chi-tiet-tin-tuc', params: {id : item.id}}"
      >
        <div class="homeBoxNews p-2">
          <div class="row">
            <div class="col-lg-4 pr-0">
              <div
                class="img-background img-16-9"
                :style="{ backgroundImage: 'url(\'' + item.bannerUrl + '\')' }"
              ></div>
            </div>
            <div class="col-lg-8">
              <div class="infoBoxNewsHome">
                <h3 class="titleBoxNews">{{item.name}}</h3>
                <p class="mb-0 postDateTime">{{item.createDate}}</p>
              </div>
            </div>
          </div>
        </div>
      </router-link>
    </div>
  </div>
</template>
<script>
import NewAppService from "../api/news";
export default {
  data() {
    return {
      newTechnology: [],
      categoriesId: 0
    };
  },
  methods: {
    getNewTechnology() {
      NewAppService.getNewTechnology().then(resp => {
        this.newTechnology = resp.data;
        this.categoriesId = resp.data.find(element => element).categoriesId;
      });
    }
  },
  created() {
    this.getNewTechnology();
  }
};
</script>

