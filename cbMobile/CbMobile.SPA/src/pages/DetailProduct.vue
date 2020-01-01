<template>
  <div class="container" v-if="loading">
    <div>
      <div class="infoDetail pt-lg-3 pb-lg-2 border-bottom">
        <h2 class="mb-lg-3">{{products.name}}</h2>
        <div class="review d-flex align-items-center">
          <span>
            Mã sản phẩm:
            <strong class="font-italic">00543146</strong>
          </span>
          <span class="px-lg-2 color-red">|</span>
          <span>
            <star-rating
              :show-rating="false"
              :read-only="true"
              v-model="totalStars"
              v-bind:increment="0.5"
              v-bind:star-size="15"
            ></star-rating>
          </span>
          <a href="#" class="ml-lg-2" v-scroll-to="'#element'">Đánh giá sản phẩm</a>
        </div>
      </div>
      <div class="detailProduct pt-lg-3">
        <div class="row">
          <div class="col-lg-9">
            <div class="row">
              <div class="col-lg-6">
                <ProductZoomer
                  class="zoomerContainer"
                  :base-images="images"
                  :base-zoomer-options="zoomerOptions"
                />
              </div>
              <div class="col-lg-6">
                <h2 class="color-red font-weight-500">{{formatPrice(products.valuePromotion)}}</h2>
                <div class="d-flex justify-content-between" v-if="value">
                  <p>
                    <span>Giá thị trường:</span>
                    <span class="text-decoration font-weight-500" >{{formatPrice(value)}}</span>
                  </p>
                  <p class="color-green" v-if="priceSavings > 0">
                    <span>Tiết kiệm:</span>
                    <span class="text-decoration font-weight-500">{{formatPrice(priceSavings)}}</span>
                  </p>
                </div>
                <p>
                  <span class="font-weight-500">Tình trạng:</span>
                  <span class="color-green" v-if="products.status">Còn hàng</span>
                  <span class="color-red" v-else>Tạm thời hết hàng</span>
                </p>
                <p class>
                  <span class="font-weight-bold">Dung lượng:</span>
                </p>
                <div class="customRadio">
                  <div>
                    <el-radio-group @change="postAccessories(mainMemoryId,mainColorId)" v-for="(item,index) in listMainMemory" :key="index" v-model="mainMemoryId">
                      <el-radio-button :label="item.id">{{item.name}}</el-radio-button>
                    </el-radio-group>
                  </div>
                </div>

                <p class>
                  <span class="font-weight-bold">Màu sắc:</span>
                </p>
                <div class="customRadio mb-lg-3">
                  <div>
                    <el-radio-group
                      @change="postAccessories(mainMemoryId,mainColorId)"
                      v-for="(item,index) in listMainColor"
                      :key="index"
                      v-model="mainColorId"
                    >
                      <el-radio-button id="isMainColor" :label="item.id">{{item.name}}</el-radio-button>
                    </el-radio-group>
                  </div>
                </div>
                <div class="shoppingProduct d-flex w-100">
                  <!-- <div
                    class="totalProduct d-flex w-40 justify-content-between font-weight-500 align-items-center"
                  >
                    <button class="btn btnPlus" type="button">-</button>
                    <span>1</span>
                    <button class="btn btnPlus" type="button">+</button>
                  </div> -->
                  <div class="totalProduct">
                    <el-input-number v-model="amount"  :min="1" :max="99"></el-input-number>
                  </div>
                  <div class="checkProduct w-60">
                    <button @click="addCart(products)" class="btn btnCheck text-uppercase font-weight-500">
                      <i class="fa fa-cart-arrow-down mr-2"  aria-hidden="true"></i>
                      Mua ngay
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-lg-9" id="element">
            <el-tabs v-model="activeName">
              <el-tab-pane label="Mô tả" name="first">
                <div class="full-description" v-html="products.fullDescription"></div>
              </el-tab-pane>
              <el-tab-pane label="Nhận xét sản phẩm" name="second">
                <div class="border-bottom py-lg-2">
                  <span class="titleReview">Đánh giá sản phẩm</span>
                </div>
                <div class="d-flex py-lg-3">
                  <div v-if="totalReviews > 0" class="d-flex align-items-start">
                    <h3 class="pr-3 mb-0">{{totalStars}}</h3>
                    <div>
                      <span>
                        <star-rating
                          :show-rating="false"
                          :read-only="true"
                          v-model="totalStars"
                          v-bind:increment="1"
                          v-bind:star-size="22"
                        ></star-rating>
                      </span>
                      <div class="d-flex align-items-center mt-lg-1">
                        <h5 class="pr-1 mb-0">{{totalReviews}}</h5>
                        <span>
                          <i class="fa fa-users" aria-hidden="true"></i>
                        </span>
                      </div>
                    </div>
                  </div>
                  <div class="ml-auto">
                    <a
                      class="btn btnSendContact font-weight-bolder text-uppercase color-white"
                      @click="centerDialogVisible = true"
                    >Viết đánh giá</a>
                  </div>
                </div>
                <div
                  v-for="(item,index) in allReivews"
                  :key="index"
                  class="border-top"
                  :v-if="totalReviews > 0"
                >
                  <div class="d-flex align-items-center pt-lg-2">
                    <i class="fa fa-user-circle-o fontSiteUserIcon pr-3" aria-hidden="true"></i>
                    <div>
                      <p class="mb-0">{{item.name}}</p>
                      <div class="d-flex align-items-center">
                        <star-rating
                          :show-rating="false"
                          :read-only="true"
                          v-model="item.reviewStar"
                          v-bind:increment="1"
                          v-bind:star-size="16"
                        ></star-rating>
                        <p class="pl-lg-2 mb-0 createDateReview">{{item.createDate}}</p>
                      </div>
                    </div>
                  </div>
                  <div class="pb-lg-2 pt-lg-1">
                    <p class="mb-0 titleCommentReview">{{item.title}}</p>
                    <p class="mb-0 pl-lg-3">{{item.content}}</p>
                  </div>
                </div>
              </el-tab-pane>
            </el-tabs>
          </div>
        </div>
      </div>
      <!-- <GenericProduct :categoryProductId="categoryProductId"></GenericProduct> -->
    </div>
     <el-dialog class="cartDialog" :visible.sync="cartDialog" width="70%" >
       <span slot="title" class="el-dialog__title">Bạn đã thêm <span class="color-red"> {{nameProductCart}} </span> vào giỏ hàng</span>
       <router-link class="titleQuantityPopup" to="/gio-hang">
         Giỏ hàng của bạn có {{totalProduct}} sản phẩm
       </router-link>
       <table class="tableProduct">
        <thead>
          <tr>
            <th>Sản phẩm</th>
            <th>Đơn giá</th>
            <th>Số lượng</th>
            <th>Thành tiền</th>
          </tr>
        </thead>
        <tbody class="summaryProduct">
          <tr v-for="(item,index) in cart" :key="index">
            <td class="text-left d-flex">
               <router-link to="/">
                  <img class="itemImage" width="80" height="80" :src="item.avatarUrl"/>
                </router-link>
              <div class="ml-2">
                <router-link class="productCartTitle mb-1" to="/gio-hang">
                  {{item.name}}
                </router-link>
                <p class="font-weight-normal fontSize13">{{item.mainMemoryName}} / {{item.mainColorName}}</p>
                <a href="" @click.prevent="removeProduct(index,item)" class="productRemove">Bỏ sản phẩm</a>
              </div>
            </td>
            <td>{{formatPrice(item.valuePromotion)}}</td>
            <td><el-input-number @change="changePrice(index,item)" v-model="item.amount"  :min="1" :max="99"></el-input-number></td>
            <td>{{formatPrice(item.totalPrice)}}</td>
          </tr>
        </tbody>
      </table>
      <hr class="my-0"/>
      <div class="d-flex justify-content-between">
        <router-link class="processCart mt-2" to="/">
         Tiếp tục mua hàng
       </router-link>
       <p class="font-weight-600 mt-2 mb-0"><span>Thành tiền: </span><span class="color-main">275.880.000₫</span></p>
      </div>
      <button type="button" class="btn btnCheckout w-100 mt-lg-4">Thanh toán đơn hàng</button>
    </el-dialog>
    <el-dialog title="Đánh giá sản phẩm" :visible.sync="centerDialogVisible" width="25%" center>
      <el-form ref="reviews" :rules="rules" :model="reviews" class="pt-lg-3">
        <span class="d-flex justify-content-center pb-lg-3">
          <star-rating
            :border-width="4"
            :show-rating="false"
            v-bind:star-size="20"
            v-model="reviews.reviewStar"
            border-color="#FFD055"
            :rounded-corners="true"
          ></star-rating>
        </span>
        <el-form-item prop="name" class="pb-lg-2">
          <el-input placeholder="Nhập tên của bạn" v-model="reviews.name"></el-input>
        </el-form-item>
        <el-form-item prop="email" class="pb-lg-2">
          <el-input placeholder="Nhập Email của bạn" type="email" v-model="reviews.email"></el-input>
        </el-form-item>
        <el-form-item prop="title" class="pb-lg-2">
          <el-input placeholder="Tiêu đề" v-model="reviews.title"></el-input>
        </el-form-item>
        <el-form-item prop="content">
          <el-input :rows="5" type="textarea" placeholder="Nội dung" v-model="reviews.content"></el-input>
        </el-form-item>
        <div class="d-flex justify-content-center pt-lg-3">
          <el-button
            @click="submitForm('reviews')"
            class="btn btnSendReview font-weight-bolder text-uppercase"
          >Gửi</el-button>
        </div>
      </el-form>
      <!-- <span slot="footer" class="dialog-footer">
        <el-button @click="centerDialogVisible = false">Cancel</el-button>
        <el-button type="primary" @click="centerDialogVisible = false">Confirm</el-button>
      </span>-->
    </el-dialog>
  </div>
