import { Axios } from "../api/axios";
export const CategoryAppService = {
  getCategoryNewMenu() {
    return Axios.get("/api/CategoryPost/GetCategoryNewMenu").then(resp => {
      return resp;
    });
  },
  getListByIdCategory(id) {
    return Axios.get("/api/CategoryPost/GetListById", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  }
};

export default CategoryAppService;
