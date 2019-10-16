import request from "@/utils/request";

export function fetchList(query) {
  return request({
    url: "/api/AdminManufacturer/AdminGetAllManufacturer",
    method: "get",
    params: query
  });
}

export function fetchListDropdownManufacturer() {
  return request({
    url: "/api/AdminManufacturer/AdminGetListDropdownManufacturer",
    method: "get"
  });
}

export function fetchArticle(id) {
  return request({
    url: "/api/AdminManufacturer/AdminGetDetailManufacturer",
    method: "get",
    params: { id }
  });
}

export function createArticle(data) {
  return request({
    url: "/api/AdminManufacturer/CreateManufacturer",
    method: "post",
    data
  });
}

export function updateArticle(data) {
  return request({
    url: "/api/AdminManufacturer/UpdateManufacturer",
    method: "put",
    data
  });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminManufacturer/DeleteManufacturer",
    method: "post",
    params: { id }
  });
}
