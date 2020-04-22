import Vue from 'vue';
import Vuetify from 'vuetify';
import { mount, createLocalVue } from '@vue/test-utils';
import Navbar from '@/components/Navigation/Navbar.vue';

Vue.use(Vuetify);

const localVue = createLocalVue();

describe('Navbar', () => {
  let vuetify;
  beforeEach(() => {
    vuetify = new Vuetify();
  });

  it('should render', () => {
    const wrapper = mount(Navbar, {
      localVue,
      vuetify,
      propsData: {
        user: {},
        toggleDrawer: jest.fn(),
      },
    });
    
    expect(wrapper.isVueInstance()).toBe(true);
    expect(wrapper).toMatchSnapshot();
  });
});
