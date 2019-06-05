import axios from "axios";

export const Axios = axios.create({
  baseURL: `https://localhost:44339`,
  headers: {
    Authorization: "Bearer {token}"
  }
});
