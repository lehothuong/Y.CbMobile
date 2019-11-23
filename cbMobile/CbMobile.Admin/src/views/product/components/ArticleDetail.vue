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
            <el-form-item label="Trạng thái" label-width="120px" class="text-left">
              <toggle-button
                :value="postForm.status"
                :sync="true"
                :labels="true"
                v-model="postForm.status"
              />
            </el-form-item>
          </el-col>
        </el-row>
        <span class="notice">(Chỉ lấy 6 sản phẩm hot)</span>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Hot" label-width="120px" class="text-left">
              <toggle-button
                :value="postForm.hot"
                :sync="true"
                :labels="true"
                v-model="postForm.hot"
              />
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Nhà sản xuất" class="text-left">
              <el-select
                v-model="postForm.manufacturerId"
                filterable
                default-first-option
                remote
                placeholder="Nhà sản xuất"
              >
                <el-option
                  v-for="(item,index) in manufacturerListOptions"
                  :key="item+index"
                  :label="item.name"
                  :value="item.id"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row>
        <!-- <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Dung lượng" class="text-left">
              <el-select v-model="postForm.listMemory" multiple placeholder="Dung lượng">
                <el-option
                  v-for="item in mainMemoryListOptions"
                  :key="item.value"
                  :label="item.text"
                  :value="item.value"
                />
              </el-select>
            </el-form-item>
          </el-col>
        </el-row> -->
        <el-row>
          <el-col :span="12">
            <el-form-item label-width="120px" label="Loại" class="text-left">
              <el-select
                v-model="postForm.categoryProductId"
                filterable
                default-first-option
                remote
                placeholder="Loại"
              >
                <el-option
                  v-for="(item,index) in categoryProductListOptions"
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
            <el-form-item label="Tên" label-width="120px" class="text-left">
              <el-input v-model="postForm.name" placeholder="Tên" :maxlength="100"></el-input>
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
            <el-form-item label="Link hình ảnh" label-width="120px" class="text-left">
              <el-input v-model="postForm.avatarUrl" placeholder="Link hình ảnh"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Giá thị trường" label-width="120px" class="text-left">
              <div class="el-input el-input--medium">
                <cleave v-model="postForm.value" class="el-input__inner" :options="options.number"></cleave>
              </div>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Giá khuyến mãi" label-width="120px" class="text-left">
              <div class="el-input el-input--medium">
                <cleave
                  v-model="postForm.valuePromotion"
                  class="el-input__inner"
                  :options="options.number"
                ></cleave>
              </div>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="24">
            <el-form-item label="Mô tả ngắn" label-width="120px" class="text-left">
              <el-input
                type="textarea"
                v-model="postForm.shortDescription"
                placeholder="Mô tả ngắn"
                :maxlength="300"
                required
              ></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="24">
            <el-form-item
              label="Mô tả dài"
              label-width="120px"
              class="text-left"
              style="margin-bottom: 30px;"
            >
              <Tinymce ref="editor" v-model="postForm.fullDescription" :height="300" />
            </el-form-item>
          </el-col>
        </el-row>
        <!-- <el-form-item style="margin-bottom: 40px;" label-width="70px" label="Summary:">
          <el-input v-model="postForm.fullDescription" :rows="1" type="textarea" class="article-textarea" autosize placeholder="Please enter the content" />
          <span v-show="postForm.fullDescription" class="word-counter">{{ postForm.fullDescription }}</span>
        </el-form-item>-->

        <!--<el-form-item prop="image_uri" style="margin-bottom: 30px;">
          <Upload v-model="postForm.avatarUrl" />
        </el-form-item>-->
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
  createArticle,
  updateArticle,
  deleteArticle
} from "@/api/product";
import { fetchListDropdownManufacturer } from "@/api/manufacturer";
import { fetchGetListDropdownCategoryProduct } from "@/api/categoryProduct";
// import { getListDropdownMainMemory } from "@/api/mainMemory";
import { searchUser } from "@/api/remote-search";
import Warning from "./Warning";
import {
  CommentDropdown,
  PlatformDropdown,
  SourceUrlDropdown
} from "./Dropdown";

const defaultForm = {
  name: "",
  id: undefined,
  value: 0,
  valuePromotion: 0
};

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
    const validateRequireInt = (rule, value, callback) => {
      if (value === "") {
        this.$message({
          message: "Xin vui lòng nhập giá",
          type: "error"
        });
        callback(new Error("Xin vui lòng nhập giá"));
      } else {
        callback();
      }
    };
    return {
      postForm: Object.assign({}, defaultForm),
      loading: false,
      total: 0,
      userListOptions: [],
      manufacturerListOptions: [],
      // mainMemoryListOptions: [],
      categoryProductListOptions: [],
      mainMemorys: [],
      rules: {
        image_uri: [{ validator: validateRequire }],
        name: [{ validator: validateRequire }],
        value: [{ validator: validateRequire }]
      },
      tempRoute: {},
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
    displayTime: {
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
    } else {
      this.postForm = Object.assign({}, defaultForm);
    }
    this.tempRoute = Object.assign({}, this.$route);
    this.fetchListDropdownManufacturer();
    this.fetchGetListDropdownCategoryProduct();
    // this.getListDropdownMainMemory();
  },
  methods: {
    fetchData(id) {
      this.loading = true;
      fetchArticle(id)
        .then(response => {
          this.postForm = response;
          this.loading = false;
        })
        .catch(err => {
          console.log(err);
        }).finally(()=>{
          this.loading = false;
        });
    },
    fetchListDropdownManufacturer() {
      fetchListDropdownManufacturer()
        .then(response => {
          this.manufacturerListOptions = response;
        })
        .catch(err => {
          console.log(err);
        });
    },
    fetchGetListDropdownCategoryProduct() {
      fetchGetListDropdownCategoryProduct()
        .then(response => {
          this.categoryProductListOptions = response;
        })
        .catch(err => {
          console.log(err);
        });
    },
    // getListDropdownMainMemory() {
    //   getListDropdownMainMemory()
    //     .then(response => {
    //       this.mainMemoryListOptions = response;
    //     })
    //     .catch(err => {
    //       console.log(err);
    //     });
    // },
    submitForm() {
      this.$refs.postForm.validate(valid => {
        //Array to string list id [1,2,3,4] => 1,2,3,4
        this.postForm.mainMemory = this.postForm.listMemory.join(",");
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
              this.$router.push("/product/list");
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
        this.postForm.mainMemory = this.postForm.listMemory.join(",");
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
                path: this.redirect || "/category-product/list"
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
      });
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
