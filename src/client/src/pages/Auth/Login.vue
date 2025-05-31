<template>
<div class="container container-tight my-5 px-lg-5">
        <div class="text-center mb-4">
          <a href="#" class="navbar-brand navbar-brand-autodark">
            <img src="/img/logo.svg" />
          </a>
        </div>
        <h2 class="h3 text-center mb-3">Mesabına Giriş Yap</h2>
        <div class="mb-3">
          <label class="form-label">Mail Adresi</label>
          <input type="email" v-model="form.mail" class="form-control" placeholder="your@email.com"
            autocomplete="off" />
        </div>
        <div class="mb-2">
          <label class="form-label">
            Parola
            <span class="form-label-description">
              <a href="./forgot-password.html">Parolamı Unuttum</a>
            </span>
          </label>
          <div class="input-group input-group-flat">
            <input type="password" v-model="form.password" class="form-control" placeholder="Your password"
              autocomplete="off" />
            <span class="input-group-text">
              <a href="#" class="link-secondary" title="Show password" data-bs-toggle="tooltip">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none"
                  stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"
                  class="icon icon-1">
                  <path d="M10 12a2 2 0 1 0 4 0a2 2 0 0 0 -4 0" />
                  <path d="M21 12c-2.4 4 -5.4 6 -9 6c-3.6 0 -6.6 -2 -9 -6c2.4 -4 5.4 -6 9 -6c3.6 0 6.6 2 9 6" />
                </svg>
              </a>
            </span>
          </div>
        </div>
        <div class="mb-2">
          <label class="form-check">
            <input type="checkbox" class="form-check-input" />
            <span class="form-check-label">Beni Hatırla</span>
          </label>
        </div>
        <div class="form-footer">
          <button @click="signIn" class="btn btn-primary w-100">Giriş Yap</button>
        </div>
        <div class="text-center text-secondary mt-3">Hesabın yok mu? <a href="#" tabindex="-1">Kayıt Ol</a></div>
      </div>
</template>
<script>
import ajaxHelper from '../../helpers/ajaxHelper';
export default {
    name: "Login",
    data() {
    return {
      form: {
        mail: null,
        password: null
      }
    }
  },
  methods: {
    signIn() {
      const model = { mail: this.form.mail, password: this.form.password };
      ajaxHelper.post("api/authentication/sign-in", model)
        .then(apiResult => {
          if (apiResult.succeeded) {
            window.localStorage.setItem("token", apiResult.data.token);
            window.localStorage.setItem("displayName", apiResult.data.displayName);
            window.location.replace("/");
          }
        });
    }
  }
}
</script>