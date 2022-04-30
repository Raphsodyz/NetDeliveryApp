<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Um momento, as informações estão sendo carregadas...
        </div>
        <div v-if="post" class="content">
            <h1>Hamburguers</h1>
            <div id="features-wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-4 col-12-medium" v-for="produtos in post" :key="produtos.id">
                            <section class="box feature" v-if="produtos.categoria.id == 1">
                                <a href="#" class="image featured"><img :src="produtos.foto" alt="" /></a>
                                <div class="inner">
                                    <header>
                                        <h2>{{produtos.nome}}</h2>
                                        <h3>R${{produtos.valor}}</h3>
                                    </header>
                                    <p>{{produtos.ingredientes}}</p>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="js">
    import Vue from 'vue';

    export default
        Vue.extend({
            data() {
                return {
                    loading: false,
                    post: null,
                }
            },
            created() {
                this.fetchData();

            },
            watch: {
                '$route': 'fetchData'
            },
            methods: {
                fetchData() {
                    this.post = null;
                    this.loading = true;

                    fetch('Produtos/Listar')
                        .then(r => r.json())
                        .then(json => {
                            this.post = json;
                            this.loading = false;
                            return;
                        });
                }
            }
        });
</script>