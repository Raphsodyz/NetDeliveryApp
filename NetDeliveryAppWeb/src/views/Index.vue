<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <h5>Um momento, as informações estão sendo carregadas...</h5>
        </div>
        <div v-if="post" class="content">
            <div style="float: right;">
                <b-dropdown id="dropdown-1" variant="button" text="Ordenar por..">
                    <div v-for="categoria in categorias" :key="categoria.id">
                        <b-dropdown-item @click="capturarCategoria(categoria.id)">{{categoria.nome}}</b-dropdown-item>
                    </div>
                    <b-dropdown-divider></b-dropdown-divider>
                    <b-dropdown-item @click="semCategoria = !semCategoria">Exibir todos</b-dropdown-item>
                </b-dropdown>
            </div>
            <div id="features-wrapper">
                <b-container fluid>
                    <div v-show="semCategoria" class="row" v-for="categoria in categorias" :key="categoria.id">
                        <h1>{{categoria.nome}}</h1>
                        <!-- eslint-disable vue/no-use-v-if-with-v-for,vue/no-confusing-v-for-v-if -->
                        <div class="col-4 col-12-medium" v-for="produtos in post" :key="produtos.id" v-if="produtos.categoria.id === categoria.id">
                            <!-- eslint-enable -->
                            <section class="box feature">
                                <div v-if="produtos.categoria.id === 1">
                                    <a v-b-modal.modal-1 @click="capturarProduto(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                </div>
                                <div v-else>
                                    <a v-b-modal.modal-2 @click="capturarProduto(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                </div>                                
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
                        <br />
                    </div>
                    <div v-show="!semCategoria" class="row">
                        <div class="col-4 col-12-medium" v-for="produtos in produtoFiltrado" :key="produtos.id">
                            <section class="box feature">
                                <div v-if="produtoFiltrado[0].categoriaId === 1">
                                    <a v-b-modal.modal-1 @click="capturarProduto(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                </div>
                                <div v-else>
                                    <a v-b-modal.modal-2 @click="capturarProduto(produtos.id)" class="image featured"><b-img-lazy :src="produtos.foto" :alt="modal.nome" /></a>
                                </div>
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
                    <div v-if="temItens">
                        <b-button block to="/Carrinho" class="button" id="carrinhoBtn">Carrinho <font-awesome-icon icon="fa-solid fa-burger" /></b-button>
                    </div>
                </b-container>
                <div>
                    <b-modal centered
                             id="modal-1"
                             body-class="b-row"
                             no-close-on-backdrop
                             no-close-on-esc
                             v-model="modal1">
                        <template #modal-header>
                            <h2>{{modal.nome}}</h2>
                            <b-button size="sm" class="button" @click="botaoX()">X</b-button>
                        </template>
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
                                             max-rows="6"></b-form-textarea>
                        </b-form-group>
                        <br />
                        <b-form-group id="entrada2"
                                      label="Quantos?"
                                      label-for="quantidade"
                                      description="Se vazio, entenderemos que é somente um.">
                            <b-form-input id="quantidade"
                                          v-model="quantidade"
                                          type="number"
                                          min="1"
                                          oninput="validity.valid||(value='');"></b-form-input>
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
                                          style="float:right;"
                                          @click="Adicionar">
                                    Adicionar ao carrinho
                                </b-button>
                            </div>
                        </template>
                    </b-modal>

                    <b-modal centered
                             id="modal-2"
                             body-class="b-row"
                             no-close-on-backdrop
                             no-close-on-esc
                             v-model="modal2">
                        <template #modal-header>
                            <h2>{{modal.nome}}</h2>
                            <b-button size="sm" class="button" @click="botaoX()">X</b-button>
                        </template>
                        <b-img-lazy :src="modal.foto" fluid-grow :alt="modal.nome" />
                        <p class="my-4" style="text-align: center;
                                        font-family: 'PT Sans', sans-serif;
                                        font-size: medium;">
                            {{modal.volume}}
                        </p>

                        <b-form-group id="entrada1"
                                      label="Alguma observação sobre o pedido?"
                                      label-for="observacao">
                            <b-form-textarea id="observacao"
                                             v-model="observacao"
                                             placeholder="Digite aqui!"
                                             rows="3"
                                             max-rows="6"></b-form-textarea>
                        </b-form-group>
                        <br />
                        <b-form-group id="entrada2"
                                      label="Quantos?"
                                      label-for="quantidade"
                                      description="Se vazio, entenderemos que é somente um.">
                            <b-form-input id="quantidade"
                                          v-model="quantidade"
                                          type="number"
                                          min="1"
                                          oninput="validity.valid||(value='');"></b-form-input>
                        </b-form-group>

                        <template #modal-footer>
                            <div class="w-100">
                                <b-button class="button"
                                          block
                                          @click="Adicionar"
                                          style="float:right;">
                                    Adicionar ao carrinho
                                </b-button>
                            </div>
                        </template>
                    </b-modal>
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
                    post: {},
                    categorias: {},
                    modal: {},
                    acrescimosLista: {},
                    Itens: [],
                    observacao: '',
                    quantidade: 1,
                    acrescimos: [],
                    modal1: false,
                    modal2: false,
                    temItens: false,
                    semCategoria: true,
                    produtoFiltrado: {},
                }
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
                    case localStorage.getItem('carrinho').length > 2:
                        this.temItens = true;
                        break;
                    case localStorage.getItem("carrinho").length === 2:
                        this.carrinho = localStorage.getItem("carrinho");
                        break;
                    default:
                        console.log("Erro ao localizar o carrinho.");
                        break;
                }

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
                        })
                        .catch((error) => {
                            console.log(error)
                        });

                    fetch('Categorias/Listar')
                        .then(c => c.json())
                        .then(json => {
                            this.categorias = json;
                            return;
                        })
                        .catch((error) => {
                            console.log(error)
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
                capturarProduto(id) {
                    this.modal = this.post.find(p => p.id === id);
                },
                Adicionar() {

                    if (localStorage.getItem("carrinho").length === 2) {
                        const carrinho = JSON.parse(localStorage.getItem("carrinho"));
                        carrinho.push({ produto: this.modal, observacao: this.observacao, quantidade: this.quantidade, acrescimos: this.acrescimos });
                        localStorage.setItem("carrinho", btoa(JSON.stringify(carrinho)));
                        this.Itens = JSON.parse(atob(localStorage.getItem("carrinho")));
                    }
                    else {
                        const carrinho = JSON.parse(atob(localStorage.getItem("carrinho")));
                        carrinho.push({ produto: this.modal, observacao: this.observacao, quantidade: this.quantidade, acrescimos: this.acrescimos });
                        localStorage.setItem("carrinho", btoa(JSON.stringify(carrinho)));
                        this.Itens = JSON.parse(atob(localStorage.getItem("carrinho")));
                    }
                    this.modal1 = false;
                    this.modal2 = false;
                    this.temItens = true;
                    this.observacao = '';
                    this.quantidade = 1;
                    this.acrescimos = [];
                },

                botaoX() {
                    this.modal1 = false;
                    this.modal2 = false;
                    this.observacao = '';
                    this.quantidade = 1;
                    this.acrescimos = [];
                },
                capturarCategoria(id) {
                    this.produtoFiltrado =
                        this.post.filter(function (posts) {
                            return posts.categoria.id === id
                        });
                    this.semCategoria = false;
                }
            }
        });
</script>