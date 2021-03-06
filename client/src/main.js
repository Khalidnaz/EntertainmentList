import Vue from 'vue';
import App from './App.vue';
import vuetify from './plugins/vuetify';
import router from './router';
import store from './store/store';
import apolloProvider from './plugins/apollo';

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  vuetify,
  apolloProvider,
  render: (h) => h(App),
  created() {
		const user = localStorage.getItem('user');
		
    if (user) {
			this.$store.commit('setUser', JSON.parse(user));
    }
  },
}).$mount('#app');
