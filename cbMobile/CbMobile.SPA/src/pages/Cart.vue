<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12 px-5">
                <h5 class="pt-4"><span class="text-uppercase font-weight-500">Giỏ hàng</span>&nbsp;<span class="fontSize14">({{totalQuantity}} sản phẩm)</span></h5>
            </div>
        </div>
        <div v-if="cart.length>0" class="row mb-4">
            <div class="col-lg-9 px-5">
                <div class="row py-3 shoppingCartItem" v-for="(item,index) in cart" :key="index">
                    <div class="col-lg-3">
                        <div class="img-1-1 slider ">
                            <img class="img-small" :src="item.avatarUrl"/>
                        </div>
                    </div>
                    <div class="col-lg-9 px-0">
                        <div class="d-flex justify-content-between align-items-center">
                            <div class="w-60 pr-3">
                                <p class="font-weight-500 mb-0">{{item.name}}</p>
                                <!-- <p>Khuyến mãi: Đang cập nhật</p> -->
                            </div>
                            <div class="w-30">
                                <h6 class="color-red font-weight-500 mb-0">{{formatPrice(item.valuePromotion)}}</h6>
                            </div>
                            <div class="w-20 text-right">
                                <el-input-number v-model="item.amount" @change="changePrice(index,item)" :min="1" :max="99"></el-input-number>
                            </div>
                        </div>
                        <el-button class="danger mb-0" @click.prevent="removeProduct(index,item)" type="text">Xóa</el-button>
                    </div>
                </div>
            </div>
            <div class="col-lg-3 pr-5 pl-2 mt-4">
                <p class="d-flex">
                    <span>Tạm tính</span>
                    <span class="ml-auto">{{formatPrice(totalPrice)}}</span>
                </p>
                <hr class="mt-4"/>
                <p class="d-flex align-items-center">
                    <span>Thành tiền</span>
                    <span class="totalPrices ml-auto">{{formatPrice(totalPrice)}}</span>
                </p>
                <div class="mt-lg-4 pt-lg-2">
                    <router-link to="/dat-hang" class="btn btnCheckout w-100">Thanh toán ngay</router-link>
                    <button type="button" class="mt-3 btn btnProcessCheckout w-100">Tiếp tục mua hàng</button>
                </div>
            </div>
        </div>
        <div v-else>
            <div class="row justify-content-center align-items-center">
                <div class="col-lg-3 text-center">
                    <div class="img-1-1 slider">
                        <img class="img-small" src="../assets/Images/shopping-cart-empty.svg"/>
                    </div>
                     <button type="button" class="mt-lg-3 mb-lg-4 btn btnCheckout">Tiếp tục lựa chọn</button>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            num: 1,
            cart:[],
            totalQuantity:0,
            amount:1,
        }
    },
    computed: {
        totalPrice(){
            return this.cart.map(p => p.totalPrice).reduce((acc,currentValue) => acc + currentValue,0)
        }
    },
    mounted(){
        this.getCart();
        if(this.cart.length == 0){
            this.$router.push('/')
        }
    },
    methods:{
        getTotalQuantity(){
            this.totalQuantity = this.cart.map(p => p.amount).reduce((acc,curentValue) => acc + curentValue,0);
            this.$store.commit('SET_TOTALQUANTITY',this.totalQuantity)
        },
        changePrice(value,object){
            localStorage.removeItem('cart');
            this.cart[value].totalPrice = object.amount * object.valuePromotion;
            let parsed = JSON.stringify(this.cart);
            localStorage.setItem('cart', parsed);
            this.getTotalQuantity();
        },
        removeProduct(value,object){
            localStorage.removeItem('cart');
            this.cart.splice(value, 1);
            let parsed = JSON.stringify(this.cart);
            localStorage.setItem('cart', parsed);
            if(this.cart.length == 0){
                this.cartDialog = false;
            }
            this.getTotalQuantity();
        },
        getCart(){
            this.cart = JSON.parse(localStorage.getItem('cart'));
            this.getTotalQuantity();
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