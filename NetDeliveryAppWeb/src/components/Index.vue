<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Um momento, o site esta sendo carregado...
        </div>

        <div v-if="post" class="content">
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">ID</th>
                        <th scope="col">Nome</th>
                        <th scope="col">Valor</th>
                        <th scope="col">Categoria</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="Acrescimos in post" :key="Acrescimos.id">
                        <th scope="row">{{ Acrescimos.id }}</th>
                        <td>{{ Acrescimos.nome }}</td>
                        <td>{{ Acrescimos.valor }}</td>
                        <td>{{ Acrescimos.categoria.nome }}</td>
                    </tr>
                </tbody>
            </table>
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
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
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