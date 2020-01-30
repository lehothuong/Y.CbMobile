import { Axios } from "./axios";
export const SearchAppService = {
  filter(keyword) {
    return Axios.get("/api/Search/Filter", { params: { keyword: keyword } }).then(resp => {
      return resp;
    });
  },
};

export default SearchAppService;
