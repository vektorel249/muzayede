<template>
    <div :id="id" class="carousel slide carousel-fade" data-bs-ride="carousel">
        <div class="carousel-indicators carousel-indicators-dot">
            <button type="button" :data-bs-target="'#' + id" data-bs-slide-to="0"
                class="active"></button>
            <button type="button" :data-bs-target="'#' + id" data-bs-slide-to="1" class=""></button>
            <button type="button" :data-bs-target="'#' + id" data-bs-slide-to="2" class=""></button>
            <button type="button" :data-bs-target="'#' + id" data-bs-slide-to="3" class=""></button>
            <button type="button" :data-bs-target="'#' + id" data-bs-slide-to="4" class=""></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img class="d-block w-100" alt="" src="/img/photos/1.jpg" />
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" alt="" src="/img/photos/2.jpg" />
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" alt="" src="/img/photos/3.jpg" />
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" alt="" src="/img/photos/4.jpg" />
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" alt="" src="/img/photos/5.jpg" />
            </div>
        </div>
    </div>
</template>
<script>
export default {
    props: {
        id: {
            type: String,
            required: true
        }
    },
    name: "Carousel"
}
</script>