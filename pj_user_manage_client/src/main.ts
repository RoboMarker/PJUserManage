import { createApp, watch } from 'vue'
import App from './App.vue'
import router from './router'

import 'element-plus/dist/index.css'
import ElementPlus, { ElTable } from 'element-plus';

// 解决 ElTable 自动宽度高度导致的「ResizeObserver loop limit exceeded」问题
const fixElTableErr = (table: any) => { // 使用 any 类型来暂时处理
    let resizeObserver: ResizeObserver | null = null;
  
    const observeResize = () => {
      if (resizeObserver) {
        resizeObserver.disconnect();
      }
      resizeObserver = new ResizeObserver(() => {
        table.doLayout();
      });
      const el = table.$el.querySelector('.el-table__body-wrapper');
      if (el) {
        resizeObserver.observe(el);
      }
    };
  
    watch(
      () => table.store.states.data,
      () => {
        observeResize();
      },
      { immediate: true }
    );
  
    window.addEventListener('resize', () => {
      observeResize();
    });
  };
var myapp=createApp(App);

myapp.use(ElementPlus);
myapp.use(router).mount('#app')
