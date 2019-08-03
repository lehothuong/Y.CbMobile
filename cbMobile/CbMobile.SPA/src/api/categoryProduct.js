import { Axios } from "../api/axios";
export const CategoryProductAppService = {
  getMenuCategoryProduct() {
    return Axios.get("/api/CategoryProduct/GetMenuCategoryProduct").then(
      resp => {
        return resp;
      }
    );
  },

  getManuFacturerById(id) {
    return Axios.get("/api/CategoryProduct/getManuFacturerById", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  }
};

export default CategoryProductAppService;
