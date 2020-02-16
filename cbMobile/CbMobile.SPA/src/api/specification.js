import { Axios } from "./axios";
export const SpecificationAppService = {
  getUISpecification(id){
    return Axios.get("/api/Specification/GetUISpecificationById",{params : {id : id}}).then(resp => {
        return resp;
    });
  }
};

export default SpecificationAppService;
