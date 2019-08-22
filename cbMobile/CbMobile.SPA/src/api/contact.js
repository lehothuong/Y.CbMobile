import { Axios } from "../api/axios";
export const ContactAppService = {
  postContact(contact) {
    return Axios.post("/api/Contact/PostContact", contact).then(resp => {
      return resp;
    });
  }
};

export default ContactAppService;
