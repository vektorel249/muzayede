<template>
  <component :is="layout">
    <router-view />
  </component>
</template>

<script>
import MainLayout from './layouts/MainLayout.vue';
import Anonymous from './layouts/Anonymous.vue';
export default {
  name: "App",
  components: {
    MainLayout,
    Anonymous
  },
  mounted() {
    this.$moment.locale("tr");
  },
  computed: {
    layout(){
      const layout = this.$route.meta.layout;
      if (!layout) {
        return null;
      }
      if (layout == "main") {
        return MainLayout;  
      }
      else if (layout == "anon") {
        return Anonymous;
      }
      return null;
    }
  }
}
</script>