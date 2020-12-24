import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import Inventory from "@/views/Inventory.vue";
import Customer from "@/views/Customer.vue";
import Order from "@/views/Order.vue";
import InvoiceNew from "@/views/InvoiceNew.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Inventory
  },
  {
    path: '/inventory',
    name: 'Inventory',
    component: Inventory
  },
  {
    path: '/customers',
    name: 'Customers',
    component: Customer
  },
  {
    path: '/orders',
    name: 'Orders',
    component: Order
  },
  {
    path: '/invoice/new',
    name: 'InvoiceNew',
    component: InvoiceNew
  }
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});

export default router;