<template>
    <div style="float: right;">
        <b-dropdown id="dropdown-1" variant="button" text="Ordenar por..">
            <div v-for="categoria in categorias" :key="categoria.id">
                <b-dropdown-item @click="capturarCategoria(categoria.id)">{{categoria.nome}}</b-dropdown-item>
            </div>
            <b-dropdown-divider></b-dropdown-divider>
            <b-dropdown-item @click="todos()">Exibir todos</b-dropdown-item>
        </b-dropdown>
    </div>
</template>

<script>
    export default {
        name: 'ordenar',
        props: {
            categorias: Object,
            produtos: Object,
        },
        data: function () {
            return {
                semCategoria: true,
                produtoFiltrado: [],
            }
        },
        methods: {
            capturarCategoria(id) {
                this.produtoFiltrado =
                    this.produtos.filter((posts) => {
                        return posts.categoria.id === id
                    });
                this.semCategoria = false;
                this.$emit('dados', this.produtoFiltrado, this.semCategoria);
            },
            todos() {
                this.semCategoria = true;
                this.$emit('menu', this.semCategoria);
            }
        }
    }
</script>