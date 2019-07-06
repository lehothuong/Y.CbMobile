import { Axios } from "../api/axios";
export const PostAppService = {
  getAboutUs() {
    return Axios.get("/api/Post/GetAboutUs").then(resp => {
      return resp;
    });
  }
};

export default PostAppService;
