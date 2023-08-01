<template>
  <div class="common-layout">
    <el-container>
      <el-header
        >Header
        <nav>
          <router-link to="/">Home</router-link> |
          <router-link to="/about">About</router-link>|
          <router-link to="/MenuList">MenuList</router-link>
        </nav>
      </el-header>
      <el-container>
        <el-aside width="200px"> <Menu /></el-aside>
        <el-container>
          <el-main>
            <router-view></router-view>
          </el-main>
          <el-footer>Footer</el-footer>
        </el-container>
      </el-container>
    </el-container>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, reactive } from "vue";
import Menu from "./components/Menu/Menu.vue";
import { ElContainer, ElHeader, ElAside, ElMain, ElFooter } from "element-plus";
import { default as axios } from "axios";

export default defineComponent({
  name: "Main",
  components: {
    ElContainer,
    ElHeader,
    ElAside,
    ElMain,
    ElFooter,
    Menu,
  },
  setup() {
    // var loginToken=  localStorage.getItem('loginToken');
    return {};
  },
});
</script>


<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>
