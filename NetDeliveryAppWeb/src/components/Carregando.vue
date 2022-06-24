<template>
    <div>
        <b-overlay :show="show" rounded="sm" class="loading"></b-overlay>
    </div>
</template>

<script>
    export default {
        name: 'carregando',
        props:{
            show: Boolean
        }
    }
</script>