</template>
<script>
import ReviewAppService from "../api/review";
import ProductAppService from "../api/product";
// import { AppMutations } from "../store/index";
import GenericProduct from "../components/GenericProduct";
export default {
  components: {
    // GenericProduct
  },
  data() {
    return {
      id: this.$route.params.id,
      totalProduct:null,
      cart:[],
      amount:1,
      totalReviews: 0,
      totalStars: 0,
      priceSavings: 0,
      loading: true,
      listMainMemory:[],
      listMainColor:[],
      rom: "",
      checkColor: "",
      num:1, 
      value:0,
      valuePromotion:0,
      mainMemoryName:'',
      mainColorName:'',
      nameProductCart:'',
      totalQuantity:null,
      mainMemoryId:0,
      mainColorId:0,
      reviews: {
        name: "",
        title: "",
        content: "",
        email: "",
        productId: this.$route.params.id,
        reviewStar: 3
      },
      rules: {
        name: [
          {
            required: true,
            message: "Xin vui lòng nhập Họ Tên",
            trigger: "blur"
          },
          {
            min: 3,
            message: "Xin vui nhập tối thiểu 3 ký tự",
            trigger: "blur"
          }
        ],
        email: [
          {
            required: true,
            message: "Xin vui lòng nhập Email",
            trigger: "blur"
          },
          {
            type: "email",
            message: "Xin vui lòng nhập đúng định dạng Email",
            trigger: ["blur", "change"]
          }
        ],
        title: [
          {
            required: true,
            message: "Xin vui lòng nhập Tiêu đề",
            trigger: "blur"
          },
          {
            min: 3,
            message: "Xin vui nhập tối thiểu 3 ký tự",
            trigger: "blur"
          }
        ],
        content: [
          {
            required: true,
            message: "Xin vui lòng nhập Nội dung",
            trigger: "blur"
          }
        ]
      },
      centerDialogVisible: false,
      cartDialog:false,
      products: [],
      gender: [],
      allReivews: [],
      listMemory: [],
      color: [],
      categoryProductId: Number,
      radio: 3,
      activeName: "first",
      images: {
        thumbs: [
          {
            id: 1,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636051023338-ss-galaxy-s10-plus-den-1.png"
          },
          {
            id: 2,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050913338-ss-galaxy-s10-plus-den-2.png"
          },
          {
            id: 3,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050673338-ss-galaxy-s10-plus-den-3.png"
          },
          {
            id: 4,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 5,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 6,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 7,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 8,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          }
        ],
        normal_size: [
          {
            id: 1,
            url:
              "https://bizweb.dktcdn.net/thumb/1024x1024/100/348/133/products/636863636051023338-ss-galaxy-s10-plus-den-1.png"
          },
          {
            id: 2,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050913338-ss-galaxy-s10-plus-den-2.png"
          },
          {
            id: 3,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050673338-ss-galaxy-s10-plus-den-3.png"
          },
          {
            id: 4,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 5,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 6,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 7,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 8,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          }
        ],
        large_size: [
          {
            id: 1,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636051023338-ss-galaxy-s10-plus-den-1.png"
          },
          {
            id: 2,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050913338-ss-galaxy-s10-plus-den-2.png"
          },
          {
            id: 3,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863636050673338-ss-galaxy-s10-plus-den-3.png"
          },
          {
            id: 4,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 5,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 6,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 7,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          },
          {
            id: 8,
            url:
              "https://bizweb.dktcdn.net/thumb/compact/100/348/133/products/636863637628103338-ss-galaxy-s10-plus-den-4.png"
          }
        ]
      },
      zoomerOptions: {
        zoomFactor: 4, // scale for zoomer
        pane: "container-round", // three type of pane ['pane', 'container-round', 'container']
        hoverDelay: 500, // how long after the zoomer take effect
        namespace: "inline-round-zoomer", // add a namespace for zoomer component, useful when on page have mutiple zoomer
        move_by_click: true, // move image by click thumb image or by mouseover
        scroll_items: 4, // thumbs for scroll
        scroller_position: "bottom"
      },
      groupAcc:{
        mainMemoryId:undefined,
        mainColorId:undefined
      }
    };
  },
  computed:{
    totalPrice(){
      return this.amount * this.products.valuePromotion
    }
  },
  mounted() {
    this.getDetailProduct();
    this.getAllReviewByProductId();
  },
  beforeDestroy() {
    this.getAllReviewByProductId();
  },
  methods: {
    getTotalQuantity(){
      this.totalQuantity = this.cart.map(p => p.amount).reduce((acc,curentValue) => acc + curentValue,0);
      this.$store.commit('SET_TOTALQUANTITY',this.totalQuantity)
    },
    changePrice(value,object){
      localStorage.removeItem('cart');
      this.cart[value].totalPrice = object.amount * object.valuePromotion;
      let parsed = JSON.stringify(this.cart);
      localStorage.setItem('cart', parsed);
      this.getTotalQuantity();
    },
    removeProduct(value,object){
      localStorage.removeItem('cart');
      this.cart.splice(value, 1);
      let parsed = JSON.stringify(this.cart);
      localStorage.setItem('cart', parsed);
      if(this.cart.length == 0){
         this.cartDialog = false;
      }
      this.getTotalQuantity();
    },
    setCartSaveLocal(model){
      let obj = {
            id:model.id,
            avatarUrl : model.avatarUrl,
            name : model.name,
            mainMemoryName : this.mainMemoryName,
            mainColorName: this.mainColorName,
            mainColorId: this.mainColorId,
            mainMemoryId: this.mainMemoryId,
            valuePromotion: model.valuePromotion,
            amount:this.amount,
            totalPrice: this.totalPrice
          };
      this.cart.push(obj)
      let parsed = JSON.stringify(this.cart);
      localStorage.setItem('cart', parsed);
    },
    addCart(model){
      if (localStorage.getItem('cart')) {
        this.cart = JSON.parse(localStorage.getItem('cart'));
        localStorage.removeItem('cart');
        const found = this.cart.find(find => find.id == this.products.id);
        if(found){
          found.amount += this.amount;
          found.totalPrice = found.amount * this.products.valuePromotion;
          let parsed = JSON.stringify(this.cart);
          localStorage.setItem('cart', parsed);
        }else{
          this.setCartSaveLocal(model);
        }
      }
      else{
        this.setCartSaveLocal(model);
      }
      this.totalProduct = this.cart.length;
      this.nameProductCart = this.cart.slice(-1).find(p=>p).name;
      this.getTotalQuantity();
      this.cartDialog = true;
    },
    postAccessories(mainMemoryId,mainColorId){
      ProductAppService.getDetailAccessoriesById(mainMemoryId,mainColorId).then(resp=>{
        this.value = resp.data.value;
        this.mainMemoryName = resp.data.mainMemoryName;
        this.mainColorName = resp.data.mainColorName;
        this.priceSavings = this.value - this.products.valuePromotion;
      })
    },
    formatPrice(value) {
      let val = (value / 1).toFixed(0).replace(".", ",");
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "₫";
    },
    getDetailProduct() {
      this.loading = false;
      ProductAppService.getDetailProduct(this.id).then(resp => {
        this.products = resp.data;
        this.listMainMemory = this.products.listMainMemory;
        this.listMainColor = this.products.listMainColor;
        this.categoryProductId = this.products.categoryProductId;
        this.priceSavings = this.products.detailAccessoriesDefaults.value - this.products.valuePromotion;
        this.value = this.products.detailAccessoriesDefaults.value;
        this.mainColorName = this.products.detailAccessoriesDefaults.mainColorName;
        this.mainMemoryName = this.products.detailAccessoriesDefaults.mainMemoryName;
        this.mainColorId = this.products.detailAccessoriesDefaults.mainColorId;
        this.mainMemoryId = this.products.detailAccessoriesDefaults.mainMemoryId;
        this.loading = true;
      });
    },
    getAllReviewByProductId() {
      ReviewAppService.getAllReviewByProductId(this.id).then(resp => {
        this.allReivews = resp.data;
        this.totalReviews = this.allReivews.length;
        this.averageStar(this.totalReviews);
      });
    },
    submitForm(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          ReviewAppService.postReview(this.reviews).then(resp => {
              this.allReivews.push(resp.data);
              this.totalReviews = this.allReivews.length;
              this.averageStar(this.totalReviews);
              this.$refs[formName].resetFields();
              this.$notify({
                title: "Thành công!",
                message: "Cảm ơn bạn đã đánh giá sản phẩm của chúng tôi",
                type: "success",
                offset: 100
              });
          });
        } else {
          this.$notify({
            title: "Không thành công!",
            message: "Đánh giá không thành công",
            type: "Error",
            offset: 100
          });
          return false;
        }
      });
    },
    averageStar(totalReivew) {
      var result = this.allReivews.reduce(function(tot, arr) {
        return tot + arr.reviewStar;
      }, 0);

      this.totalStars = parseFloat((result / totalReivew).toFixed(0));
    }
  }
};
</script>
<style scoped lang="scss">
.tableProduct{
    height: 268px;
    position: relative;
}
.summaryProduct{
    width: 100%;
    min-height: 100%;
    height: 100%;
    position: absolute;
    overflow: auto;
    transition:all 0.5s ease-in-out;
    tr{
      width: 100%;
      display: inline-table;
    }
    &::-webkit-scrollbar {
      width:  4px;
      height: 4px;
    }

    &::-webkit-scrollbar-thumb {
        background: #fff;
    }

    &::-webkit-scrollbar-track {
        background: #fff;
    }
    &:hover{
        transition:all 0.5s ease-in-out;
        &::-webkit-scrollbar-thumb {
        background: #a8a8a8;
        }

        &::-webkit-scrollbar-track {
            background: #fff;
        }
    }
    .summaryProductList{
        padding: 1rem;
    }
}
.btnCheckout{
  background-color: #f30;
  color: #fff;
  text-transform: uppercase;
  padding: 0.45rem 0.75rem;
  font-size: 0.8125rem;
  font-weight: 600;
  &:hover{
      background-color: #cc2900;
  }
}
.color-main{
  color: #f30;
}
.processCart{
  color: #0657a3;
  font-weight: 400;
  transition: 0.4s all;
  font-size: 0.9rem;

  &:hover{
    color: #f30;
  }
}
.fontSize13{
  font-size: 13px;
}
.productRemove{
  color: #888 !important;
  font-weight: 400;
  font-size: 13px;
}
.productCartTitle{
  color: #0657a3;
  font-weight: 600;
  transition: 0.4s all;
  font-size: 0.9rem;
  &:hover{
    color: #f30;
  }
}
.itemImage{
    border: 1px solid #d2d2d2;
    padding: 0.1rem;
}
.titleQuantityPopup{
  color: #0657a3;
  font-weight: 600;
  transition: 0.4s all;
  font-size: 1rem;
  &:hover{
    color: #f30;
  }
}


table { 
	width: 100%; 
	border-collapse: collapse; 
	margin:12px auto 2rem auto;
	}

  
th:nth-child(1) { 
    width: 55%;
}
  
th:nth-child(2),th:nth-child(3),th:nth-child(4) { 
  flex-grow: 1;
  max-width: 100%;
  text-align: center;
}

tr td { 
	padding: 10px; 
	border: 1px solid transparent; 
	text-align: left; 
  font-size: 12px;
  text-align: center;
  font-weight: 600; 
}

tr th { 
	background: #f7f7f7; 
	color: inherit; 
  font-weight: 600; 
  padding: 6px 5px;
  font-size: 13px !important;
  border: 1px solid #fff;
	}
/* 
Max width before this PARTICULAR table gets nasty
This query will take effect for any screen smaller than 760px
and also iPads specifically.
*/

</style>

