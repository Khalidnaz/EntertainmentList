import Vue from 'vue';
import Vuex from 'vuex';
import user from './modules/user';
import movies from './modules/movies';

Vue.use(Vuex);

export default new Vuex.Store({
	modules: {
		user,
		movies
	}
})