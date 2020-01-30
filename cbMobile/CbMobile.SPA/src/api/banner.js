import { Axios } from "../api/axios";
export const BannerAppService = {
  getBannerHome(bannerId) {
    return Axios.get("/api/Banner/GetBannerHome", {params : {idbannerHomeTop : bannerId}}).then(resp => {
      return resp;
    });
  },
};

export default BannerAppService;
