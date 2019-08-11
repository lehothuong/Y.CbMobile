import { Axios } from "../api/axios";
export const ContactAppService = {
  postContact(contact) {
    console.log(contact);
    return Axios.post("/api/Contact/PostContact", contact);
  }
};

export default ContactAppService;
