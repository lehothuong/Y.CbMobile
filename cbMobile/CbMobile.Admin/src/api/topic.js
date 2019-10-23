import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminTopic/AdminGetAllTopic",
    method: "get",
    params: query
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminTopic/AdminGetDetailTopic",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminTopic/CreateTopic",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminTopic/UpdateTopic",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminTopic/DeleteTopic",
    method: "delete",
    params: { id }
  });
}
