<template>
  <div class="app-container">
    <el-table v-loading="listLoading" :data="list" fit highlight-current-row style="width: 100%">
      <el-table-column width="100" align="center" label="Thanh Toán">
        <template slot-scope="scope">
          <span>
            <el-checkbox :disabled="scope.row.isPay" @change="checkPayment(scope.row.id,scope.row.isPay)" v-model="scope.row.isPay"></el-checkbox>
          </span>
        </template>
      </el-table-column>
      <el-table-column width="150" align="center" label="Mã đơn hàng">
        <template slot-scope="scope">
          <router-link :to="'/order/edit/'+scope.row.id">
            <span class="color-primary">#000{{ scope.row.id }}</span>
          </router-link>
        </template>
      </el-table-column>
      <el-table-column width="150" align="center" label="Họ và tên">
        <template slot-scope="scope">
          <span>{{ scope.row.userName }}</span>
        </template>
      </el-table-column>
      <el-table-column width="220" align="center" label="Email">
        <template slot-scope="scope">
          <span>{{ scope.row.email }}</span>
        </template>
      </el-table-column>
      <el-table-column width="150" align="center" label="Phone">
        <template slot-scope="scope">
          <span>{{ scope.row.phoneNumber }}</span>
        </template>
      </el-table-column>
       <el-table-column width="150" align="center" label="Địa chỉ">
        <template slot-scope="scope">
          <span>{{ scope.row.address }}</span>
        </template>
      </el-table-column>
      <el-table-column width="220" align="center" label="Nội dung">
        <template slot-scope="scope">
          <span>{{ scope.row.content }}</span>
        </template>
      </el-table-column>
      <el-table-column width="220" align="center" label="Phương thức thanh toán">
        <template slot-scope="scope">
          <span>{{ paymentEnumString[scope.row.payment] }}</span>
        </template>
      </el-table-column>
      <el-table-column width="180" align="center" label="Ngày tạo">
        <template slot-scope="scope">
          <span>{{ scope.row.createdDate | parseTime('{d}-{m}-{y} {h}:{i}') }}</span>
        </template>
      </el-table-column>
      
      <el-table-column align="center" label="Actions" width="120">
        <template slot-scope="scope">
          <el-button
            type="danger"
            size="small"
            icon="el-icon-delete"
            @click="draftForm(scope.row.id)"
          >Xóa</el-button>
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
import { fetchList, deleteArticle,isCheckPayment } from "@/api/order";
import Pagination from "@/components/Pagination"; // Secondary package based on el-pagination
import { PaymentEnumString } from "@/api/enum/enum";

export default {
  name: "Banner",
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
      paymentEnumString:PaymentEnumString,
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
    checkPayment(id,value){
      isCheckPayment(id,value).then(resp => {
        if(resp){
          this.$message({
            type: "success",
            message: "Đã than toán"
          });
        }
      })
    },
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
              var index = this.list.findIndex(x => x.id === id);
              if (index !== -1) this.list.splice(index, 1);
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
        this.list = response.data;
        this.total = response.totalCount;
        this.listLoading = false;
      });
    }
  }
};
</script>

<style scoped>
.color-primary{
  color: #1890ff;
}
.edit-input {
  padding-right: 100px;
}
.cancel-btn {
  position: absolute;
  right: 15px;
  top: 10px;
}
</style>
