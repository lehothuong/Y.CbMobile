import { Axios } from "../api/axios";
export const NewAppService = {
  getDetailById(id) {
    return Axios.get("/api/Post/GetDetailNews", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  },
  getNewTechnology() {
    return Axios.get("/api/Post/GetNewTechnology").then(resp => {
      return resp;
    });
  }
};

export default NewAppService;
