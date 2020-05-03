import Vue from "vue";
import Vuex from "vuex";
import user from "./modules/user";
import movies from "./modules/movies";
import tv from "./modules/tv";

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    user,
    movies,
    tv,
  },
});
