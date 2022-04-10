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
                        <th scope="col">CPF</th>
                        <th scope="col">Telefone</th>
                        <th scope="col">Data de Criação</th>
                        <th scope="col">Foto</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="Clientes in post" :key="Clientes.id">
                        <th scope="row">{{ Clientes.id }}</th>
                        <td>{{ Clientes.nome }}</td>
                        <td>{{ Clientes.cpf }}</td>
                        <td>{{ Clientes.telefone }}</td>
                        <td>{{ Clientes.dataCriacao }}</td>
                        <td>{{ Clientes.foto }}</td>
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

                fetch('Clientes/Listar')
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