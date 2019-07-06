import { Axios } from "../api/axios";
export const ProductAppService = {
  getProductHotInHome() {
    return Axios.get("/api/Product/GetProductHotInHome").then(resp => {
      return resp;
    });
  },
  getPhoneProductInHome() {
    return Axios.get("/api/Product/GetPhoneProductInHome").then(resp => {
      return resp;
    });
  }
};

export default ProductAppService;
