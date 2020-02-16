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
        <!-- <el-row>
          <el-col :span="12">
            <el-form-item label="Giá thị trường" label-width="120px" class="text-left">
              <div class="el-input el-input--medium">
                <cleave v-model="postForm.value" class="el-input__inner" :options="options.number"></cleave>
              </div>
            </el-form-item>
          </el-col>
        </el-row> -->
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
        <div v-if="isEdit">
          <label class="d-block mb-4">Thông số kỹ thuật</label>
          <el-button class="mb-4" @click="handleCreateDialog()" type="success" size="small" icon="el-icon-circle-plus-outline">Thêm mới</el-button>
          <el-dialog @closed="handleCancel('postSpecification')" title="Thông số kỹ thuật" :visible.sync="dialogVisible">
            <el-form ref="postSpecification" :model="postSpecification" :rules="ruleSpecifications">
              <el-form-item prop="specificationId" label="Thông số" label-width="85px" v-if="isShowList">
                <el-select
                  v-model="postSpecification.specificationId"
                  filterable
                  default-first-option
                  placeholder="Thông số kỹ thuật"
                >
                  <el-option
                    v-for="(item,index) in specificationExtend"
                    :key="item+index"
                    :label="item.name"
                    :value="item.id"
                  />
                </el-select>
              </el-form-item>
              <el-form-item prop="content" label="Nội dung" label-width="85px" class="content">
                <el-input
                  v-model="postSpecification.content"
                  placeholder="Nội dung"
                  maxlength="100"
                  required
                ></el-input>
              </el-form-item>
              <el-form-item label="Sắp xếp" label-width="85px" class="content">
                <el-input v-model="postSpecification.displayOrder" placeholder="Sắp xếp" maxlength="100"></el-input>
              </el-form-item>
              <!-- <el-form-item label="Promotion name" :label-width="formLabelWidth">
                <el-input autocomplete="off"></el-input>
              </el-form-item> -->
            </el-form>
            <span slot="footer" class="dialog-footer">
              <el-button @click="handleCancel('postSpecification')">Hủy</el-button>
              <el-button type="primary" @click="handleSpecification()">Lưu</el-button>
            </span>
          </el-dialog>
          
          <el-table
            class="mt-3"
            :data="listDetailSpecification"
            border
            style="width: 100%">
            <el-table-column
              prop="specificationName"
              label="Tên thông số"
              width="250">
              <template slot-scope="scope">
                <a @click="handleDialog(scope.row.id, postForm.id, scope.row.specificationId)">
                  <span class="color-primary">{{ scope.row.specificationName }}</span>
                </a>
              </template>
            </el-table-column>
            <el-table-column
              prop="content"
              label="Nội dung"
              width="250">
            </el-table-column>
            <el-table-column
              prop="displayOrder"
              label="Sắp xếp"
              width="250">
            </el-table-column>
            <el-table-column align="center" label="Actions" fixed="right">
              <template slot-scope="scope">
                <div class="row">
                  <el-button
                    type="danger"
                    size="small"
                    icon="el-icon-delete"
                    @click="deleteDetailSpecification(scope.row.id, scope.row.specificationId)"
                  >Xóa</el-button>
                </div>
              </template>
          </el-table-column>
          </el-table>
        </div>
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
import {
  fetchGetListDropdownSpecification,
  createSpecification,
  getAllSpecificationById,
  getSpecificationById,
  updateDetailSpecification,
  deleteDetailSpecification
} from "@/api/specification";
import { fetchListDropdownManufacturer } from "@/api/manufacturer";
import { fetchGetListDropdownCategoryProduct } from "@/api/categoryProduct";
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

