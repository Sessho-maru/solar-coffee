<template>
  <div id="app">
    <div class="menu">
      <SideMenu />
    </div>
    <div class="content">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SideMenu from './components/SideMenu.vue';

@Component({
    name: 'App',
    components: { SideMenu }
})

export default class App extends Vue {}
</script>

<style lang="scss">
@import "@/scss/global.scss";

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  display: flex;

  .menu {
    position: fixed;
  }

  .content {
    padding: 1.2rem;
    width: 90%;
    margin: 1rem auto 1rem $menu-width;
    text-align: left;
  }

  a {
    text-decoration: none;
  }

  hr {
    border: 1px solid #eee;
    margin: 1rem 0;
  }
}
</style>
