<template>
  <Anonymous v-if="needsLogin" />
  <Authorized v-else />
</template>

<script>
import Anonymous from "./Layouts/Anonymous.vue";
import Authorized from "./layouts/Authorized.vue";
export default {
  name: "App",
  components: {
    Authorized,
    Anonymous
  },
  data() {
    return {
      needsLogin: false
    }
  },
  beforeMount() {
    let isLogin = window.location.pathname == "/login";
    if (isLogin) {
      this.needsLogin = true;
    }
  }
}
</script>