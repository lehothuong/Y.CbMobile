import { Axios } from "../api/axios";
export const LocationAppService = {
  getAllLocation() {
    return Axios.get("/api/Location/GetAllLocation").then(resp => {
      return resp;
    });
  }
};
export default LocationAppService;
