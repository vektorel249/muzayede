<template>
    {{ products }}
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
                  .then(result=> {
                    this.products = result.data;
                  });
    }
}
</script>