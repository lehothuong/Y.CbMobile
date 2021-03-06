import request from "@/utils/request";

export function login(data) {
  return request({
    url: "/api/AdminAccount/Authenticate",
    method: "post",
    data
  });
}

export function getInfo(token) {
  return request({
    url: "/api/AdminAccount",
    method: "get",
    params: { token }
  });
}

export function logout() {
  return request({
    url: "/api/AdminAccount/Logout",
    method: "post"
  });
}
