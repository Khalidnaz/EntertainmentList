import { API_KEY } from '../../config';
import axios from 'axios';

const BASE_URL = 'https://api.themoviedb.org/3';

const state = {
  movies: [],
  movieLoading: false,
  genres: {},
};

const getters = {
  movies: (state) => state.movies,
  movieLoading: (state) => state.movieLoading,
  genres: (state) => state.genres,
};

const actions = {
  fetchMovies: async ({ commit }, section, pageNum = 1) => {
    commit('setMovieLoading', true);

    const { data } = await axios.get(
      `${BASE_URL}/movie/${section}?api_key=${API_KEY}&language=en-US&page=${pageNum}`
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
		
    commit('setGenres', genreHash);
  },
};

const mutations = {
  setMovieLoading: (state, payload) => (state.movieLoading = payload),
  setUpcoming: (state, payload) => (state.movies = payload),
  setTopRated: (state, payload) => (state.movies = payload),
  setNowPlaying: (state, payload) => (state.movies = payload),
  setGenres: (state, payload) => (state.genres = payload),
};

export default {
  state,
  getters,
  actions,
  mutations,
};
