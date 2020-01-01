import request from "@/utils/request";

export function fetchList(query) {
    return request({
      url: "/api/AdminBill/AdminGetAllBill",
      method: "get",
      params: query
    });
}

export function deleteArticle(id) {
  return request({
    url: "/api/AdminBill/DeleteBill",
    method: "delete",
    params: { id }
  });
}

export function isCheckPayment(id,isPay) {
  return request({
    url: "/api/AdminBill/IsCheckPayment",
    method: "post",
    params: { id,isPay }
  });
}

export function fetchArticle(id){
  return request({
    url:"/api/AdminBill/AdminGetDetailBill",
    method:"get",
    params:{id}
  })
}

export function fetchArticleItems(id){
  return request({
    url:"/api/AdminBill/AdminGetDetailBillById",
    method:"get",
    params:{id}
  })
}
  
//   export function fetchArticle(id) {
//     return request({
//       url: "/api/AdminPost/AdminGetDetailPost",
//       method: "get",
//       params: { id }
//     });
//   }
  
//   export function createArticle(data) {
//     return request({
//       url: "/api/AdminPost/CreatePost",
//       method: "post",
//       data
//     });
//   }
  
//   export function updateArticle(data) {
//     return request({
//       url: "/api/AdminPost/UpdatePost",
//       method: "put",
//       data
//     });
//   }
  
