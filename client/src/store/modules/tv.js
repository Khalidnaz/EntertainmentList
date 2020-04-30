import { API_KEY } from "../../config";
import axios from "axios";

const BASE_URL = "https://api.themoviedb.org/3";

const state = {
  tv: [],
  tvLoading: false,
  genres: {},
};

const getters = {
  tv: (state) => state.tv,
  tvLoading: (state) => state.tvLoading,
  tvGenres: (state) => state.genres,
};

const actions = {
  fetchTv: async ({ commit }, section, pageNum = 1) => {
    commit("setTvLoading", true);

    const { data } = await axios.get(
      `${BASE_URL}/tv/${section}?api_key=${API_KEY}&language=en-US&page=${pageNum}`
    );

    commit("setNowPlaying", data.results);
    commit("setTvLoading", false);
  },

  getGenres: async ({ commit }) => {
    const { data } = await axios.get(
      `${BASE_URL}/genre/tv/list?api_key=${API_KEY}&language=en-US`
    );

    const genreHash = {};

    data.genres.forEach((genre) => {
      genreHash[genre.id] = genre.name;
    });

    commit("setGenres", genreHash);
  },
};

const mutations = {
  setTvLoading: (state, payload) => (state.tvLoading = payload),
  setUpcoming: (state, payload) => (state.tv = payload),
  setTopRated: (state, payload) => (state.tv = payload),
  setNowPlaying: (state, payload) => (state.tv = payload),
  setGenres: (state, payload) => (state.genres = payload),
};

export default {
  state,
  getters,
  actions,
  mutations,
};
