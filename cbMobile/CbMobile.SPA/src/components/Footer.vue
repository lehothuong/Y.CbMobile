<template>
  <div id="footer" v-bind:class="classObject" class="p-lg-4 bgFooter">
    <div class="container">
      <div class="row">
        <div class="col-lg-3">
          <p class="font-weight-500">Thông tin công ty</p>
          <router-link to="/" class="mb-lg-1">Trang chủ</router-link>
          <router-link to="/" class="mb-lg-1">Giới thiệu</router-link>
          <router-link to="/" class="mb-lg-1">Sản phẩm</router-link>
          <router-link to="/" class="mb-lg-1">Tin tức</router-link>
          <router-link to="/" class="mb-lg-1">Liên hệ</router-link>
        </div>
        <div class="col-lg-3">
          <p class="font-weight-500">Chính sách công ty</p>
          <router-link to="/" class="mb-lg-1">Về chúng tôi</router-link>
        </div>
        <div class="col-lg-3">
          <p class="font-weight-500">Hỗ trợ khách hàng</p>
          <router-link to="/" class="mb-lg-1">Về chúng tôi</router-link>
        </div>
        <div class="col-lg-3">
          <p class="font-weight-500">Thông tin</p>
          <router-link to="/" class="mb-lg-1">Về chúng tôi</router-link>
        </div>
      </div>
      <div class="d-flex justify-content-between mt-lg-3">
        <div class="footerSocial">
          <p class="font-weight-500 mb-2">Kết nối với chúng tôi</p>
          <ul class="d-flex list-menu list-inline">
            <li class="twitter">
              <a href="#" target="_blank">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  version="1.1"
                  x="0px"
                  y="0px"
                  viewBox="0 0 612 612"
                  style="enable-background:new 0 0 612 612;"
                  xml:space="preserve"
                  width="15px"
                  height="15px"
                >
                  <g>
                    <path
                      d="M612,116.258c-22.525,9.981-46.694,16.75-72.088,19.772c25.929-15.527,45.777-40.155,55.184-69.411    c-24.322,14.379-51.169,24.82-79.775,30.48c-22.907-24.437-55.49-39.658-91.63-39.658c-69.334,0-125.551,56.217-125.551,125.513    c0,9.828,1.109,19.427,3.251,28.606C197.065,206.32,104.556,156.337,42.641,80.386c-10.823,18.51-16.98,40.078-16.98,63.101    c0,43.559,22.181,81.993,55.835,104.479c-20.575-0.688-39.926-6.348-56.867-15.756v1.568c0,60.806,43.291,111.554,100.693,123.104    c-10.517,2.83-21.607,4.398-33.08,4.398c-8.107,0-15.947-0.803-23.634-2.333c15.985,49.907,62.336,86.199,117.253,87.194    c-42.947,33.654-97.099,53.655-155.916,53.655c-10.134,0-20.116-0.612-29.944-1.721c55.567,35.681,121.536,56.485,192.438,56.485    c230.948,0,357.188-191.291,357.188-357.188l-0.421-16.253C573.872,163.526,595.211,141.422,612,116.258z"
                      data-original="#010002"
                      class="active-path"
                      data-old_color="#010002"
                      fill="#FFFFFF"
                    />
                  </g>
                </svg>
              </a>
            </li>

            <li class="facebook">
              <a href="#" target="_blank">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  version="1.1"
                  x="0px"
                  y="0px"
                  width="15px"
                  height="15px"
                  viewBox="0 0 430.113 430.114"
                  style="enable-background:new 0 0 430.113 430.114;"
                  xml:space="preserve"
                >
                  <path
                    id="Facebook"
                    d="M158.081,83.3c0,10.839,0,59.218,0,59.218h-43.385v72.412h43.385v215.183h89.122V214.936h59.805   c0,0,5.601-34.721,8.316-72.685c-7.784,0-67.784,0-67.784,0s0-42.127,0-49.511c0-7.4,9.717-17.354,19.321-17.354   c9.586,0,29.818,0,48.557,0c0-9.859,0-43.924,0-75.385c-25.016,0-53.476,0-66.021,0C155.878-0.004,158.081,72.48,158.081,83.3z"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                </svg>
              </a>
            </li>

            <li class="pinterest">
              <a href="#" target="_blank">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  version="1.1"
                  x="0px"
                  y="0px"
                  viewBox="0 0 310.05 310.05"
                  style="enable-background:new 0 0 310.05 310.05;"
                  xml:space="preserve"
                  width="15px"
                  height="15px"
                >
                  <path
                    id="XMLID_799_"
                    d="M245.265,31.772C223.923,11.284,194.388,0,162.101,0c-49.32,0-79.654,20.217-96.416,37.176   c-20.658,20.9-32.504,48.651-32.504,76.139c0,34.513,14.436,61.003,38.611,70.858c1.623,0.665,3.256,1,4.857,1   c5.1,0,9.141-3.337,10.541-8.69c0.816-3.071,2.707-10.647,3.529-13.936c1.76-6.495,0.338-9.619-3.5-14.142   c-6.992-8.273-10.248-18.056-10.248-30.788c0-37.818,28.16-78.011,80.352-78.011c41.412,0,67.137,23.537,67.137,61.425   c0,23.909-5.15,46.051-14.504,62.35c-6.5,11.325-17.93,24.825-35.477,24.825c-7.588,0-14.404-3.117-18.705-8.551   c-4.063-5.137-5.402-11.773-3.768-18.689c1.846-7.814,4.363-15.965,6.799-23.845c4.443-14.392,8.643-27.985,8.643-38.83   c0-18.55-11.404-31.014-28.375-31.014c-21.568,0-38.465,21.906-38.465,49.871c0,13.715,3.645,23.973,5.295,27.912   c-2.717,11.512-18.865,79.953-21.928,92.859c-1.771,7.534-12.44,67.039,5.219,71.784c19.841,5.331,37.576-52.623,39.381-59.172   c1.463-5.326,6.582-25.465,9.719-37.845c9.578,9.226,25,15.463,40.006,15.463c28.289,0,53.73-12.73,71.637-35.843   c17.367-22.418,26.932-53.664,26.932-87.978C276.869,77.502,265.349,51.056,245.265,31.772z"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                </svg>
              </a>
            </li>

            <li class="google">
              <a href="#" target="_blank">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  xmlns:xlink="http://www.w3.org/1999/xlink"
                  version="1.1"
                  x="0px"
                  y="0px"
                  viewBox="0 0 491.858 491.858"
                  style="enable-background:new 0 0 491.858 491.858;"
                  xml:space="preserve"
                  width="15px"
                  height="15px"
                  class
                >
                  <path
                    d="M377.472,224.957H201.319v58.718H308.79c-16.032,51.048-63.714,88.077-120.055,88.077     c-69.492,0-125.823-56.335-125.823-125.824c0-69.492,56.333-125.823,125.823-125.823c34.994,0,66.645,14.289,89.452,37.346     l42.622-46.328c-34.04-33.355-80.65-53.929-132.074-53.929C84.5,57.193,0,141.693,0,245.928s84.5,188.737,188.736,188.737     c91.307,0,171.248-64.844,188.737-150.989v-58.718L377.472,224.957L377.472,224.957z"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                  <polygon
                    points="491.858,224.857 455.827,224.857 455.827,188.826 424.941,188.826 424.941,224.857 388.91,224.857      388.91,255.74 424.941,255.74 424.941,291.772 455.827,291.772 455.827,255.74 491.858,255.74    "
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                </svg>
              </a>
            </li>

            <li class="instagram">
              <a href="#" target="_blank">
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 512 512"
                  width="15px"
                  height="15px"
                >
                  <path
                    d="m75 512h362c41.355469 0 75-33.644531 75-75v-362c0-41.355469-33.644531-75-75-75h-362c-41.355469 0-75 33.644531-75 75v362c0 41.355469 33.644531 75 75 75zm-45-437c0-24.8125 20.1875-45 45-45h362c24.8125 0 45 20.1875 45 45v362c0 24.8125-20.1875 45-45 45h-362c-24.8125 0-45-20.1875-45-45zm0 0"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                  <path
                    d="m256 391c74.4375 0 135-60.5625 135-135s-60.5625-135-135-135-135 60.5625-135 135 60.5625 135 135 135zm0-240c57.898438 0 105 47.101562 105 105s-47.101562 105-105 105-105-47.101562-105-105 47.101562-105 105-105zm0 0"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                  <path
                    d="m406 151c24.8125 0 45-20.1875 45-45s-20.1875-45-45-45-45 20.1875-45 45 20.1875 45 45 45zm0-60c8.269531 0 15 6.730469 15 15s-6.730469 15-15 15-15-6.730469-15-15 6.730469-15 15-15zm0 0"
                    data-original="#000000"
                    class="active-path"
                    data-old_color="#000000"
                    fill="#FFFFFF"
                  />
                </svg>
              </a>
            </li>
          </ul>
        </div>
        <div class="footerSubscribe">
          <p class="font-weight-500 mb-2">Đăng ký nhận tin</p>
          <p class="mb-2">Nhận thông tin sản phẩm mới nhất, tin khuyến mãi và nhiều hơn nữa.</p>
          <el-form ref="subscribe" :model="subscribe" :rules="rules">
            <el-form-item prop="email" class="email">
              <el-input placeholder="Email của bạn" type="email" v-model="subscribe.email"></el-input>
            </el-form-item>
            <el-form-item class="inputGroupBtn">
              <el-button @click="submitForm('subscribe')" class="btn btnDefault">Gửi tin nhắn</el-button>
            </el-form-item>
          </el-form>
          <!-- <form>
            <div class="input-group">
              <input type="email" class="form-control"  />
              <span class="inputGroupBtn">
                <button type="submit" class="btn btnDefault">Submit</button>
              </span>
            </div>
          </form>-->
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import SubscribeAppService from "../api/subscribe";
export default {
  props: ["isActive"],
  data() {
    return {
      subscribe: {
        email: ""
      },
      result: [],
      rules: {
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
        ]
      }
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          SubscribeAppService.postSubscribe(this.subscribe).then(resp => {
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
  computed: {
    classObject: function() {
      if (this.isActive) {
        return {
          bgWhite: "fatal"
        };
      }
    }
  }
};
</script>

