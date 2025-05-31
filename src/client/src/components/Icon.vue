<template>
    <div class="btn btn-icon p-2" :class="'bg-'+ bgColor">
        <FontAwesomeIcon :icon="['fas', symbol]" :style="{ color: color }"></FontAwesomeIcon>
    </div>
</template>
<script>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
export default {
    name: "Icon",
    props: {
        symbol: {
            type: String,
            required: true
        },
        bgColor: {
            type: String,
            default: "blue"
        },
        color: {
            type: String,
            default: "white"
        }
    },
    components: {
        FontAwesomeIcon
    }
}
</script>