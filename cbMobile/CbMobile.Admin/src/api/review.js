import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminReview/AdminGetAllReview",
    method: "get",
    params: query
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminReview/DeleteReview",
    method: "delete",
    params: { id }
  });
}
