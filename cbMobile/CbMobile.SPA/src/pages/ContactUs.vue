<template>
  <div class="container contact">
    <div class="row mt-5 pb-5 border-bottom">
      <div class="col-lg-4 infoContact">
        <h5 class="text-uppercase font-weight-500 color-black-1">Thông tin liên hệ</h5>
        <div v-for="(item,index) in locations" :key="index">
          <p>{{item.shortDescription}}</p>
          <p>
            <span class="px-lg-1">
              <i class="fa fa-map-marker" aria-hidden="true"></i>
            </span>
            {{item.address}}
          </p>
          <p>
            <span class="px-lg-1">
              <i class="fa fa-phone" aria-hidden="true"></i>
            </span>
            {{item.phoneNumber}}
          </p>
          <p>
            <span class="px-lg-1">
              <i class="fa fa-envelope" aria-hidden="true"></i>
            </span>
            {{item.email}}
          </p>
        </div>
      </div>
      <div class="col-lg-8 formContact">
        <h5 class="text-uppercase font-weight-500 color-black-1">Gửi thông tin</h5>
        <p
          class="font-italic textContact"
        >Bạn hãy điền nội dung tin nhắn vào form dưới đây và gửi cho chúng tôi. Chúng tôi sẽ trả lời bạn sau khi nhận được.</p>
        <el-form class="demo-ruleForm" ref="contact" :model="contact" :rules="rules">
          <div class="row">
            <div class="col-lg-6">
              <el-form-item label="Họ tên" prop="name">
                <el-input v-model="contact.name"></el-input>
              </el-form-item>
            </div>
            <div class="col-lg-6">
              <el-form-item label="Email" prop="email">
                <el-input type="email" v-model="contact.email"></el-input>
              </el-form-item>
            </div>
          </div>
          <el-form-item label="Điện thoại" prop="phoneNumber">
            <el-input type="number" v-model="contact.phoneNumber"></el-input>
          </el-form-item>
          <el-form-item label="Nội dung" prop="content">
            <el-input type="textarea" :rows="5" v-model="contact.content"></el-input>
          </el-form-item>
          <el-form-item>
            <el-button
              @click="submitForm('contact')"
              class="btn btnSendContact font-weight-bolder text-uppercase"
            >Gửi tin nhắn</el-button>
          </el-form-item>
        </el-form>
      </div>
    </div>
    <div class="mt-lg-4 pt-lg-2">
      <h5 class="text-uppercase font-weight-500 text-center color-black-1">Bản đồ cửa hàng</h5>
      <iframe
        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.2498024603133!2d106.64038581452866!3d10.792169892310868!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3175294ce73d0759%3A0x99abb4bf92864687!2sThe+Coffee+House+-+B%C3%A0u+C%C3%A1t!5e0!3m2!1svi!2s!4v1565409816300!5m2!1svi!2s"
        height="450"
        frameborder="0"
        style="border:0; width:100%"
        allowfullscreen
      ></iframe>
    </div>
  </div>
</template>
<script>
import GoogleMap from "../components/GoogleMap";
import LocationAppService from "../api/location";
import ContactAppService from "../api/contact";
export default {
  components: {
    GoogleMap
  },
  data() {
    return {
      contact: {
        name: "",
        email: "",
        phoneNumber: 0,
        content: ""
      },
      result: "",
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
        phoneNumber: [
          {
            required: true,
            message: "Xin vui lòng nhập Số điện thoại",
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
      locations: []
    };
  },
  methods: {
    getAllLocation() {
      LocationAppService.getAllLocation().then(resp => {
        this.locations = resp.data;
      });
    },
    submitForm(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          ContactAppService.postContact(this.contact).then(resp => {
            this.result = resp.data;
            this.$notify({
              title: "Thành công!",
              message: "Cảm ơn bạn đã liên hệ với chúng tôi",
              type: "success",
              offset: 100
            });
            this.$refs[formName].resetFields();
          });
        } else {
          this.$notify({
            title: "Không thành công!",
            message: "Liên hệ không thành công",
            title: "Error",
            offset: 100
          });
          return false;
        }
      });
    }
  },
  created() {
    this.getAllLocation();
  }
};
</script>

