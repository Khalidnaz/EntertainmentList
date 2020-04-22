import { API_KEY } from '../../config';
import axios from 'axios';

const BASE_URL = 'https://api.themoviedb.org/3';

const state = {
  upcoming: [],
  topRated: [],
  nowPlaying: [],
  movieLoading: false,
  genres: {},
};

const getters = {
  upcoming: (state) => state.upcoming,
  topRated: (state) => state.topRated,
  nowPlaying: (state) => state.nowPlaying,
  movieLoading: (state) => state.movieLoading,
  genres: (state) => state.genres,
};

const actions = {
  fetchNowPlaying: async ({ commit }, pageNum = 1) => {
    commit('setMovieLoading', true);

    const { data } = await axios.get(
      `${BASE_URL}/movie/now_playing?api_key=${API_KEY}&language=en-US&page=${pageNum}`
    );

    commit('setNowPlaying', data.results);
    commit('setMovieLoading', false);
  },

  getGenres: async ({ commit }) => {
    const { data } = await axios.get(
      `${BASE_URL}/genre/movie/list?api_key=${API_KEY}&language=en-US`
    );

    const genreHash = {};

    data.genres.forEach((genre) => {
      genreHash[genre.id] = genre.name;
    });
		console.log('hash', genreHash)
    commit('setGenres', genreHash);
  },
};

const mutations = {
  setMovieLoading: (state, payload) => (state.movieLoading = payload),
  setUpcoming: (state, payload) => (state.upcoming = payload),
  setTopRated: (state, payload) => (state.topRated = payload),
  setNowPlaying: (state, payload) => (state.nowPlaying = payload),
  setGenres: (state, payload) => (state.genres = payload),
};

export default {
  state,
  getters,
  actions,
  mutations,
};
