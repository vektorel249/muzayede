<template>
  <component :is="layout">
    <router-view />
  </component>
</template>

<script>
import Authorized from './layouts/Authorized.vue';
import Anonymous from './layouts/Anonymous.vue';
export default {
  name: "App",
  components: {
    Authorized,
    Anonymous
  },
  computed: {
    layout(){
      const layout = this.$route.meta.layout;
      if (!layout) {
        return null;
      }
      if (layout == "main") {
        return Authorized;  
      }
      else if (layout == "anon") {
        return Anonymous;
      }
      return null;
    }
  }
}
</script>