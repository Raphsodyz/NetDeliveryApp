<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <h5>Um momento, as informações estão sendo carregadas...</h5>
        </div>
        <div id="features-wrapper">
            <b-container fluid>
                <b-row>
                    <div class="col-6 col-12-small" v-if="carrinho.length">
                        <h3>Confira seu pedido:</h3>
                        <ul v-for="p in carrinho" :key="p.produto.id">
                            <li class="carrinhoLista">
                                <b-img style="vertical-align: middle;" v-bind="mainProps" rounded :src="p.produto.foto" fluid alt="p.produto.nome"></b-img>
                                <span class="carrinhoTexto">
                                    &nbsp; &nbsp;{{p.quantidade}}&nbsp;{{p.produto.nome}}
                                    <br />
                                    &nbsp; &nbsp;{{p.observacao}}
                                    <br />
                                    <template class="carrinhoTexto" v-for="a in p.acrescimos">
                                        &nbsp; &nbsp;+ {{a.nome}}
                                    </template>
                                </span>
                            </li>
                        </ul>
                    </div>
                    <template v-else>
                        <h4>Nada aqui para chamar de meu...</h4>
                    </template>
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
                carrinho: [],
                mainProps: { blank: false, blankColor: '#777', width: 120, height: 120, class: 'm1' },
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
                    this.carrinho = false;
                    break;
                default:
                    console.log('Erro ao abrir o carrinho.');
                    break;
            }
        },
        methods: {
            fetchData() {
                this.loading = false;
            },
        }
    });
</script>