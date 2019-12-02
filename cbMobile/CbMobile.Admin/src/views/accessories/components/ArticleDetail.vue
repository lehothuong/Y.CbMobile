<template>
  <div class="createPost-container">
    <el-form ref="postForm" v-if="!loading" :model="postForm" :rules="rules" class="form-container">
      <sticky :z-index="10" :class-name="'sub-navbar '+postForm.published">
        <el-button
          v-if="!this.isEdit"
          v-loading="loading"
          style="margin-left: 10px;"
          type="success"
          @click="submitForm"
        >Lưu</el-button>
        <el-button
          v-if="this.isEdit"
          v-loading="loading"
          style="margin-left: 10px;"
          type="warning"
          @click="updateForm"
        >Chỉnh sửa và lưu</el-button>
        <el-button v-if="this.isEdit" v-loading="loading" type="danger" @click="draftForm">Xóa</el-button>
      </sticky>

      <div class="createPost-main-container">
        <el-row>
          <el-col :span="12">
            <el-form-item label="Kích hoạt" label-width="120px" class="text-left">
              <toggle-button
                :value="postForm.published"
                :sync="true"
                :labels="true"
                v-model="postForm.published"
              />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Sắp xếp" label-width="120px" class="text-left">
              <el-input v-model="postForm.displayOrder" placeholder="Sắp xếp" :maxlength="100"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
         <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Sản phẩm" class="text-left">
              <el-select
                v-model="postForm.productId"
                filterable
                default-first-option
                remote
                placeholder="Sản phẩm"
              >
                <el-option
                  v-for="(item,index) in productListOptions"
                  :key="item+index"
                  :label="item.name"
                  :value="item.id"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Bộ nhớ" class="text-left">
              <el-select
                v-model="postForm.mainMemoryId"
                filterable
                default-first-option
                remote
                placeholder="Bộ nhớ"
              >
                <el-option
                  v-for="(item,index) in mainMemoryListOptions"
                  :key="item+index"
                  :label="item.name"
                  :value="item.id"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
         <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Màu sắc" class="text-left">
              <el-select
                v-model="postForm.mainColorId"
                filterable
                default-first-option
                remote
                placeholder="Màu sắc"
              >
                <el-option
                  v-for="(item,index) in mainColorListOptions"
                  :key="item+index"
                  :label="item.name"
                  :value="item.id"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Giá thị trường" label-width="120px" class="text-left">
              <div class="el-input el-input--medium">
                <cleave v-model="postForm.value" placeholder="Nhập giá" class="el-input__inner" :options="options.number"></cleave>
              </div>
            </el-form-item>
          </el-col>
        </el-row>
        <!-- <el-row>
          <el-col :span="12">
            <el-form-item label="Giá khuyến mãi" label-width="120px" class="text-left">
              <div class="el-input el-input--medium">
                <cleave
                  placeholder="Nhập giá"
                  v-model="postForm.valuePromotion"
                  class="el-input__inner"
                  :options="options.number"
                ></cleave>
              </div>
            </el-form-item>
          </el-col>
        </el-row> -->
        
      </div>
    </el-form>
  </div>
</template>

<script>
import Sticky from "@/components/Sticky";
import { validURL } from "@/utils/validate";
import {
  fetchArticle,
  createArticle,
  updateArticle,
  deleteArticle
} from "@/api/accessories";
import { fetchGetListDropdownProduct } from "@/api/product";
import { getListDropdownMainMemory } from "@/api/mainMemory";
import { getListDropdownMainColor } from "@/api/mainColor";
import { searchUser } from "@/api/remote-search";
import Warning from "./Warning";
import {
  CommentDropdown,
  PlatformDropdown,
  SourceUrlDropdown
} from "./Dropdown";

const defaultForm = {
  name: ""
};

export default {
  name: "ArticleDetail",
  components:{
    Sticky,
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
      postForm: Object.assign({}, defaultForm),
      loading: false,
      productListOptions:[],
      mainMemoryListOptions:[],
      mainColorListOptions:[],
       rules: {
        name: [{ validator: validateRequire }],
      },
      options: {
        number: {
          numeral: true,
          numeralPositiveOnly: true,
          noImmediatePrefix: true,
          rawValueTrimPrefix: true,
          numeralIntegerScale: 9,
          numeralDecimalScale: 2
        }
      }
    };
  },
  computed: {
    contentShortLength() {
      return this.postForm.content_short.length;
    },
  },
  created() {
    if (this.isEdit) {
      const id = this.$route.params && this.$route.params.id;
      this.fetchData(id);
    } else {
      this.postForm = Object.assign({}, defaultForm);
    }
    this.fetchGetListDropdownProduct();
    this.getListDropdownMainMemory();
    this.getListDropdownMainColor();
  },
  
  methods: {
    fetchData(id) {
      this.loading=true;
      fetchArticle(id)
        .then(response => {
          this.postForm = response;
        })
        .catch(err => {
          console.log(err);
        }).finally(()=>{
          this.loading=false;
        });
    },
    fetchGetListDropdownProduct(){
      fetchGetListDropdownProduct().then(resp => {
        this.productListOptions = resp;
      }).catch(errs => {
        console.log(errs);
      })
    },
    getListDropdownMainMemory(){
      getListDropdownMainMemory().then(resp => {
        this.mainMemoryListOptions = resp;
      }).catch(errs => {
        console.log(errs);
      })
    },
    getListDropdownMainColor(){
      getListDropdownMainColor().then(resp => {
        this.mainColorListOptions = resp;
      }).catch(errs => {
        console.log(errs);
      })
    },
    submitForm() {
      this.$refs.postForm.validate(valid => {
        if (valid) {
          createArticle(this.postForm).then(resp => {
            if (resp) {
              this.loading = true;
              this.$notify({
                title: "Lưu",
                message: "Đã lưu",
                type: "success",
                duration: 2000
              });
              this.$router.push("/accessories/list");
              this.loading = false;
            } else console.log("error submit!!");
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
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
            if (resp) {
              this.$message({
                type: "success",
                message: "Đã xóa"
              });
              this.$router.push({
                path: this.redirect || "/ac/list"
              });
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
      })
    }
  }
};
</script>

<style lang="scss" scoped>
@import "~@/styles/mixin.scss";

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
