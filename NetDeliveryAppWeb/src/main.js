import Vue from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.use(BootstrapVue)

require('../public/css/Styles.css');
require('../public/css/noscript.css');
require('../public/css/fontawesome-all.min.css');

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')