<template>
    <div class="row row-cards">
        <div class="col-sm-6 col-lg-3">
            <div class="card card-sm">
                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col-auto">
                            <icon symbol="try" bg-color="purple" />
                        </div>
                        <div class="col">
                            <div class="font-weight-medium">{{ productCount }} Ürün</div>
                            <div class="text-secondary"><RouterLink to="/products">Hemen Gözat</RouterLink></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6 col-lg-3">
            <div class="card card-sm">
                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col-auto">
                            <icon symbol="bell" bg-color="yellow" color="#333" />
                        </div>
                        <div class="col">
                            <div class="font-weight-medium">14 Yorum</div>
                            <div class="text-secondary">6 cevaplanmamış</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6 col-lg-3">
            <div class="card card-sm">
                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col-auto">
                            <icon symbol="eye" />
                        </div>
                        <div class="col">
                            <div class="font-weight-medium">{{ proposalCount }} Gün İçi Teklif</div>
                            <div class="text-secondary">Fırsatı Kaçırma!</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6 col-lg-3">
            <div class="card card-sm">
                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col-auto">
                            <icon symbol="thumbs-up" />
                        </div>
                        <div class="col">
                            <div class="font-weight-medium">17 Beğeni</div>
                            <div class="text-secondary">4 bugün</div>
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import ajaxHelper from "../../../helpers/ajaxHelper";
export default {
    name: "Navigation",
    data() {
        return {
            productCount: 0,
            proposalCount: 0
        }
    },
    mounted() { // yüklendiğinde
        ajaxHelper.get("api/statistics/active-products")
                  .then(result => {
                    this.productCount = result.data;
                  });
        ajaxHelper.get("api/statistics/daily-proposals")
                  .then(result => {
                    this.proposalCount = result.data;
                  });
    }
}
</script>