<template>
    <div class="container-fluid wrap">
        <el-form ref="form" :model="form" label-width="120px">
            <div class="row h-100vh">
                <div class="col-lg-8">
                    <router-link class="shopName d-inline-block" to="/">
                        <h1 class="mb-0">CbMobile</h1>
                    </router-link>
                    <div class="row">
                        <div class="col-lg-6">
                            <h5 class="font-weight-600 mb-3">Thông tin mua hàng</h5>
                            <el-form-item class="mb-3" prop="name">
                                <el-input placeholder="Email" v-model="model.email"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-3" prop="name">
                                <el-input placeholder="Họ và tên" v-model="model.name"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-3" prop="name">
                                <el-input placeholder="Số điện thoại" v-model="model.phoneNumber"></el-input>
                            </el-form-item>
                             <el-form-item class="mb-3" prop="name">
                                <el-input placeholder="Địa chỉ" v-model="model.address"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-3">
                                <el-select
                                    v-model="value"
                                    multiple
                                    filterable
                                    allow-create
                                    default-first-option
                                    placeholder="Chọn tỉnh thành">
                                    <el-option
                                    v-for="item in options"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <el-form-item class="mb-3">
                                <el-select
                                    v-model="value"
                                    multiple
                                    filterable
                                    allow-create
                                    default-first-option
                                    placeholder="Chọn quận huyện">
                                    <el-option
                                    v-for="item in options"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <el-form-item class="mb-0" prop="name">
                                 <el-checkbox v-model="checked">Giao hàng đến địa chỉ khác</el-checkbox>
                            </el-form-item>
                            <el-form-item label="Activity form">
                                <el-input type="textarea" placeholder="Ghi chú" v-model="model.content"></el-input>
                            </el-form-item>
                        </div>
                        <div class="col-lg-6">
                            <h5 class="font-weight-600 mb-3">Vận chuyển</h5>
                            <el-form-item class="transport" prop="name">
                                <el-radio v-model="radio" label="1">
                                    <span class="font-weight-normal">Giao hàng tận nơi</span>
                                    <span class="font-weight-bold">40.000₫</span>
                                </el-radio>
                            </el-form-item>
                            <h5 class="font-weight-600 mb-3">Thanh toán</h5>
                            <div class="payment">
                                <el-form-item class="mb-0 transport boxShadow-none" prop="name">
                                    <el-radio v-model="radio" label="1">
                                        <span class="font-weight-normal">Thanh toán khi giao hàng (COD)</span>
                                        <span class="font-weight-bold">
                                            <i class="fa fa-money payment-icon-fa" aria-hidden="true"></i>
                                        </span>
                                    </el-radio>
                                </el-form-item>
                            <div class="contentBackground">
                                <p class="mb-0">Bạn chỉ phải thanh toán khi nhận được hàng</p>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 px-0">
                    <div class="bgOrder h-100">
                        <div class="bgHeaderOrder">
                            <h5 class="font-weight-600">Đơn hàng</h5>
                        </div>
                        <div class="bgContentOrder">
                            <div class="summaryProduct">
                                <div class="summaryProductList">
                                    <div class=" d-flex align-items-center mb-4">
                                        <div class="productThumbnail">
                                            <span class="productThumbnailWrapper">
                                                <img src="https://bizweb.dktcdn.net/thumb/thumb/100/348/133/products/636737264632784078-nokia6plus-den-1.jpg?v=1551242185720" class="product-thumbnail__image">
                                            </span>
                                            <span class="productThumbnailQuantity">
                                                1
                                            </span>
                                        </div>
                                        <div class="px-3">
                                            <p>Nokia 6.1 Plus</p>
                                        </div>
                                        <div class="ml-auto">
                                            <p>23.960.000₫</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-0 mx-3">
                            <div class="promotionCode px-3 py-2">
                                <el-form-item class="mb-0" prop="name">
                                    <el-input placeholder="Email" v-model="model.email"></el-input>
                                    <el-button class="promotionCodeBtn">Áp dụng</el-button>
                                </el-form-item>
                            </div>
                            <hr class="my-0 mx-3">
                            <div class="d-flex justify-content-between my-3 mx-3">
                                <div>
                                    <p>Tạm tính</p>
                                    <p>Phí vận chuyển</p>
                                </div>
                                <div>
                                    <p>69.940.000₫</p>
                                </div>
                            </div>
                            <hr class="my-0 mx-3">
                            <div class="d-flex align-items-center justify-content-between my-3 mx-3">
                                <p>Tổng cộng</p>
                                <h4>69.940.000₫</h4>
                            </div>
                            <div class="orderCheckout d-flex align-items-center justify-content-between my-3 mx-3">
                               <router-link class="orderCheckoutBtnBack" to="/cart"><i class="fa fa-angle-left fa-lg" aria-hidden="true"></i>Quay về giỏ hàng</router-link>
                                <el-button class="orderCheckoutBtnApply">Áp dụng</el-button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </el-form>
    </div>
