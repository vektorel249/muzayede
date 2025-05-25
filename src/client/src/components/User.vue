<template>
    <div class="nav-item dropdown">
        <a href="#" class="nav-link d-flex lh-1 p-0 px-2" data-bs-toggle="dropdown" aria-label="Open user menu">
            <span class="avatar avatar-sm" style="background-image: url(/img/jelert.jpg)"> </span>
            <div class="d-none d-xl-block ps-2">
                <div>{{ displayname }}</div>
                <div class="mt-1 small text-secondary">Kullanıcı</div>
            </div>
        </a>
        <div class="dropdown-menu dropdown-menu-end dropdown-menu-arrow">
            <a href="#" class="dropdown-item">Status</a>
            <a href="./profile.html" class="dropdown-item">Profile</a>
            <a href="#" class="dropdown-item">Feedback</a>
            <div class="dropdown-divider"></div>
            <a href="./settings.html" class="dropdown-item">Settings</a>
            <a @click="signOut" class="dropdown-item">Çıkış Yap</a>
        </div>
    </div>
</template>
<script>
export default {
    name: "User",
    data() {
        return {
            displayname: null
        }
    },
    mounted() {
        this.displayname = window.localStorage.getItem("displayName");
    },
    methods: {
        signOut() {
            window.localStorage.removeItem("token");
            window.location.reload();
        }
    }
}
</script>