const state = {
  user: null,
  loading: false,
  error: null
};

const getters = {
  user: state => state.user,
  loading: state => state.loading,
  error: state => state.error
};

const actions = {
  registerUser: ({ commit }, payload) => {
    commit('setLoading', true);
    console.log('payload', payload);
  },
  login: ({ commit }, payload) => {
		commit('setLoading', true);
		console.log('payload', payload)
	},
	logout: ({ commit }) => commit('clearUser')
};

const mutations = {
  setLoading: (state, payload) => (state.loading = payload),
	setError: (state, payload) => (state.error = payload),
	clearUser: state => state.user = null
};

export default {
  state,
  getters,
  actions,
  mutations
};
