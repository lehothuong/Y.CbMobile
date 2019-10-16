import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminMainMemory/AdminGetAllMainMemory",
    method: "get",
    params: query
  });
}

export function getListDropdownMainMemory() {
  return request({
    url: "/api/AdminMainMemory/AdminGetListDropdownMainMemory",
    method: "get"
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminMainMemory/AdminGetDetailMainMemory",
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
    url: "/api/AdminMainMemory/CreateMainMemory",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminMainMemory/UpdateMainMemory",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminMainMemory/DeleteMainMemory",
    method: "post",
    params: { id }
  });
}
