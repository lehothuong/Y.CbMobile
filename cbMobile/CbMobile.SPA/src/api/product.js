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
  },
  getDetailProduct(id) {
    return Axios.get("/api/Product/GetDetails", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  },
  getProductGeneric(id) {
    return Axios.get("/api/Product/GetGenericProduct", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  },
  getIndexProductById(id) {
    return Axios.get("/api/Product/GetIndexProductById", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  },
  getIndexManufactureById(id, idCategory) {
    return Axios.get("/api/Product/GetIndexManufactureById", {
      params: { id: id, idCategory: idCategory }
    }).then(resp => {
      return resp;
    });
  },
  getCategoryProductById(id) {
    return Axios.get("/api/CategoryProduct/GetCategoryProductById", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  }
};

export default ProductAppService;
