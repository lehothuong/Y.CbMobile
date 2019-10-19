import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminBanner/AdminGetAllBanner",
    method: "get",
    params: query
  });
}

// export function fetchGetListDropdownCategoryProduct() {
//   return request({
//     url: "/api/AdminCategoryProduct/AdminGetListDropdownCategoryProduct",
//     method: "get"
//   });
// }

export function fetchArticle(id) {
  return request({
    url: "/api/AdminBanner/AdminGetDetailBanner",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminBanner/CreateBanner",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminBanner/UpdateBanner",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminBanner/DeleteBanner",
    method: "delete",
    params: { id }
  });
}
