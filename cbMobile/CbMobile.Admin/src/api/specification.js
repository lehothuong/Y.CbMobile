import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminSpecification/AdminGetAllSpecification",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminSpecification/GetDetailSpecification",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminSpecification/CreateSpecification",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminSpecification/UpdateSpecification",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminSpecification/DeleteSpecification",
    method: "delete",
    params: { id }
  });
}

export function fetchGetListDropdownSpecification() {
  return request({
    url: "/api/AdminSpecification/GetListDropdownSpecification",
    method: "get"
  });
}
