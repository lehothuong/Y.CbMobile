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
                <div class="d-flex justify-content-between">
                  <p>
                    <span>Giá thị trường:</span>
                    <span class="text-decoration font-weight-500">{{formatPrice(products.value)}}</span>
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
                    <el-radio-group v-for="(item,index) in listMemory" :key="index" v-model="rom">
                      <el-radio-button :label="item.name"></el-radio-button>
                    </el-radio-group>
                  </div>
                </div>

                <p class>
                  <span class="font-weight-bold">Màu sắc:</span>
                </p>
                <!-- <div class="customRadio mb-lg-3">
                  <div>
                    <el-radio-group
                      v-for="(item,index) in convertStringToArrayColor"
                      :key="index"
                      v-model="checkColor"
                    >
                      <el-radio-button :label="item"></el-radio-button>
                    </el-radio-group>
                  </div>
                </div>-->
                <div class="shoppingProduct d-flex w-100">
                  <div
                    class="totalProduct d-flex w-40 justify-content-between font-weight-500 align-items-center"
                  >
                    <button class="btn btnPlus" type="button">-</button>
                    <span>1</span>
                    <button class="btn btnPlus" type="button">+</button>
                  </div>
                  <div class="checkProduct w-60">
                    <button class="btn btnCheck text-uppercase font-weight-500">
                      <i class="fa fa-cart-arrow-down mr-2" aria-hidden="true"></i>
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
      <GenericProduct :categoryProductId="categoryProductId"></GenericProduct>
    </div>
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
import GenericProduct from "../components/GenericProduct";
export default {
  components: {
    GenericProduct
  },
  data() {
    return {
      id: this.$route.params.id,
      totalReviews: 0,
      totalStars: 0,
      priceSavings: 0,
      loading: true,
      rom: "",
      checkColor: "",
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
      }
    };
  },
  mounted() {
    this.getDetailProduct();
    this.getAllReviewByProductId();
  },
  beforeDestroy() {
    this.getAllReviewByProductId();
  },
  computed: {
    // convertStringToArray() {
    //   return this.mainMemory.split(",");
    // }
    // convertStringToArrayColor() {
    //   return this.color.split(",");
    // }
  },
  methods: {
    formatPrice(value) {
      let val = (value / 1).toFixed(0).replace(".", ",");
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "₫";
    },
    getDetailProduct() {
      this.loading = false;
      ProductAppService.getDetailProduct(this.id).then(resp => {
        this.products = resp.data;
        this.listMemory = this.products.listMemory;
        this.color = this.products.color;
        this.categoryProductId = this.products.categoryProductId;
        this.priceSavings = this.products.value - this.products.valuePromotion;
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
            this.$notify({
              title: "Thành công!",
              message: "Cảm ơn bạn đã đánh giá sản phẩm của chúng tôi",
              type: "success",
              offset: 100
            });
            this.$refs[formName].resetFields();
          });
        } else {
          this.$notify({
            title: "Không thành công!",
            message: "Đánh giá không thành công",
            title: "Error",
            offset: 100
          });
          return false;
        }
      });
    },
    averageStar(totalReivew) {
      var result = this.allReivews.reduce(function(tot, arr) {
        // return the sum with previous value
        return tot + arr.reviewStar;
      }, 0);

      this.totalStars = parseFloat((result / totalReivew).toFixed(0));
    }
  }
};
</script>

