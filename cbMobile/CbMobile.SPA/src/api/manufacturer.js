import { Axios } from "../api/axios";
export const ManufacturerAppService = {
  getManufacturerInHome() {
    return Axios.get("/api/Manufacturer").then(resp => {
      return resp;
    });
  },
  getManufacturerById(id) {
    return Axios.get("/api/Manufacturer/GetManufacturerById", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  }
};

export default ManufacturerAppService;
