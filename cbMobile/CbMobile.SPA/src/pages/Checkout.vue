<template>
    <div class="container-fluid wrap">
        <el-form :rules="rules" ref="model" :model="model" label-width="120px">
            <div class="row h-100vh">
                <div class="col-lg-8">
                    <router-link class="shopName d-inline-block" to="/">
                        <h1 class="mb-0">CbMobile</h1>
                    </router-link>
                    <div class="row">
                        <div class="col-lg-6">
                            <h5 class="font-weight-600 mb-3">Thông tin mua hàng</h5>
                            <el-form-item class="mb-4" prop="email">
                                <el-input placeholder="Email" type="Email" v-model="model.email"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-4" prop="userName">
                                <el-input placeholder="Họ và tên" v-model="model.userName"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-4">
                                <el-input type="number" placeholder="Số điện thoại" v-model="model.phoneNumber"></el-input>
                            </el-form-item>
                             <el-form-item class="mb-4">
                                <el-input placeholder="Địa chỉ" v-model="model.address"></el-input>
                            </el-form-item>
                            <el-form-item class="mb-3">
                                <el-select
                                    v-model="model.value"
                                    filterable
                                    clearable
                                    default-first-option
                                    placeholder="Chọn tỉnh thành">
                                    <el-option
                                    v-for="item in province"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <el-form-item class="mb-3">
                                <el-select
                                    v-model="model.value"
                                    filterable
                                    clearable
                                    default-first-option
                                    placeholder="Chọn quận huyện">
                                    <el-option
                                    v-for="item in district"
                                    :key="item.value"
                                    :label="item.label"
                                    :value="item.value">
                                    </el-option>
                                </el-select>
                            </el-form-item>
                            <!-- <el-form-item class="mb-0" prop="name">
                                 <el-checkbox v-model="checked">Giao hàng đến địa chỉ khác</el-checkbox>
                            </el-form-item> -->
                            <el-form-item>
                                <el-input rows="3" type="textarea" placeholder="Ghi chú" v-model="model.content"></el-input>
                            </el-form-item>
                        </div>
                        <div class="col-lg-6">
                            <h5 class="font-weight-600 mb-3">Vận chuyển</h5>
                            <el-form-item class="transport">
                                <el-radio-group v-model="transport">
                                    <el-radio label="1">
                                        <span class="font-weight-normal">Giao hàng tận nơi</span>
                                        <span class="font-weight-bold">&nbsp;{{formatPrice(transportFee)}}</span>
                                    </el-radio>
                                </el-radio-group>
                            </el-form-item>
                            <h5 class="font-weight-600 mb-3">Thanh toán</h5>
                            <div class="payment">
                                <el-form-item class="mb-0 transport boxShadow-none">
                                    <el-radio-group v-model="model.payment">
                                        <el-radio label="1">
                                            <span class="font-weight-normal">Thanh toán khi giao hàng (COD)</span>
                                            <span class="font-weight-bold">
                                                <i class="fa fa-money payment-icon-fa" aria-hidden="true"></i>
                                            </span>
                                        </el-radio>
                                    </el-radio-group>
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
                            <h5 class="font-weight-600">Đơn hàng ({{totalAmount}} sản phẩm)</h5>
                        </div>
                        <div class="bgContentOrder">
                            <div class="summaryProduct">
                                <div class="summaryProductList">
                                    <div class="d-flex align-items-center mb-4" v-for="(item,index) in cart" :key="index">
                                        <div class="productThumbnail">
                                            <span class="productThumbnailWrapper">
                                                <img width="50" height="50" :src="item.avatarUrl" class="product-thumbnail__image">
                                            </span>
                                            <span class="productThumbnailQuantity">
                                                {{item.amount}}
                                            </span>
                                        </div>
                                        <div class="px-3">
                                            <p>{{item.name}}</p>
                                        </div>
                                        <div class="ml-auto">
                                            <p>{{formatPrice(item.valuePromotion)}}</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-0 mx-3">
                            <!-- <div class="promotionCode px-3 py-2">
                                <el-form-item class="mb-0" prop="name">
                                    <el-input placeholder="Email" v-model="model.email"></el-input>
                                    <el-button class="promotionCodeBtn">Áp dụng</el-button>
                                </el-form-item>
                            </div> -->
                            <hr class="my-0 mx-3">
                            <div class="d-flex justify-content-between my-3 mx-3">
                                <div>
                                    <p>Tạm tính</p>
                                    <p>Phí vận chuyển</p>
                                </div>
                                <div>
                                    <p>{{formatPrice(totalPriceAll)}}</p>
                                    <p>{{formatPrice(transportFee)}}</p>
                                </div>
                            </div>
                            <hr class="my-0 mx-3">
                            <div class="d-flex align-items-center justify-content-between my-3 mx-3">
                                <p>Tổng cộng</p>
                                <h4>{{formatPrice(totalPriceAllOther)}}</h4>
                            </div>
                            <div class="orderCheckout d-flex align-items-center justify-content-between my-3 mx-3">
                               <router-link class="orderCheckoutBtnBack" to="/gio-hang"><i class="fa fa-angle-left fa-lg" aria-hidden="true"></i>Quay về giỏ hàng</router-link>
                                <el-button @click.native="sendCheckout('model')" class="checkoutBtn">Đặt hàng</el-button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </el-form>
    </div>
