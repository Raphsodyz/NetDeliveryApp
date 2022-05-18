import Vue from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import { library } from '@fortawesome/fontawesome-svg-core'
import { faBurger } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

library.add(faBurger);
Vue.component('font-awesome-icon', FontAwesomeIcon);

Vue.use(BootstrapVue);

require('../public/css/Styles.css');
require('../public/css/noscript.css');
require('../public/css/fontawesome-all.min.css');

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')