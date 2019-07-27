import { Axios } from "../api/axios";
export const CategoryProductAppService = {
  getMenuCategoryProduct() {
    return Axios.get("/api/CategoryProduct/GetMenuCategoryProduct").then(
      resp => {
        return resp;
      }
    );
  }
};

export default CategoryProductAppService;
