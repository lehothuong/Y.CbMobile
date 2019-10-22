import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminCategoryBanner/AdminGetAllCategoryBanner",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminCategoryBanner/AdminGetDetailCategoryBanner",
    method: "get",
    params: { id }
  });
}

export function fetchGetListDropdownCategoryBanner() {
  return request({
    url: "/api/AdminCategoryBanner/GetListDropdownCategoryBanner",
    method: "get"
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminCategoryBanner/CreateCategoryBanner",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminCategoryBanner/UpdateCategoryBanner",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminCategoryBanner/DeleteCategoryBanner",
    method: "delete",
    params: { id }
  });
}
