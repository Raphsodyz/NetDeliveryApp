<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <h5>Um momento, as informações estão sendo carregadas...</h5>
        </div>
        <div id="features-wrapper">
            <b-container fluid>
                <b-row class="row" v-if="carrinho.length < 1">
                    <h4>Nada aqui para chamar de meu...</h4>
                </b-row>
                <b-row class="row" v-else>
                    <div class="col-6 col-12-small">
                        <h3>Confira seu pedido:</h3>
                        <ul v-for="produtos in carrinho" :key="produtos.produto.id">
                            <li class="carrinhoLista"><b-img v-bind="mainProps" rounded :src="produtos.produto.foto" fluid alt="produtos.produto.nome"></b-img>
                            {{produtos.quantidade}} - {{produtos.produto.nome}} com acrescimo de {{produtos.acrescimos.nome}}
                            </li>
                        </ul>
                    </div>
                </b-row>
            </b-container>
        </div>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';

    export default Vue.extend({
        data() {
            return {
                loading: false,
                post: null,
                carrinho: [],
                mainProps: { blank: false, blankColor: '#777', width: 100, height: 100, class: 'm1' },
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        mounted() {

            if (!localStorage.getItem("carrinho")) {
                localStorage.setItem("carrinho", JSON.stringify([]));
            }

            switch (true) {
                case localStorage.getItem("carrinho").length < 2:
                    localStorage.setItem("carrinho", JSON.stringify([]));
                    break;
                case localStorage.getItem("carrinho").length > 2:
                    this.carrinho = JSON.parse(atob(localStorage.getItem("carrinho")));
                    break;
                case localStorage.getItem("carrinho").length === 2:
                    this.carrinho = localStorage.getItem("carrinho");
                    break;
                default:
                    console.log('Erro ao abrir o carrinho.');
                    break;
            }
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = false;
            }
        },
    });
</script>