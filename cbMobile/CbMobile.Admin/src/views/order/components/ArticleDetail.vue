<template>
  <div class="createPost-container" v-if="!loading">
    <el-form ref="postForm" :model="postForm" :rules="rules" class="form-container">
      <div class="createPost-main-container">
        <el-row>
          <el-col :span="12">
            <label>Người mua</label>
            <el-row class="mt-3">
              <el-col :span="24">
                <el-form-item label="Mã đơn hàng" label-width="200px" class="text-left">
                  <span>#000{{postForm.id}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Họ và tên" label-width="200px" class="text-left">
                  <span>{{postForm.userName}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Email" label-width="200px" class="text-left">
                  <span>{{postForm.email}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Số điện thoại" label-width="200px" class="text-left">
                  <span>{{postForm.phoneNumber}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Địa chỉ" label-width="200px" class="text-left">
                  <span>{{postForm.address}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Phương thức thanh toán" label-width="200px" class="text-left">
                  <span>{{paymentEnumString[postForm.payment]}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row class="mb-3">
              <el-col :span="24">
                <el-form-item label="Nội dung" label-width="200px" class="text-left">
                  <span>{{postForm.content}}</span>
                </el-form-item>
              </el-col>
            </el-row>
          </el-col>
          <el-col :span="12">
            <label>Hóa đơn</label>
            <el-row class="mt-3">
              <el-col :span="24">
                <el-form-item label="Tổng giá trị" label-width="200px" class="text-left">
                  <span>{{formatPrice(postForm.totalBill)}}</span>
                </el-form-item>
              </el-col>
            </el-row>
            <el-row>
              <el-col :span="24">
                <el-form-item label="Trạng thái thanh toán" label-width="200px" class="text-left">
                  <toggle-button
                    @change="checkPayment(postForm.id,postForm.isPay)"
                    :disabled="postForm.isPay"
                    :value="postForm.isPay"
                    :sync="true"
                    :labels="true"
                    v-model="postForm.isPay"
                  />
                </el-form-item>
              </el-col>
            </el-row>
          </el-col>
        </el-row>
        <label >Chi tiết đơn hàng</label>
        <el-table
          class="mt-3"
          :data="listDetailBillItem"
          border
          style="width: 100%">
          <el-table-column
            prop="productName"
            label="Tên sản phẩm"
            width="250">
          </el-table-column>
          <el-table-column
            prop="colorName"
            label="Màu sắc"
            width="120">
          </el-table-column>
          <el-table-column
            prop="memoryName"
            label="Bộ nhớ"
            width="120">
          </el-table-column>
          <el-table-column
            label="Giá"
            width="180">
            <template slot-scope="scope">
              <span>{{ formatPrice(scope.row.price) }}</span>
            </template>
          </el-table-column>
          <el-table-column
            prop="amount"
            label="Số lượng"
            width="100">
          </el-table-column>
          <el-table-column
            label="Tổng tiền">
            <template slot-scope="scope">
              <span>{{ formatPrice(scope.row.totalPrice) }}</span>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </el-form>
  </div>
</template>

<script>
import Tinymce from "@/components/Tinymce";
import Upload from "@/components/Upload/SingleImage3";
import MDinput from "@/components/MDinput";
import Sticky from "@/components/Sticky";
import { validURL } from "@/utils/validate";
import {
  fetchArticle,
  fetchArticleItems,
  updateArticle,
  deleteArticle,
  isCheckPayment
} from "@/api/order";
import { fetchGetListDropdownCategoryBanner } from "@/api/categoryBanner";
import { PaymentEnumString } from "@/api/enum/enum";
import Warning from "./Warning";
import {
  CommentDropdown,
  PlatformDropdown,
  SourceUrlDropdown
} from "./Dropdown";

export default {
  name: "ArticleDetail",
  components: {
    Tinymce,
    MDinput,
    Upload,
    Sticky,
    Warning,
    CommentDropdown,
    PlatformDropdown,
    SourceUrlDropdown
  },
  props: {
    isEdit: {
      type: Boolean,
      default: false
    }
  },
  data() {
    const validateRequire = (rule, value, callback) => {
      if (value === "") {
        this.$message({
          message: "Xin vui lòng nhập tên",
          type: "error"
        });
        callback(new Error("Xin vui lòng nhập tên"));
      } else {
        callback();
      }
    };
    return {
      postForm: Object.assign({}),
      loading: false,
      userListOptions: [],
      categoryBannerListOptions: [],
      paymentEnumString:PaymentEnumString,
      listDetailBillItem:[],
      rules: {
        image_uri: [{ validator: validateRequire }],
        name: [{ validator: validateRequire }],
        content: [{ validator: validateRequire }]
      },
      tempRoute: {}
    };
  },
  computed: {
    contentShortLength() {
      return this.postForm.content_short.length;
    },
    displayTime: {
      // set and get is useful when the data
      // returned by the back end api is different from the front end
      // back end return => "2013-06-25 06:59:25"
      // front end need timestamp => 1372114765000
      get() {
        return +new Date(this.postForm.createdDate);
      },
      set(val) {
        this.postForm.createdDate = new Date(val);
      }
    }
  },
  created() {
    if (this.isEdit) {
      const id = this.$route.params && this.$route.params.id;
      this.fetchData(id);
      this.fetchArticleItems(id);
    } else {
      this.postForm = Object.assign({});
    }
    this.tempRoute = Object.assign({}, this.$route);
    // this.fetchGetListDropdownCategoryBanner();
  },
  methods: {
    checkPayment(id,value){
      isCheckPayment(id,value).then(resp => {
        console.log(resp)
        if(resp){
          this.$message({
            type: "success",
            message: "Đã than toán"
          });
        }
      })
    },
    formatPrice(value) {
      let val = (value / 1).toFixed(0).replace(".", ",");
      return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "₫";
    },
    fetchData(id) {
      this.loading = true;
      fetchArticle(id)
        .then(response => {
          this.postForm = response;
        })
        .catch(err => {
          console.log(err);
        }).finally(()=>{
          this.loading = false;
        });
    },
    fetchArticleItems(id){
      fetchArticleItems(id).then(response => {
        console.log(response)
        this.listDetailBillItem = response
      })
      .catch(err => {
        console.log(err)
      })
    },
    // submitForm() {
    //   this.$refs.postForm.validate(valid => {
    //     if (valid) {
    //       createArticle(this.postForm).then(resp => {
    //         if (resp) {
    //           this.loading = true;
    //           this.$notify({
    //             title: "Lưu",
    //             message: "Đã lưu",
    //             type: "success",
    //             duration: 2000
    //           });
    //           this.$router.push("/banner/list");
    //           this.loading = false;
    //         } else console.log("error submit!!");
    //       });
    //     } else {
    //       console.log("error submit!!");
    //       return false;
    //     }
    //   });
    // },
    // fetchGetListDropdownCategoryBanner() {
    //   fetchGetListDropdownCategoryBanner()
    //     .then(response => {
    //       this.categoryBannerListOptions = response;
    //     })
    //     .catch(err => {
    //       console.log(err);
    //     });
    // },
    updateForm() {
      this.$refs.postForm.validate(valid => {
        if (valid) {
          updateArticle(this.postForm).then(resp => {
            if (resp) {
              this.loading = true;
              this.$notify({
                title: "Chỉnh sửa",
                message: "Đã chỉnh sửa",
                type: "success",
                duration: 2000
              });
              this.$router.go(-1);
              this.loading = false;
            }
            return false;
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    draftForm() {
      this.$confirm("Bạn có chắc chắn muốn xóa. Tiếp tục?", "Cảnh báo", {
        confirmButtonText: "OK",
        cancelButtonText: "Cancel",
        type: "warning",
        center: true
      })
        .then(() => {
          deleteArticle(this.postForm.id).then(resp => {
            console.log("delêt");
            if (resp) {
              this.$message({
                type: "success",
                message: "Đã xóa"
              });
              this.$router.go(-1);
            } else {
              console.log("error update!!");
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "Chưa xóa"
          });
        });
    },
    getRemoteUserList(query) {
      searchUser(query).then(response => {
        if (!response.data.items) return;
        this.userListOptions = response.data.items.map(v => v.name);
      });
    }
  }
};
</script>

<style lang="scss" scoped>
@import "~@/styles/mixin.scss";
.mb-3{
  margin-bottom: 1rem;
}
.mt-3{
  margin-top: 1rem;
}
.el-form-item{
  margin-bottom: 0 !important;
}
.createPost-container {
  position: relative;

  .createPost-main-container {
    padding: 40px 45px 20px 50px;

    .postInfo-container {
      position: relative;
      @include clearfix;
      margin-bottom: 10px;

      .postInfo-container-item {
        float: left;
      }
    }
  }

  .word-counter {
    width: 40px;
    position: absolute;
    right: 10px;
    top: 0px;
  }
}

.article-textarea /deep/ {
  textarea {
    padding-right: 40px;
    resize: none;
    border: none;
    border-radius: 0px;
    border-bottom: 1px solid #bfcbd9;
  }
}
</style>
