import { Axios } from "../api/axios";
export const ManufacturerAppService = {
  getManufacturerInHome() {
    return Axios.get("/api/Manufacturer").then(resp => {
      return resp;
    });
  }
};

export default ManufacturerAppService;
