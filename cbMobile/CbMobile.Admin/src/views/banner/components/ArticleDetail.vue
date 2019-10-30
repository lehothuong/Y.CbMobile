<template>
  <div class="createPost-container" v-loading="loading">
    <el-form ref="postForm" :model="postForm" :rules="rules" class="form-container">
      <sticky :z-index="10" :class-name="'sub-navbar '+postForm.published">
        <!-- <CommentDropdown v-model="postForm.comment_disabled" />
        <PlatformDropdown v-model="postForm.platforms" />
        <SourceUrlDropdown v-model="postForm.source_uri" />-->
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
            <el-form-item label-width="120px" label="Loại" class="text-left">
              <el-select
                v-model="postForm.categoryId"
                filterable
                default-first-option
                remote
                placeholder="Loại"
              >
                <el-option
                  v-for="(item,index) in categoryBannerListOptions"
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
            <el-form-item label="Ảnh banner" label-width="120px" class="text-left">
              <el-input v-model="postForm.bannerUrl" placeholder="Ảnh banner"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <el-row>
          <el-col :span="12">
            <el-form-item label="Liên kết" label-width="120px" class="text-left">
              <el-input v-model="postForm.url" placeholder="Liên kết"></el-input>
            </el-form-item>
          </el-col>
        </el-row>
        <!-- <el-form-item style="margin-bottom: 40px;" label-width="70px" label="Summary:">
          <el-input v-model="postForm.content_short" :rows="1" type="textarea" class="article-textarea" autosize placeholder="Please enter the content" />
          <span v-show="contentShortLength" class="word-counter">{{ contentShortLength }}words</span>
        </el-form-item>

        <el-form-item prop="content" style="margin-bottom: 30px;">
          <Tinymce ref="editor" v-model="postForm.content" :height="400" />
        </el-form-item>

        <el-form-item prop="image_uri" style="margin-bottom: 30px;">
          <Upload v-model="postForm.image_uri" />
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
} from "@/api/banner";
import { fetchGetListDropdownCategoryBanner } from "@/api/categoryBanner";
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
    } else {
      this.postForm = Object.assign({});
    }
    this.tempRoute = Object.assign({}, this.$route);
    this.fetchGetListDropdownCategoryBanner();
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
        });
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
              this.$router.push("/banner/list");
              this.loading = false;
            } else console.log("error submit!!");
          });
        } else {
          console.log("error submit!!");
          return false;
        }
      });
    },
    fetchGetListDropdownCategoryBanner() {
      fetchGetListDropdownCategoryBanner()
        .then(response => {
          this.categoryBannerListOptions = response;
        })
        .catch(err => {
          console.log(err);
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
