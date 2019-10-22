import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminPost/AdminGetAllPost",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminPost/AdminGetDetailPost",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminPost/CreatePost",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminPost/UpdatePost",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminPost/DeletePost",
    method: "delete",
    params: { id }
  });
}
