import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminLocation/AdminGetAllLocation",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminLocation/AdminGetDetailLocation",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminLocation/CreateLocation",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminLocation/UpdateLocation",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminLocation/DeleteLocation",
    method: "delete",
    params: { id }
  });
}
