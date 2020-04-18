import { ADD_USER } from '../../graphql/user/userMutations';
import { apolloClient } from '../../plugins/apollo';

const state = {
  user: null,
  loading: false,
  error: null,
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
      const { data } = await apolloClient.mutate({
        mutation: ADD_USER,
        variables: payload,
      });

      console.log('data', data);
			commit('setLoading', false);
			commit('setUser', data.createUser);
    } catch (err) {
			commit('setError', err.message)
    }
  },
  login: ({ commit }, payload) => {
    commit('setLoading', true);
    console.log('payload', payload);
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
