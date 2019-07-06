<template>
  <div class="header">
    <div class="container">
      <div class="row align-items-center">
        <div class="col-lg-2">
          <img src="../assets/Images/logo.png" class="logo w-100" />
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
                  <router-link class="nav-link" to="/about-us">
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
                    <div class="row">
                      <div class="col-sm-6 col-lg-4">
                        <h5>Links</h5>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                      </div>
                      <div class="col-sm-6 col-lg-4">
                        <h5>Links</h5>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                        <a class="dropdown-item" href="#">Another action</a>
                        <a class="dropdown-item" href="#">Something else here</a>
                      </div>
                      <div class="col-sm-6 col-lg-4">
                        <h5>Paragraph</h5>
                        <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Veniam impedit itaque minus distinctio possimus reiciendis et repellat. Voluptate, temporibus veniam et praesentium alias, maxime repudiandae aliquid, natus omnis animi iste!</p>
                      </div>
                    </div>
                  </div>
                </li>
                <li class="nav-item dropdown">
                  <router-link class="nav-link pointer" to="/news">
                    <div class="text-center">
                      <i class="fa fa-newspaper-o" aria-hidden="true"></i>
                      <p class="nav-p dropdown-toggle">Tin tức</p>
                    </div>
                  </router-link>
                  <div class="dropdown-menu">
                    <a class="dropdown-item" href="#">Action</a>
                    <a class="dropdown-item" href="#">Another action</a>
                    <div class="dropdown-divider"></div>
                    <a class="dropdown-item" href="#">Something else here</a>
                  </div>
                </li>
                <li class="nav-item">
                  <router-link class="nav-link" to="/">
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
