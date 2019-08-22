import { Axios } from "../api/axios";
export const ReviewAppService = {
  postReview(review) {
    return Axios.post("/api/Review/PostReview", review).then(resp => {
      return resp;
    });
  },
  getAllReviewByProductId(id) {
    return Axios.get("/api/Review/GetAllReviewByProductId", {
      params: { id: id }
    }).then(resp => {
      return resp;
    });
  }
};
export default ReviewAppService;
