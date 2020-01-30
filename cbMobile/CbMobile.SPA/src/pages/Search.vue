<template>
    <div class="container py-5">
        <h5 class="text-center font-weight-600" v-if="totalResult>0">Có {{totalResult}} kết quả tìm kiếm phù hợp</h5>
        <div v-else class="text-center">
            <h5 class="text-center font-weight-600" >Không có tìm kiếm phù hợp</h5>
            <p>Vui lòng nhập từ khóa tìm kiếm khác</p>
        </div>
        <div class="row">
            <div class="col-lg-25 px-0" v-for="(item,index) in productPhoneInHome" :key="index">
                <div class="listProduct text-center">
                    <router-link class="borderBottom p-3"  v-bind:to="{ name: 'chi-tiet-san-pham', params: {id : item.id},target: '_blank'}">
                    <div class="img-1-1 slider">
                        <img class="img-small" :alt="item.name" :data-src="item.avatarUrl" />
                    </div>
                    <p class="nameProductInHomeHot mt-lg-3 mb-0">{{item.name}}</p>
                    <div class="priceProductInHomeHot mt-lg-2">
                        <p class="realPrice">{{formatPrice(item.valuePromotion)}}</p>
                    </div>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import SearchAppService from "../api/search";
export default {
    data(){
        return{
            keyword:'',
            productPhoneInHome:[],
            totalResult:0,
        }
    },
    mounted(){
        this.detectParams();
        this.filter();
    },
    methods:{
        detectParams(){
            this.keyword = this.$route.query.key;
        },
        filter(){
            SearchAppService.filter(this.keyword).then(resp=>{
                this.productPhoneInHome = resp.data;
                this.totalResult = this.productPhoneInHome.length;
            })
        }
    }
}
</script>
<style scoped lang="scss">
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
}

.listProduct {
  a {
    transition: box-shadow ease 0.2s;
    &:hover {
      -webkit-box-shadow: 0 0 7px rgba(0, 0, 0, 0.3);
      box-shadow: 0 0 7px rgba(0, 0, 0, 0.3);
      box-sizing: border-box;
      z-index: 1;
      position: relative;
    }
  }
}
</style>