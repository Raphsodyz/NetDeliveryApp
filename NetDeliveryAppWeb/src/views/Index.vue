<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Um momento, as informações estão sendo carregadas...
        </div>
        <div v-if="post" class="content">
            <div>
                <b-modal centered
                         id="modal-1"
                         size="lg"
                         title-tag="h2"
                         no-close-on-backdrop
                         :title="modal.nome">
                    <b-img-lazy :src="modal.foto" fluid-grow :alt="modal.nome" />
                    <p class="my-4">{{modal.ingredientes}}</p>
                    <b-form></b-form>
                </b-modal>
            </div>
            <h1>Hamburguers</h1>
            <div id="features-wrapper">
                <div class="container">
                    <div class="row">
                        <div class="col-4 col-12-medium" v-for="produtos in categoria1" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2>{{produtos.nome}}</h2>
                                        <h3>R${{produtos.valor}}</h3>
                                    </header>
                                    <p>{{produtos.ingredientes}}</p>
                                </div>
                            </section>
                        </div>
                        <h1>Bebidas</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria2" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2>{{produtos.nome}}</h2>
                                        <h3>R${{produtos.valor}}</h3>
                                    </header>
                                    <p class="card-text">{{produtos.ingredientes}}</p>
                                </div>
                            </section>
                        </div>
                        <h1>Sucos</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria3" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2>{{produtos.nome}}</h2>
                                        <h3>R${{produtos.valor}}</h3>
                                    </header>
                                    <p>{{produtos.ingredientes}}</p>
                                </div>
                            </section>
                        </div>
                        <h1>Cervejas</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria4" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
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
    
import axios from 'axios';
import Vue from 'vue';

    export default
        Vue.extend({
            data() {
                return {
                    loading: false,
                    post: null,
                    modal:{},
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
                },
                capturar(id) {
                    var selecionado = id;
                    axios.get('https://localhost:5001/api/Produtos/Encontrar/' + selecionado.toString())
                        .then((resposta) => {
                            this.modal = resposta.data
                        })
                        .catch((error) => {
                            console.log(error);
                        });
                }
            },
            computed: {
                categoria1: function () {
                    return this.post.filter(function (posts) {
                        return posts.categoria.id === 1
                    })
                },
                categoria2: function () {
                    return this.post.filter(function (posts) {
                        return posts.categoria.id === 2
                    })
                },
                categoria3: function () {
                    return this.post.filter(function (posts) {
                        return posts.categoria.id === 3
                    })
                },
                categoria4: function () {
                    return this.post.filter(function (posts) {
                        return posts.categoria.id === 4
                    })
                }
            }
        });
</script>