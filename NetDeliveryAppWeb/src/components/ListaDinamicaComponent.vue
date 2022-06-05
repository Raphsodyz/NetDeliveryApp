<template>
    <div>
        <div v-show="semCategoria" class="row" v-for="categoria in categorias" :key="categoria.id">
            <h1>{{categoria.nome}}</h1>
            <!-- eslint-disable vue/no-use-v-if-with-v-for,vue/no-confusing-v-for-v-if -->
            <div class="col-4 col-12-medium" v-for="produto in produtos" :key="produto.id" v-if="produto.categoria.id === categoria.id">
                <!-- eslint-enable -->
                <section class="box feature">
                    <div v-if="produto.categoria.id === 1">
                        <a v-b-modal.modal-1 @click="capturarProduto(produto.id)" class="image featured"><b-img-lazy :src="produto.foto" :alt="modal.nome" /></a>
                    </div>
                    <div v-else>
                        <a v-b-modal.modal-2 @click="capturarProduto(produto.id)" class="image featured"><b-img-lazy :src="produto.foto" :alt="modal.nome" /></a>
                    </div>
                    <div class="inner">
                        <header>
                            <h2 class="titulo">{{produto.nome}}</h2>
                            <p class="card-text">{{produto.ingredientes}}</p>
                            <br />
                            <h2 class="produto-valor">R${{produto.valor}}</h2>
                        </header>
                    </div>
                </section>
            </div>
            <br />
        </div>
    </div>
</template>

<script>
    export default {
        name: 'listadinamica',
        props: {
            categorias: Array,
            produtos: Array,
            acrescimos: Array,
            semCategoria: Boolean
        },
        data: function () {
            return {
                modal: {},
            }
        },
        methods: {
            capturarProduto(id) {
                this.modal = this.produtos.find(p => p.id === id);
                this.$emit('selecionado', this.modal);
            },
        }
    }
</script>