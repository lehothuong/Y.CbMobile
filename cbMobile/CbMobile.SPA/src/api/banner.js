import { Axios } from "../api/axios";
export const BannerAppService = {
  getBannerHome() {
    return Axios.get("/api/Banner/GetBannerHome").then(resp => {
      return resp;
    });
  },
};

export default BannerAppService;
