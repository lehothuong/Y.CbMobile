import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminCategoryPost/AdminGetAllCategoryPost",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminCategoryPost/AdminGetDetailCategoryPost",
    method: "get",
    params: { id }
  });
}

export function fetchGetListDropdownCategoryPost() {
  return request({
    url: "/api/AdminCategoryPost/GetListDropdownCategoryPost",
    method: "get"
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminCategoryPost/CreateCategoryPost",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminCategoryPost/UpdateCategoryPost",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminCategoryPost/DeleteCategoryPost",
    method: "delete",
    params: { id }
  });
}
