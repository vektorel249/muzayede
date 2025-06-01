import { createApp } from 'vue';
import { library } from '@fortawesome/fontawesome-svg-core';
import { fas } from '@fortawesome/free-solid-svg-icons';
import { createWebHistory, createRouter } from 'vue-router'
import moment from 'moment/moment';
import 'moment/locale/tr';

library.add(fas);
import App from './App.vue'
import Icon from './components/Icon.vue';

import Products from "./pages/Products/Index.vue"
import ProductDetail from "./pages/Products/Detail.vue"
import Home from "./pages/Home/Index.vue"
import Login from "./pages/Auth/Login.vue"

const routes = [
    { path: '/', component: Home, meta: { layout: "main"} },
    { path: '/products', component: Products, meta: { layout: "main"} },
    { path: '/products/:id', component: ProductDetail, meta: { layout: "main"} },
    { path: '/login', component: Login, meta: { layout: "anon"} },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

moment.locale("tr");

var app = createApp(App).use(router);
app.config.globalProperties.$moment = moment;
app.component("icon", Icon);
app.mount('#app')


