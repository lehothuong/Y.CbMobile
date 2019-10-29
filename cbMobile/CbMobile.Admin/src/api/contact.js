import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminContact/AdminGetAllContact",
    method: "get",
    params: query
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminContact/DeleteContact",
    method: "delete",
    params: { id }
  });
}
