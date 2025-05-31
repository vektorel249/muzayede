<template>
  <div class="row g-0 flex-fill">
    <div class="col-12 col-lg-6 col-xl-4 border-top-wide border-primary d-flex flex-column justify-content-center">
      <router-view />
    </div>
    <div class="col-12 col-lg-6 col-xl-8 d-none d-lg-block">
      <div class="bg-cover h-100 min-vh-100" style="background-image: url(./img/photos/login-1.jpg)"></div>
    </div>
  </div>
</template>
<script>
export default {
  name: "Anonymous",
  
}
</script>