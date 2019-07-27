<template>
  <div class="container">
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
              v-model="rating"
              v-bind:increment="0.5"
              v-bind:star-size="15"
            ></star-rating>
          </span>
          <span class="ml-lg-2">Đánh giá sản phẩm</span>
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
                <h2 class="color-red font-weight-500">{{products.value}}</h2>
                <p>
                  <span>Giá thị trường:</span>
                  <span class="text-decoration font-weight-500">23.500.000đ</span>
                </p>
                <p>
                  <span class="font-weight-500">Tình trạng:</span>
                  <span class="color-green">Còn hàng</span>
                </p>
                <p class>
                  <span class="font-weight-bold">Dung lượng:</span>
                </p>
                <div class="customRadio">
                  <div>
                    <el-radio-group v-model="radio">
                      <el-radio :label="3">Option A</el-radio>
                      <el-radio :label="6">Option B</el-radio>
                      <el-radio :label="9">Option C</el-radio>
                    </el-radio-group>
                  </div>
                </div>
                <p class>
                  <span class="font-weight-bold">Màu sắc:</span>
                </p>
                <div class="customRadio mb-lg-3">
                  <div>
                    <el-radio-group v-model="radio">
                      <el-radio :label="3">Option A</el-radio>
                      <el-radio :label="6">Option B</el-radio>
                    </el-radio-group>
                  </div>
                </div>
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
          <div class="col-lg-9">
            <el-tabs v-model="activeName">
              <el-tab-pane label="Mô tả" name="first">
                <div class="full-description" v-html="products.fullDescription"></div>
              </el-tab-pane>
              <el-tab-pane label="Nhận xét sản phẩm" name="second">Đánh giá sản phẩm</el-tab-pane>
            </el-tabs>
          </div>
        </div>
      </div>
      <GenericProduct :categoryProductId="categoryProductId"></GenericProduct>
    </div>
  </div>
</template>
<script>
import ProductAppService from "../api/product";
import GenericProduct from "../components/GenericProduct";
export default {
  components: {
    GenericProduct
  },
  data() {
    return {
      id: this.$route.params.id,
      products: [],
      gender: [],
      categoryProductId: Number,
      radio: 3,
      rating: 3,
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
  methods: {
    getDetailProduct(id) {
      ProductAppService.getDetailProduct(this.id).then(resp => {
        this.products = resp.data;
        this.categoryProductId = this.products.categoryProductId;
      });
    }
  },
  created() {
    this.getDetailProduct(this.id);
  },
  mounted() {
    this.getDetailProduct(this.id);
  }
};
</script>

