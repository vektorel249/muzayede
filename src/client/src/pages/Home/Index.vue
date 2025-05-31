<template>
    <div class="row row-deck row-cards">
        <div class="col-12">
            <Navigation />
        </div>
        <div class="col-md-6">
            <HomeCard id="car-1" title="Öne Çıkanlar" />
        </div>
        <div class="col-md-6">
            <HomeCard id="car-2" title="Yeni Eklenenler" />
        </div>
    </div>
</template>

<script>
import HomeCard from './components/HomeCard.vue';
import Navigation from './components/Navigation.vue';
export default {
    name: "Home",
    components: {
        Navigation,
        HomeCard
    }
}
</script>