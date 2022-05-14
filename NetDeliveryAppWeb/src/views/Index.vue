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
                        <div class="col-4 col-12-medium" v-for="produtos in categoria1" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2 class="titulo">{{produtos.nome}}</h2>
                                        <p class="card-text">{{produtos.ingredientes}}</p>
                                        <br />
                                        <h2 class="produto-valor">R${{produtos.valor}}</h2>
                                    </header>
                                </div>
                            </section>
                        </div>
                        <h1>Bebidas</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria2" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2 class="titulo">{{produtos.nome}}</h2>
                                        <p class="card-text">{{produtos.ingredientes}}</p>
                                        <br />
                                        <h2 class="produto-valor">R${{produtos.valor}}</h2>
                                    </header>
                                </div>
                            </section>
                        </div>
                        <h1>Sucos</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria3" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2 class="titulo">{{produtos.nome}}</h2>
                                        <p class="card-text">{{produtos.ingredientes}}</p>
                                        <br />
                                        <h2 class="produto-valor">R${{produtos.valor}}</h2>
                                    </header>
                                </div>
                            </section>
                        </div>
                        <h1>Cervejas</h1>
                        <div class="col-4 col-12-medium" v-for="produtos in categoria4" :key="produtos.id">
                            <section class="box feature">
                                <a v-b-modal.modal-1 @click="capturar(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                <div class="inner">
                                    <header>
                                        <h2 class="titulo">{{produtos.nome}}</h2>
                                        <p class="card-text">{{produtos.ingredientes}}</p>
                                        <br />
                                        <h2 class="produto-valor">R${{produtos.valor}}</h2>
                                    </header>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <b-modal centered
                         id="modal-1"
                         title-tag="h2"
                         body-class="b-row"
                         no-close-on-backdrop
                         :title="modal.nome"
                         v-model="show">
                    <b-img-lazy :src="modal.foto" fluid-grow :alt="modal.nome" />
                    <p class="my-4" style="text-align: center;
                                        font-family: 'PT Sans', sans-serif;
                                        font-size: medium;">
                        {{modal.ingredientes}}
                    </p>

                    <b-form-group id="entrada1"
                                  label="Alguma observação sobre o lanche?"
                                  label-for="observacao">
                        <b-form-textarea id="observacao"
                                      v-model="observacao"
                                      placeholder="Digite aqui!"
                                      rows="3"
                                      max-rows="6"
                        ></b-form-textarea>
                    </b-form-group>
                    <br />

                    <b-form-group id="entrada2"
                                  label="Quantos?"
                                  label-for="quantidade"
                                  description="Se vazio, entenderemos que é somente um.">
                        <b-form-input id="quantidade"
                                      v-model="quantidade"
                                      type="number"
                        ></b-form-input>
                    </b-form-group>
                    <br />

                    <b-form-group id="entrada3"
                                  label="Acrescimos?"
                                  label-for="acrescimos">
                        <b-form-checkbox-group id="acrescimos"
                                               v-model="acrescimos">
                            <div v-for="acrescimo in acrescimosLista"
                                 :key="acrescimo.id">
                                <b-form-checkbox :value="acrescimo">
                                    {{acrescimo.nome}} R${{acrescimo.valor}}
                                </b-form-checkbox>
                            </div>
                        </b-form-checkbox-group>
                    </b-form-group>

                    <template #modal-footer>
                        <div class="w-100">
                            <b-button class="button"
                                      block
                                      @click="Adicionar">Adicionar ao carrinho</b-button>
                        </div>
                    </template>
                </b-modal>
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
                    post: {},
                    modal: {},
                    acrescimosLista: {},
                    observacao: '',
                    quantidade: 1,
                    acrescimos: [],
                    show: false,
                }
            },
            created() {
                this.fetchData();

            },
            watch: {
                '$route': 'fetchData'
            },
            mounted() {
                if (localStorage.observacao) {
                    this.observacao = localStorage.observacao;
                }

                if (localStorage.quantidade) {
                    this.quantidade = localStorage.quantidade;
                }

                if (localStorage.getItem('acrescimos')) {
                    this.acrescimos = JSON.parse(localStorage.getItem('acrescimos'));
                }
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

                    fetch('Acrescimos/Listar')
                        .then(a => a.json())
                        .then(json => {
                            this.acrescimosLista = json;
                            return;
                        })
                        .catch((error) => {
                            console.log(error);
                        });
                },
                Adicionar() {
                    localStorage.setItem('lanche', JSON.stringify(this.modal));
                    localStorage.observacao = this.observacao;
                    localStorage.quantidade = this.quantidade;
                    localStorage.setItem('acrescimos', JSON.stringify(this.acrescimos));
                    this.show = false;
                    this.observacao = '';
                    this.quantidade = 1;
                    this.acrescimos = [];
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