</template>

<script>
import CheckoutAppService from "../api/checkout";
export default {
    data(){
        return{
            model:{
                payment:'1',
            },
            cart:[],
            checked:'1',
            transport:'1',
            totalAmount:0,
            result:'',
            totalPriceAll:0,
            transportFee:40000,
            province:[{label:'TPHCM',value:1}],
            district:[{label:'Quận 1',value:1}],
            rules:{
                email:[
                    {required:true, message:'Vui lòng nhập Email',trigger:'blur'},
                    {type:'email',message:'Vui lòng nhập email đúng định dạng',trigger:'blur'}
                ],
                userName:[
                    {required:true, message:'Vui lòng nhập họ và tên',trigger:'blur'},
                ]
            }
        }
    },
    mounted() {
        this.getAllCart();
        console.log(this.cart)

        if(!this.cart){
            this.$router.push('/')
        }
    },
    computed: {
        // totalPriceAll(){
        //     return 
        // },

        totalPriceAllOther(){
            return this.totalPriceAll + this.transportFee
        }
    },
    methods:{
        getTotalQuantity(){
            this.totalAmount = this.cart.map(p => p.amount).reduce((acc,curentValue) => acc + curentValue,0);
        },
        getAllCart(){
            this.cart = JSON.parse(localStorage.getItem('cart'));
            if(this.cart){
                this.totalPriceAll = this.cart.map(p => p.totalPrice).reduce((acc,curentValue) => acc + curentValue,0);
                this.getTotalQuantity();
            }
        },
        sendCheckout(formName){
            this.$refs[formName].validate((valid) => {
            if (valid) {
                this.model.cart = this.cart.map(obj =>
                    ({productId : obj.id, amount :obj.amount, mainColorId : obj.mainColorId, mainMemoryId : obj.mainMemoryId, price: obj.valuePromotion,mainColorName : obj.mainColorName, mainMemoryName : obj.mainMemoryName,})
                );
                CheckoutAppService.postOrder(this.model).then(resp =>{
                    console.log(resp)
                        if(resp){
                            this.$notify({
                            title: "Thành công!",
                            message: "Bạn đã đặt hàng thành công",
                            type: "success",
                            offset: 100
                        });
                        localStorage.removeItem('cart');
                        this.$router.push('/');
                    }
                    
                });
            } else {
                console.log('error submit!!');
                return false;
            }
        });
        }
    }
}
</script>
<style scoped lang="scss">
.checkoutBtn{
    height: 42px !important;
    padding: 0.75rem 3rem !important;
    color: #fff;
    text-transform: uppercase;
    font-weight: 700;
    font-size: 16px;
    background-color: #357ebd;
    border-color: #2f71a9;
    transition: 0.4s all;
    &:hover{
        background-color: #2d6a9f;
    }
    &:focus{
        outline: none;
    }
}
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