import Vue from 'vue'
import VueRouter from 'vue-router'
import Dashobard from '@/views/Dashboard.vue'
import LiveMatch from '@/views/LiveMatchStats.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Dashobard
  },
  {
    path: '/match/:serverSteamId',
    name: 'home',
    component: LiveMatch
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '@/views/About.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
