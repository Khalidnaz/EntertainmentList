import Vue from 'vue';
import Vuetify from 'vuetify/lib';

Vue.use(Vuetify);

export default new Vuetify({
  iconfont: 'md',
  theme: {
    primary: '#3B125F',
    secondary: '#8B5FBF',
		accent: '#E62E09',
    error: '#722530',
    warning: '#A37513',
    info: '#396893',
    success: '#4CAF50'
  }
});
