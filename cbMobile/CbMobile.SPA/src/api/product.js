import { Axios } from "../api/axios";
export const ProductAppService = {
  getProductInHomeHot() {
    // Axios.get("/api/Manufacturer")
    //   .then(response => {
    //     this.manufacturers = response.data;
    //   })
    //   .catch(e => {});

    return Axios.get("/api/Product").then(resp => {
      return resp;
    });
  }
};

export default ProductAppService;
