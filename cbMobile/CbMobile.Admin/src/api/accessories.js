import request from "@/utils/request";

export function fetchList(query) {
    return request({
      url: "api/AdminProduct/GetAllDetailAccessories",
      method: "get",
      params: query
    });
}

export function fetchArticle(id) {
    return request({
      url: "/api/AdminProduct/AdminGetDetailAccessories",
      method: "get",
      params: { id }
    });
}
  
export function createArticle(data) {
    return request({
      url: "/api/AdminProduct/CreateAccessories",
      method: "post",
      data
    });
}

export function updateArticle(data) {
    return request({
        url: "/api/AdminProduct/UpdateAccessories",
        method: "put",
        data
    });
}

export function deleteArticle(id) {
    return request({
        url: "/api/AdminProduct/DeleteAccessories",
        method: "delete",
        params: { id }
    });
}