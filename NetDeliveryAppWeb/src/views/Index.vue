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
                         :title="modal.nome">
                    <b-img-lazy :src="modal.foto" fluid-grow :alt="modal.nome" />
                    <p class="my-4" style="text-align: center;
                                        font-family: 'PT Sans', sans-serif;
                                        font-size: medium;">
                        {{modal.ingredientes}}
                    </p>

                    <b-form @submit="carrinho" v-if="show">
                        <b-form-group id="entrada1"
                                      label="Lanche"
                                      label-for="lanche">
                            <b-form-input id="lanche"
                                          v-model="carrinho.lanche"
                                          type="hidden"
                                          placeholder="Nome do lanche">
                                {{modal.nome}}
                            </b-form-input>
                        </b-form-group>

                        <b-form-group id="entrada2"
                                      label="Valor do lanche"
                                      label-for="valorLanche">
                            <b-form-input id="valorLanche"
                                          v-model="carrinho.valorLanche"
                                          type="hidden"
                                          placeholder="Valor do lanche">
                                {{modal.valor}}
                            </b-form-input>
                        </b-form-group>

                        <b-form-group id="entrada3"
                                      label="Alguma observação sobre o lanche?"
                                      label-for="observacao">
                            <b-form-input id="observacao"
                                          v-model="carrinho.observacao"
                                          type="textarea"
                                          placeholder="Digite aqui!"></b-form-input>
                        </b-form-group>

                        <b-form-group id="entrada4"
                                      label="Quantidade?"
                                      label-for="quantidade"
                                      description="Se vazio, entenderemos que é somente um.">
                            <b-form-input id="quantidade"
                                          v-model="carrinho.quantidade"
                                          type="number"></b-form-input>
                        </b-form-group>

                        <b-form-group id="entrada5"
                                      v-slot="{ ariaDescribedby }">
                            <b-form-checkbox-group id="acrescimos"
                                                   v-model="carrinho.acrescimosValor"
                                                   :aria-describedby="ariaDescribedby"
                                                   v-for="acrescimo in acrescimosLista"
                                                   :key="acrescimo.id">
                                <b-form-checkbox :value="acrescimo.valor">
                                    {{acrescimo.nome}} R${{acrescimo.valor}}
                                </b-form-checkbox>
                            </b-form-checkbox-group>
                        </b-form-group>

                        <template #modal-footer>
                            <div class="w-100">
                                <b-button block
                                          variant="dark"
                                          type="submit">Adicionar ao carrinho</b-button>
                            </div>
                        </template>
                    </b-form>
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
                    post: null,
                    modal: {},
                    acrescimosLista: null,
                    carrinho: {
                        lanche: '',
                        valorLanche: '',
                        observacao: '',
                        quantidade: '',
                        acrescimosValor: [],
                        total: parseInt(this.quantidade) * (parseFloat(this.valorLanche) + (this.acrescimosValor.reduce((anterior, atual) => anterior + atual, 0)))
                    },
                    show: true,
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
                },
                getAcrescimos() {
                    axios.get('https://localhost:5001/api/Acrescimos/Listar')
                        .then((resposta) => {
                            this.acrescimosLista = resposta.data
                        })
                        .catch((error) => {
                            console.log(error);
                        })
                },
                submit(event) {
                    event.preventDefault();
                    alert(JSON.stringify(this.carrinho));
                    console.log(this.carrinho);
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