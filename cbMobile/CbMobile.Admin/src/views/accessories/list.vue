<template>
  <div class="app-container">
    <div class="mb-4">
      <el-row >
        <el-col class="align-right" :span="24">
        <router-link :to="'/accessories/create'">
          <el-button  type="success" size="small" icon="el-icon-circle-plus-outline">Tạo</el-button>
        </router-link>
        </el-col>
      </el-row>
    </div>
    <el-table v-loading="listLoading" :data="list" fit highlight-current-row style="width: 100%">
      <el-table-column width="350" align="center" label="Sản phẩm">
        <template slot-scope="scope">
          <span>{{ scope.row.productName }}</span>
        </template>
      </el-table-column>
      <el-table-column width="120" align="center" label="Màu sắc">
        <template slot-scope="scope">
          <span>{{ scope.row.mainColorName }}</span>
        </template>
      </el-table-column>
      <el-table-column width="120" align="center" label="Bộ nhớ">
        <template slot-scope="scope">
          <span>{{ scope.row.mainMemoryName }}</span>
        </template>
      </el-table-column>
      <el-table-column width="120" align="center" label="Sắp xếp">
        <template slot-scope="scope">
          <span>{{ scope.row.displayOrder }}</span>
        </template>
      </el-table-column>
      <el-table-column width="150" align="center" label="Ngày tạo">
        <template slot-scope="scope">
          <span>{{ scope.row.createdDate | parseTime('{d}-{m}-{y}') }}</span>
        </template>
      </el-table-column>
      <el-table-column align="center" label="Actions" width="160" fixed="right">
        <template slot-scope="scope">
          <div class="row">
            <router-link class="mr-3" :to="'/accessories/edit/'+scope.row.id">
              <el-button type="primary" size="small" icon="el-icon-edit">Edit</el-button>
            </router-link>
            <el-button
              type="danger"
              size="small"
              icon="el-icon-delete"
              @click="draftForm(scope.row.id)"
            >Xóa</el-button>
          </div>
        </template>
      </el-table-column>
    </el-table>

    <pagination
      v-show="total>0"
      :total="total"
      background
      :page.sync="listQuery.page"
      :limit.sync="listQuery.limit"
      layout="prev, pager, next"
      @pagination="getList"
    />
  </div>
</template>

<script>
import { fetchList, deleteArticle } from "@/api/accessories";
import Pagination from "@/components/Pagination"; // Secondary package based on el-pagination

export default {
  name: "Accessories",
  components: { Pagination },
  filters: {
    statusFilter(status) {
      const statusMap = {
        published: "success",
        draft: "info",
        deleted: "danger"
      };
      return statusMap[status];
    }
  },
  data() {
    return {
      list: [],
      total: 0,
      listLoading: true,
      listQuery: {
        page: 1,
        limit: 10
      }
    };
  },
  created() {
    this.getList();
  },
  methods: {
    draftForm(id) {
      this.$confirm("Bạn có chắc chắn muốn xóa. Tiếp tục?", "Cảnh báo", {
        confirmButtonText: "OK",
        cancelButtonText: "Cancel",
        type: "warning",
        center: true
      })
        .then(() => {
          deleteArticle(id).then(resp => {
            if (resp) {
              this.$message({
                type: "success",
                message: "Đã xóa"
              });
              this.getList();
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
    getList() {
      this.listLoading = true;
      fetchList(this.listQuery).then(response => {
        console.log(response)
        this.list = response.data;
        this.total = response.totalCount;
        this.listLoading = false;
      });
    }
  }
};
</script>

<style scoped>
.edit-input {
  padding-right: 100px;
}
.cancel-btn {
  position: absolute;
  right: 15px;
  top: 10px;
}
</style>
