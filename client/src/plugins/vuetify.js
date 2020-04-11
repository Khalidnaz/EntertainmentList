import Vue from 'vue';
import Vuetify from 'vuetify/lib';

Vue.use(Vuetify);

export default new Vuetify({
  iconfont: 'md',
  theme: {
   themes: {
     dark: {
      // primary: '#3B125F',
      secondary: '#424242',
      accent: '#E62E09',
      error: '#F70528',
      warning: '#A37513',
      info: '#396893',
      success: '#4CAF50'
     }
   }
  }
});
