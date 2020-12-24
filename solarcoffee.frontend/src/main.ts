import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import moment from "moment";

Vue.config.productionTip = false;

Vue.filter('price', (num: number) => {
  if(isNaN(num))
  {
    return '-';
  }
  return '$ ' + num.toFixed(2);
});

Vue.filter('humanizeDate', (date: Date) => {
  return moment(date).format('MMMM Do YYYY');
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
