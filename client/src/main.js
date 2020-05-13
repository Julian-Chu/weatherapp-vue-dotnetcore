import Vue from "vue";
import App from "./App.vue";
import "./assets/style_grid.css";
import "./assets/fonts/font-awesome.min.css";

Vue.config.productionTip = false;

new Vue({
  render: h => h(App)
}).$mount("#app");
