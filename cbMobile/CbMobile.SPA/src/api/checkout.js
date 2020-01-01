import { Axios } from "../api/axios";
export const CheckoutAppService = {
    postOrder(order) {
    return Axios.post("/api/Bill/PostPill", order).then(resp => {
      return resp;
    });
  }
};

export default CheckoutAppService;