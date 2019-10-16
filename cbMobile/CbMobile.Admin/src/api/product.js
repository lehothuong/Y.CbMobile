import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminProduct/AdminGetAllProduct",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminProduct/AdminGetDetailProduct",
    method: "get",
    params: { id }
  });
}

export function getPublished() {
  return request({
    url: "/api/Common/GetYesNoDropdownList",
    method: "get"
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminProduct/CreateProduct",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminProduct/UpdateProduct",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminProduct/DeleteProduct",
    method: "post",
    params: { id }
  });
}
