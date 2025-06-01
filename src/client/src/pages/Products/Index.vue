<template>
    <div class="row row-cards">
        <div class="col-md-6 col-lg-4 col-sm-12" v-for="p in products" :key="p.id">
            <div class="card product" @click="() => goToProposal(p.id)">
                <div class="ribbon bg-red">{{ p.price }} ₺</div>
                <div class="row row-0">
                    <div class="col-4">
                        <img src="/img/photos/product.jpg"
                            class="w-100 h-100 object-cover card-img-start"
                            alt="Product" />
                    </div>
                    <div class="col">
                        <div class="card-body">
                            <h3 class="card-title">{{ p.name }}</h3>
                            <p class="text-secondary">
                                {{ p.description }}
                            </p>
                        </div>
                        <div class="card-footer">
                            <div class="d-flex justify-content-between">
                                <span class="text-secondary small">İlana Çıkış</span>
                                <span class="text-secondary small">{{ getTime(p.createdAt) }}</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import ajaxHelper from '../../helpers/ajaxHelper';
export default {
    name: "Products",
    data() {
        return {
            products: []
        }
    },
    mounted() {
        ajaxHelper.get("api/client/products/latest")
            .then(result => {
                this.products = result.data;
            });
    },
    methods: {
        getTime(date) {
            return this.$moment(new Date(date)).fromNow();
        },
        goToProposal(id) {
            this.$router.push("/products/" + id);
        }
    }
}
</script>
<style scoped>
    .card.product :hover{
        cursor: pointer;
        background-color: #CCC;
    }
</style>