import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import VueRouter from 'vue-router'
import Vuex from 'vuex'

import routes from './router.js';
import storeConfig from './store'

Vue.config.productionTip = false


Vue.use(VueRouter);
Vue.use(Vuex);

const router = new VueRouter({
  mode: 'history',
  routes // short for `routes: routes`
})

const store = new Vuex.Store(storeConfig);

const app = new Vue({
  vuetify,
  render: h => h(App),
  router:router,
  store:store
});

app.$mount('#app');
