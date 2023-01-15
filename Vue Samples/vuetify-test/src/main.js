import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import VueRouter from 'vue-router'

import routes from './router.js';

Vue.config.productionTip = false


Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes // short for `routes: routes`
})


const app = new Vue({
  vuetify,
  render: h => h(App),
  router:router
});

app.$mount('#app');
