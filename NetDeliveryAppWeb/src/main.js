import Vue from 'vue'
import App from './App.vue'
import router from './router'

require('../public/css/Styles.css');
require('../public/css/noscript.css');
require('../public/css/fontawesome-all.min.css');

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
