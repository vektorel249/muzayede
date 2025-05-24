<template>
    <div class="card">
                <div class="card-header">
                    <h3 class="card-title">{{ title }}</h3>
                </div>
                <div class="card-body">
                    <Carousel :id="id" />
                </div>
            </div>
</template>
<script>
import Carousel from './Carousel.vue';
export default {
    props: {
        id: {
            type: String,
            required: true
        },
        title: {
            type: String,
            required: true
        }
    },
    name: "HomeCard",
    components: {
        Carousel
    }
}
</script>