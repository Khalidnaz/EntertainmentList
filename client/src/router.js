import Vue from 'vue';
import Router from 'vue-router';
// import ProtectedRoute from './ProtectedRoute';

// components
import Register from './components/Auth/Register.vue';
import Login from './components/Auth/Login.vue';
import MovieList from './components/Movie/MovieList.vue';
import Settings from './components/Settings/Settings.vue';
import Home from './components/Home/Home.vue'

Vue.use(Router);

export default new Router({
	mode: 'history',
	base: process.env.BASE_URL,
	routes: [
		{
			path: '/register',
			name: 'register',
			component: Register
		},
		{
			path: '/login',
			name: 'login',
			component: Login
		},
		{
			path: '/movies',
			name: 'movies',
			component: MovieList,
		},
		{
			path: '/settings',
			name: 'settings',
			component: Settings,
		},
		{
			path: '/',
			name: 'home',
			component: Home
		},
	]
}) 