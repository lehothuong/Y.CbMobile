<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 px-5">
                <h5 class="pt-4"><span class="text-uppercase font-weight-500">Giỏ hàng</span>&nbsp;<span class="fontSize14">(6 sản phẩm)</span></h5>
            </div>
        </div>
        <div class="row mb-4">
            <div class="col-lg-9 px-5">
                <div class="row py-3 shoppingCartItem">
                    <div class="col-lg-3">
                        <div class="img-1-1 slider ">
                            <img class="img-small" src="https://bizweb.dktcdn.net/thumb/medium/100/348/133/products/636737264632784078-nokia6plus-den-1.jpg"/>
                        </div>
                    </div>
                    <div class="col-lg-9 px-0">
                        <div class="d-flex justify-content-between ">
                            <div class="w-60 pr-3">
                                <p class="font-weight-500">Nokia 6.1 Plus</p>
                                <p>Khuyến mãi: Đang cập nhật</p>
                                <el-button class="danger" type="text">Xóa</el-button>
                            </div>
                            <div class="w-30">
                                <h6 class="color-red font-weight-500">5.990.000₫</h6>
                            </div>
                            <div class="w-20 text-right">
                                <el-input-number v-model="num"  :min="1" :max="99"></el-input-number>
                            </div>
                        </div>
                    </div>
                </div>
                 <div class="row py-3 shoppingCartItem">
                    <div class="col-lg-3">
                        <div class="img-1-1 slider ">
                            <img class="img-small" src="https://bizweb.dktcdn.net/thumb/medium/100/348/133/products/636737264632784078-nokia6plus-den-1.jpg"/>
                        </div>
                    </div>
                    <div class="col-lg-9 px-0">
                        <div class="d-flex justify-content-between ">
                            <div class="w-60 pr-3">
                                <p class="font-weight-500">Nokia 6.1 Plus</p>
                                <p>Khuyến mãi: Đang cập nhật</p>
                                <el-button class="danger" type="text">Xóa</el-button>
                            </div>
                            <div class="w-30">
                                <h6 class="color-red font-weight-500">5.990.000₫</h6>
                            </div>
                            <div class="w-20 text-right">
                                <el-input-number v-model="num"  :min="1" :max="99"></el-input-number>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 pr-5 pl-2 mt-4">
                <p class="d-flex">
                    <span>Tạm tính</span>
                    <span class="ml-auto">66.960.000₫</span>
                </p>
                <hr class="mt-4"/>
                <p class="d-flex align-items-center">
                    <span>Thành tiền</span>
                    <span class="totalPrices ml-auto">66.960.000₫</span>
                </p>
                <div class="mt-lg-4 pt-lg-2">
                    <button type="button" class="btn btnCheckout w-100">Thanh toán ngay</button>
                    <button type="button" class="mt-3 btn btnProcessCheckout w-100">Tiếp tục mua hàng</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            num: 1
        }
    }
}
</script>
<style scoped lang="scss">
.btnCheckout{
    background-color: #f30;
    color: #fff;
    text-transform: uppercase;
    padding: 0.375rem 0.75rem;
    &:hover{
        background-color: #cc2900;
    }
}
.btnProcessCheckout{
    background-color: #fff;
    color: #f30;
    border-color: #f30;
    text-transform: uppercase;
    padding: 0.375rem 0.75rem;
    &:hover{
        background-color: #f2f2f2;
    }
}
.totalPrices{
    color: #f30;
    font-size: 22px;
    font-weight: 700;
}
.danger{
    color: #f30;
    &:hover{
        text-decoration: underline;
    }
}
.fontSize14{
    font-size: 14px;
}
.ptTotalPrices{
    padding-top: 3rem;
}
</style>