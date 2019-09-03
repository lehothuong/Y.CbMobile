import { Axios } from "../api/axios";
export const SubscribeAppService = {
  postSubscribe(subscribe) {
    return Axios.post("/api/Subscribe/PostSubscribe", subscribe).then(resp => {
      return resp;
    });
  }
};

export default SubscribeAppService;
