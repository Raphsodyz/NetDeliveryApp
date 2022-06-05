<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <h5>Um momento, as informações estão sendo carregadas...</h5>
        </div>
        <div v-if="post" class="content">
            <ordenar :categorias="categorias" :produtos="post" @dados="retorno" @menu="itens"/>
            <div id="features-wrapper">
                <b-container fluid>
                    <listadinamica :produtos="post" 
                                   :categorias="categorias" 
                                   :acrescimos="acrescimosLista" 
                                   :semCategoria="semCategoria"
                                   @selecionado="escolher_produto"
                    />
                    <listaordenada :produtos="produtoFiltrado"
                                   :categorias="categorias" 
                                   :acrescimos="acrescimosLista" 
                                   :semCategoria="semCategoria"
                                   @selecionado="escolher_produto"
                    />
                    <botaocarrinho :temItens="temItens"/>
                </b-container>

                <modalsanduiche :modal="modal"
                                :acrescimosData="acrescimosLista"
                                @modalLimpo="limpar"
                                @popularCarrinho="popular_carrinho"
                />
                <modalbebida :modal="modal"
                             :acrescimosData="acrescimosLista"
                             @modalLimpo="limpar"
                             @popularCarrinho="popular_carrinho"
                />
            </div>
        </div>
    </div>
</template>

<script lang="js">

    import Vue from 'vue';
    import ordenar from '../components/OrdenarComponent.vue';
    import listadinamica from '../components/ListaDinamicaComponent.vue';
    import listaordenada from '../components/ListaOrdenadaComponent.vue';
    import botaocarrinho from '../components/BotãoCarrinho.vue';
    import modalsanduiche from '../components/SanduicheModalComponent.vue';
    import modalbebida from '../components/BebidaModalComponent.vue';

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
                    produtoFiltrado: [],
                }
            },
            components: {
                ordenar,
                listadinamica,
                listaordenada,
                botaocarrinho,
                modalsanduiche,
                modalbebida
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
                retorno: function (produto, categoria) {
                    this.produtoFiltrado = produto;
                    this.semCategoria = categoria;
                },
                itens: function (todos) {
                    this.semCategoria = todos;
                },
                escolher_produto: function (selecionado) {
                    this.modal = selecionado;
                },
                limpar: function (m1, m2, o, q, a) {
                    this.modal1 = m1;
                    this.modal2 = m2;
                    this.observacao = o;
                    this.quantidade = q;
                    this.acrescimos = a;
                },
                popular_carrinho: function (i, ti, m1, m2, o, q, a) {
                    this.Itens = i;
                    this.temItens = ti;
                    this.modal1 = m1;
                    this.modal2 = m2;
                    this.observacao = o;
                    this.quantidade = q;
                    this.acrescimos = a;
                }
            }
        });
</script>