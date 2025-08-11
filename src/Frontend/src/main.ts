import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import { inlineFields } from './plugins/inlineFields';

import 'vuetify/styles';
import { createVuetify } from 'vuetify';
import * as components from 'vuetify/components';
import * as directives from 'vuetify/directives';

const vuetify = createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'system',
  },
});

const app = createApp(App).use(router).use(vuetify).use(inlineFields);

app.mount('#app');
