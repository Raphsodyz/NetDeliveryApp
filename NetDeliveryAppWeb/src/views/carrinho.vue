<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <h5>Um momento, as informações estão sendo carregadas...</h5>
        </div>
        <div id="features-wrapper">
            <div class="container">
                <div class="row" v-if="carrinho.length === 2">
                    <h4>Nada aqui para chamar de meu...</h4>
                </div>
                <div class="row" v-else>
                    <div class="col-6 col-12-small">
                        <ul>
                            <li></li>
                        </ul>
                    </div>
                </div>
            </div>
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
                    console.log(this.carrinho);
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
                this.loading = true;

                fetch('Acrescimos/Listar')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>