const defaultFormDetailSpecification = {
  productId:undefined,
  specificationId:undefined,
  content:''
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
      postSpecification:{
        productId:undefined,
        specificationId:undefined,
        content:''
      },
      isShowList:true,
      loading: false,
      dialogVisible: false,
      total: 0,
      listSpecification:[],
      userListOptions: [],
      manufacturerListOptions: [],
      listDetailSpecification:[],
      // mainMemoryListOptions: [],
      categoryProductListOptions: [],
      mainMemorys: [],
      rules: {
        image_uri: [{ validator: validateRequire }],
        name: [{ validator: validateRequire }],
        value: [{ validator: validateRequire }]
      },
      ruleSpecifications:{
        specificationId: [
          { required: true, message: 'Vui lòng chọn thông số kỹ thuật', trigger: 'blur' }
        ],
        content: [
          { required: true, message: 'Vui lòng nhập nọi dung', trigger: 'blur' }
        ],
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
    specificationExtend(){
      return this.listSpecification.filter(spec=> !this.listDetailSpecification.some(e => e.specificationId === spec.id))
    },
    
  },
  created() {
    this.tempRoute = Object.assign({}, this.$route);
    this.fetchListDropdownManufacturer();
    this.fetchGetListDropdownCategoryProduct();
    this.fetchGetListDropdownSpecification();
    if (this.isEdit) {
      const id = this.$route.params && this.$route.params.id;
      this.fetchData(id);
      this.getAllSpecificationById(id);
    } else {
      this.postForm = Object.assign({}, defaultForm);
    }
    // this.getListDropdownMainMemory();
  },
  methods: {
    handleCancel(formName){
      this.dialogVisible = false;
      this.$refs[formName].resetFields();
    },
    handleCreateDialog(){
      this.isShowList = true,
      this.dialogVisible = true;
      this.postSpecification = Object.assign({},defaultFormDetailSpecification)
    },
    handleDialog(id, productId, specificationId){
      this.isShowList = false;
        getSpecificationById(id, productId, specificationId).then(resp => {
          this.postSpecification = resp
          this.dialogVisible = true
        })
    },
    handleSpecification() {
      this.$refs.postSpecification.validate(valid => {
        if(valid){
          this.postSpecification.productId = this.postForm.id;
          if(this.isShowList){
            this.dialogVisible = false;
            createSpecification(this.postSpecification).then(resp => {
              if(resp){
                this.$notify({
                  title: "Lưu",
                  message: "Đã lưu",
                  type: "success",
                  duration: 100
                });
              }
              this.getAllSpecificationById(this.postForm.id);
            });
          }
          else{
            updateDetailSpecification(this.postSpecification).then(resp => {
              if(resp){
                this.$notify({
                  title: "Lưu",
                  message: "Đã lưu",
                  type: "success",
                  duration: 100
                });
              }
              this.getAllSpecificationById(this.postForm.id);
            });
          }
        }
        
      })
      
    },
    
    getAllSpecificationById(id) {
      //debugger
      this.loading = true;
      this.fetchListDropdownManufacturer()
      getAllSpecificationById(id)
        .then(response => {
          this.listDetailSpecification = response;
          this.loading = false;
        })
        .catch(err => {
          console.log(err);
        })
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
    fetchListDropdownManufacturer() {
      fetchListDropdownManufacturer()
        .then(response => {
          this.manufacturerListOptions = response;
        })
        .catch(err => {
          console.log(err);
        });
    },
    fetchGetListDropdownSpecification(){
      fetchGetListDropdownSpecification()
      .then(response => {
        this.listSpecification = response
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
    deleteDetailSpecification(id,specId) {
      this.$confirm("Bạn có chắc chắn muốn xóa. Tiếp tục?", "Cảnh báo", {
        confirmButtonText: "OK",
        cancelButtonText: "Cancel",
        type: "warning",
        center: true
      })
        .then(() => {
          deleteDetailSpecification(id, this.postForm.id, specId).then(resp => {
            if (resp) {
              this.$message({
                type: "success",
                message: "Đã xóa"
              });
            } else {
              console.log("error update!!");
            }
            this.getAllSpecificationById(this.postForm.id);
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

.color-primary{
  color: #1890ff;
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
.d-block{
  display: block;
}
</style>
