import request from "@/utils/request";

export function fetchList() {
  return request({
    url: "/api/AdminCategoryProduct/AdminGetAllCategoryProduct",
    method: "get"
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminCategoryProduct/AdminGetDetailCategoryProduct",
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
    url: "/api/AdminCategoryProduct/CreateCategoryProduct",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminCategoryProduct/UpdateCategoryProduct",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminCategoryProduct/DeleteCategoryProduct",
    method: "post",
    params: { id }
  });
}
