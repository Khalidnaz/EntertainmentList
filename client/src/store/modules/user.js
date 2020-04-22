import { ADD_USER, SIGNIN_USER } from '../../graphql/user/userMutations';
import { apolloClient } from '../../plugins/apollo';
import router from '../../router';

const state = {
  user: null,
  loading: false,
	error: null,
	watchList: []
};

const getters = {
  user: (state) => state.user,
  loading: (state) => state.loading,
  error: (state) => state.error,
};

const actions = {
  registerUser: async ({ commit }, payload) => {
    commit('setLoading', true);

    try {
      await apolloClient.mutate({
        mutation: ADD_USER,
        variables: payload,
      });

      commit('setLoading', false);
    } catch (err) {
      commit('setError', err.message);
    }
  },
  login: async ({ commit }, payload) => {
    commit('setLoading', true);

    try {
      const { data } = await apolloClient.mutate({
        mutation: SIGNIN_USER,
        variables: payload,
      });

      commit('setLoading', false);
      commit('setUser', data.login);
      localStorage.setItem('user', JSON.stringify(data.login));
      router.push("/");
    } catch (err) {
      commit('setError', err.message);
    }
  },
  logout: ({ commit }) => commit('clearUser'),
};

const mutations = {
  setUser: (state, payload) => (state.user = payload),
  setLoading: (state, payload) => (state.loading = payload),
  setError: (state, payload) => (state.error = payload),
  clearUser: (state) => (state.user = null),
};

export default {
  state,
  getters,
  actions,
  mutations,
};
