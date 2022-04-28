import Vue from 'vue'
import VueRouter from 'vue-router'
import Index from '../views/Index.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Inicio',
    component: Index
  },
  {
    path: '/Cadastro',
    name: 'Cadastro',
    component: () => import('../views/cadastro.vue')
  },
  {
    path: '/Carrinho',
    name: 'Carrinho',
    component: () => import('../views/carrinho.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