</template>

<script>
export default {
    data(){
        return{
            model:[],
            radio:'1'
        }
    }
}
</script>
<style scoped lang="scss">
.fa-angle-left{
    margin-right: 0.35rem;
}
.orderCheckoutBtnBack{
    color: #1f9cd0;
    i{
        transform: translateX(0);
        transition: 0.2s all;
    }
    &:hover{
        color: #2486ae;
        i{
            transform: translateX(-4px);
        }
    }
}
.wrap {
    .col-lg-8{
        padding-left: 2.5rem;
        padding-right: 2rem;
    }
}
.shopName{
    color: #1f9cd0;
    padding: 20px 0;
    h1{
        font-size: 33px !important;
    }
}
.bgHeaderOrder{
    border-bottom: 1px solid #e1e1e1;
    h5{
        padding:1rem 1.75rem;
    }
}
.bgContentOrder{
    padding:1rem 0.75rem;
}
.productThumbnail{
    width: 50px;
    height: 50px;
    border-radius: 8px;
    background: #fff;
    position: relative;
    box-shadow: 0 0 0 1px rgba(0, 0, 0, 0.1) inset;
    &::after{
        content: '';
        display: block;
        position: absolute;
        top: 0;
        left: 0;
        border-radius: 8px;
        box-shadow: 0 0 0 1px rgba(0,0,0,0.1) inset;
        z-index: 2;
        width: 100%;
        height: 100%;
    }
    .productThumbnailQuantity{
        position: absolute;
        top: -8px;
        right: -8px;
        border-radius: 50%;
        background-color: #5a96c8;
        color: #fff;
        z-index: 3;
        width: 20px;
        height: 20px;
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: 0.8125rem;
        line-height: 0;
    }
    .productThumbnailWrapper{
        width: 100%;
        height: 100%;
        position: relative;
        overflow: hidden;
        border-radius: 8px;
        z-index: 1;
        .productThumbnailImage {
            position: absolute;
            top: 0;
            left: 0;
            max-width: 100%;
            max-height: 100%;
            margin: auto;
        }
    }
}
.summaryProduct{
        min-height: 100%;
    max-height: 400px;
    position: relative;
    overflow: auto;
    transition:all 0.5s ease-in-out;
    &::-webkit-scrollbar {
      width:  4px;
      height: 4px;
    }

    &::-webkit-scrollbar-thumb {
        background: #f8f8f8;
    }

    &::-webkit-scrollbar-track {
        background: #f8f8f8;
    }
    &:hover{
        transition:all 0.5s ease-in-out;
        &::-webkit-scrollbar-thumb {
        background: #a8a8a8;
        }

        &::-webkit-scrollbar-track {
            background: #f8f8f8;
        }
    }
    .summaryProductList{
        padding: 1rem;
    }
}
</style>