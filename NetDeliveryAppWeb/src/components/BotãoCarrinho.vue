<template>
    <div v-if="temItens">
        <b-button block to="/Carrinho" class="button" id="carrinhoBtn">Carrinho <font-awesome-icon icon="fa-solid fa-burger" /></b-button>
    </div>
</template>

<script>
    export default {
        name: 'botaocarrinho',
        props: {
            temItens: Boolean,
        }
    }
</script>