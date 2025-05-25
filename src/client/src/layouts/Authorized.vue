<template>
<div class="page">
    <header class="navbar navbar-expand-md d-print-none">
      <div class="container-xl">
        <div class="navbar-brand navbar-brand-autodark d-none-navbar-horizontal pe-0 pe-md-3">
          <a href="/">
            <img src="/img/logo.svg" />
          </a>
        </div>
        <div class="navbar-nav flex-row order-md-last" v-if="isSignedIn">
          <div class="d-none d-md-flex">
            <div class="nav-item dropdown d-none d-md-flex">
              <a href="#" class="nav-link px-0" data-bs-toggle="dropdown" tabindex="-1" aria-label="Show notifications"
                data-bs-auto-close="outside" aria-expanded="false">
                <img src="/img/bell.svg" />
                <span class="badge bg-red"></span>
              </a>
              <div class="dropdown-menu dropdown-menu-arrow dropdown-menu-end dropdown-menu-card" >
                <Notifications />
              </div>
            </div>
          </div>
          <User />
        </div>
        <div class="navbar-nav flex-row order-md-last" v-else>
          <a class="nav-link px-0" href="login">Giriş Yap</a>
        </div>
      </div>
    </header>

    <div class="page-wrapper">
      <div class="page-header d-print-none">
        <div class="container-xl">
          <div class="row g-2 align-items-center">
            <div class="col">
              <h2 class="page-title">Müzayede</h2>
            </div>
          </div>
        </div>
      </div>
      <div class="page-body">
        <div class="container-xl">
          <Home />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Notifications from "../components/Notifications.vue";
import User from "../components/User.vue";
import Home from "../pages/Home/Home.vue"
export default {
  name: "Authorized",
  components: {
    Home,
    User, 
    Notifications
  },
  data() {
    return {
      isSignedIn: false
    }
  },
  beforeMount() {
    let token = window.localStorage.getItem("token");
    if (token) {
      this.isSignedIn = true;
    }
  }
}
</script>