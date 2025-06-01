<template>
    <div v-if="product != null">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <img src="/img/photos/product.jpg" class="card-img-top" alt="Ürün Görseli">
                </div>
            </div>

            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h1 class="card-title">{{ product.name }}</h1>
                        <h3 class="text-success">{{ product.price }} ₺</h3>

                        <ul class="list-unstyled">
                            <li><strong>Oluşturma Tarihi :</strong> {{ format(product.createdAt) }}</li>
                            <li><strong>Tahtaya Eklenme :</strong> {{ fromNow(product.createdAt) }}</li>
                        </ul>

                        <div class="mt-4">
                            <button class="btn btn-outline-primary">
                                <FontAwesomeIcon :icon="['fas', 'handshake']"></FontAwesomeIcon>
                                Teklif Ver
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <ul class="nav nav-tabs card-header-tabs" data-bs-toggle="tabs">
                            <li class="nav-item">
                                <a href="#description" class="nav-link active" data-bs-toggle="tab">Açıklama</a>
                            </li>
                            <li class="nav-item">
                                <a href="#proposals" class="nav-link" data-bs-toggle="tab">Teklifler</a>
                            </li>
                            <li class="nav-item">
                                <a href="#comments" class="nav-link" data-bs-toggle="tab">Yorumlar</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card-body">
                        <div class="tab-content">
                            <div class="tab-pane active show" id="description">
                                <p>{{ product.description }}</p>
                            </div>
                            <div class="tab-pane" id="proposals">
                                <ul>
                                    <li>Özellik 1</li>
                                    <li>Özellik 2</li>
                                    <li>Özellik 3</li>
                                </ul>
                            </div>
                            <div class="tab-pane" id="comments">
                                <div class="card" v-if="product.comments.length > 0">
                                    <div class="card-body">
                                        <div class="divide-y">
                                            <div class="row" v-for="c in product.comments">
                                                <div class="col-auto">
                                                    <span class="avatar avatar-1"
                                                        style="background-image: url('/img/jelert.jpg')"> </span>
                                                </div>
                                                <div class="col">
                                                    <div class="text-truncate">
                                                        <p><strong>{{ c.user }}</strong> - {{ c.comment }}</p>
                                                    </div>
                                                    <div class="text-secondary">{{ fromNow(c.createdAt) }}</div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="alert alert-info alert-dismissible" role="alert" v-else>
                                    <div class="alert-icon">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24"
                                            viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"
                                            stroke-linecap="round" stroke-linejoin="round"
                                            class="icon alert-icon icon-2">
                                            <path d="M3 12a9 9 0 1 0 18 0a9 9 0 0 0 -18 0" />
                                            <path d="M12 9h.01" />
                                            <path d="M11 12h1v4h1" />
                                        </svg>
                                    </div>
                                    <div>
                                        <h4 class="alert-heading">Henüz Yorum Yok</h4>
                                        <div class="alert-description">Ürün henüz bir yorum almadı. İlk yorumu yap ve
                                            teklifini ver.
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row row-cards" v-else>
        <div class="col-6">
            <div class="row row-cards">
                <div class="col-12">
                    <div class="card placeholder-glow">
                        <div class="ratio ratio-21x9 card-img-top placeholder"></div>
                        <div class="card-body">
                            <div class="placeholder col-9 mb-3"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="row row-cards">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body text-end placeholder-glow">
                            <div class="placeholder col-9 mb-3"></div>
                            <div class="placeholder placeholder-xs col-10"></div>
                            <div class="placeholder placeholder-xs col-12"></div>
                            <div class="placeholder placeholder-xs col-11"></div>
                            <div class="placeholder placeholder-xs col-8"></div>
                            <div class="placeholder placeholder-xs col-10"></div>
                            <div class="mt-3">
                                <a href="#" tabindex="-1" class="btn btn-primary disabled placeholder col-4"
                                    aria-hidden="true"></a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-12">
            <div class="col-12">
                <div class="card">
                    <ul class="list-group list-group-flush placeholder-glow">
                        <li class="list-group-item">
                            <div class="row align-items-center">
                                <div class="col-auto">
                                    <div class="avatar avatar-rounded placeholder"></div>
                                </div>
                                <div class="col-7">
                                    <div class="placeholder placeholder-xs col-9"></div>
                                    <div class="placeholder placeholder-xs col-7"></div>
                                </div>
                                <div class="col-2 ms-auto text-end">
                                    <div class="placeholder placeholder-xs col-8"></div>
                                    <div class="placeholder placeholder-xs col-10"></div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row align-items-center">
                                <div class="col-auto">
                                    <div class="avatar avatar-rounded placeholder"></div>
                                </div>
                                <div class="col-7">
                                    <div class="placeholder placeholder-xs col-9"></div>
                                    <div class="placeholder placeholder-xs col-7"></div>
                                </div>
                                <div class="col-2 ms-auto text-end">
                                    <div class="placeholder placeholder-xs col-8"></div>
                                    <div class="placeholder placeholder-xs col-10"></div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row align-items-center">
                                <div class="col-auto">
                                    <div class="avatar avatar-rounded placeholder"></div>
                                </div>
                                <div class="col-7">
                                    <div class="placeholder placeholder-xs col-9"></div>
                                    <div class="placeholder placeholder-xs col-7"></div>
                                </div>
                                <div class="col-2 ms-auto text-end">
                                    <div class="placeholder placeholder-xs col-8"></div>
                                    <div class="placeholder placeholder-xs col-10"></div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row align-items-center">
                                <div class="col-auto">
                                    <div class="avatar avatar-rounded placeholder"></div>
                                </div>
                                <div class="col-7">
                                    <div class="placeholder placeholder-xs col-9"></div>
                                    <div class="placeholder placeholder-xs col-7"></div>
                                </div>
                                <div class="col-2 ms-auto text-end">
                                    <div class="placeholder placeholder-xs col-8"></div>
                                    <div class="placeholder placeholder-xs col-10"></div>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import ajaxHelper from "../../helpers/ajaxHelper";
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
export default {
    name: "ProductDetail",
    components: {
        FontAwesomeIcon
    },
    data() {
        return {
            product: null
        }
    },
    mounted() {
        ajaxHelper.get("api/client/products/" + this.$route.params.id).then(result => {
            this.product = result.data;
        });
    },
    methods: {
        format(date) {
            return this.$moment(new Date(date)).format("DD/MM/YYYY");
        },
        fromNow(date) {
            return this.$moment(new Date(date)).fromNow();
        },
    }
}
</script>