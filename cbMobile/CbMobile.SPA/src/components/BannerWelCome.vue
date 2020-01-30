<template>
    <div>
        <router-link
        class="linkHomeBoxNews mt-2"
        to="/"
        >
            <div class="homeBoxNews">
                <div
                    class="img-background img-370-102"
                    :style="{ backgroundImage: 'url(\'' + banners.bannerUrl + '\')' }"
                ></div>
            </div>
        </router-link>
    </div>
</template>
<script>
import BannerAppService from '../api/banner';
import { BannerCategory } from '../api/enum/enum'
export default {
    data() {
        return {
            banners:null,
        }
    },
    created(){
        this.getBannerHome();
    },
    methods: {
         getBannerHome() {
            BannerAppService.getBannerHome(BannerCategory.BannerHomeWelcome).then(resp => {
                console.log(resp.data)
                this.banners = resp.data.shift();
            })
        }
    },
}
</script>