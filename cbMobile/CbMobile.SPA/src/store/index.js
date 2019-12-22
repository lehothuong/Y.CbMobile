import Vue from "vue";
import Vuex from "vuex";
Vue.use(Vuex);

const mutations = {
    SET_TOTALQUANTITY: (state, totalQuantity) => {
        state.totalQuantity = totalQuantity;
    },
};

const store = new Vuex.Store({
    state: () => {
        const state = {
            totalQuantity: 0,
        }
        return state
    },
    mutations
})
  
export default store
