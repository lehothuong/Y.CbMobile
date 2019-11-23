<template>
  <div class="header">
    <div class="container">
      <div class="row align-items-center">
        <div class="col-lg-2">
          <router-link class="nav-link" to="/">
            <img src="../assets/Images/logo.png" class="logo w-100" />
          </router-link>
        </div>
        <div class="col-lg-3">
          <div class="search">
            <input class="form-control" placeholder="Tìm kiếm" />
          </div>
        </div>
        <div class="col-lg-7 menuHeader">
          <nav class="navbar navbar-expand-lg navbar-light">
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav mr-auto">
                <li class="nav-item">
                  <router-link class="nav-link" to="/">
                    <div class="text-center">
                      <i class="fa fa-mobile" aria-hidden="true"></i>
                      <p class="nav-p">Trang chủ</p>
                    </div>
                  </router-link>
                </li>
                <li class="nav-item">
                  <router-link class="nav-link" to="/gioi-thieu">
                    <div class="text-center">
                      <i class="fa fa-tablet" aria-hidden="true"></i>
                      <p class="nav-p">Giới thiệu</p>
                    </div>
                  </router-link>
                </li>
                <li class="nav-item dropdown megamenu-li">
                  <a class="nav-link pointer">
                    <div class="text-center">
                      <i class="fa fa-laptop" aria-hidden="true"></i>
                      <p class="nav-p dropdown-toggle">Sản phẩm</p>
                    </div>
                  </a>
                  <div class="dropdown-menu megamenu">
                    <Megamenu></Megamenu>
                  </div>
                </li>
                <li class="nav-item dropdown">
                  <div class="nav-link">
                    <div class="text-center">
                      <i class="fa fa-newspaper-o" aria-hidden="true"></i>
                      <p class="nav-p dropdown-toggle">Tin tức</p>
                    </div>
                  </div>
                  <div class="dropdown-menu">
                    <MenuNews></MenuNews>
                  </div>
                </li>
                <li class="nav-item">
                  <router-link class="nav-link" to="/lien-he">
                    <div class="text-center">
                      <i class="fa fa-clock-o" aria-hidden="true"></i>
                      <p class="nav-p">Liên hệ</p>
                    </div>
                  </router-link>
                </li>
              </ul>
            </div>
          </nav>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Megamenu from "../components/Megamenu";
import MenuNews from "../components/MenuNews";
export default {
  components: {
    Megamenu,
    MenuNews
  }
};
</script>

