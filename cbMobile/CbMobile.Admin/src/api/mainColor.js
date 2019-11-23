import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminMainColor/AdminGetAllMainColor",
    method: "get",
    params: query
  });
}

export function getListDropdownMainColor() {
  return request({
    url: "/api/AdminMainColor/AdminGetListDropdownMainColor",
    method: "get"
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminMainColor/AdminGetDetailMainColor",
    method: "get",
    params: { id }
  });
}

export function fetchPv(pv) {
  return request({
    url: "/article/pv",
    method: "get",
    params: { pv }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminMainColor/CreateMainColor",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminMainColor/UpdateMainColor",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminMainColor/DeleteMainColor",
    method: "post",
    params: { id }
  });
}
