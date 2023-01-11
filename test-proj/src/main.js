import { createApp } from 'vue';

import App from './App.vue';
import Sub from './components/HelloWorld.vue';

const app = createApp(App);
app.component('friend-element',Sub)
app.mount('#app');
