<template>
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
                    <div v-for="acrescimo in acrescimosData"
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
    </div>
</template>

<script>
    export default {
        name: 'modalsanduiche',
        props: {
            modal: Object,
            acrescimosData: Array,
        },
        data: function () {
            return {
                modal1: false,
                modal2: false,
                observacao: '',
                quantidade: 1,
                acrescimos: [],
                Itens: []
            }
        },
        methods: {
            botaoX() {
                this.modal1 = false;
                this.modal2 = false;
                this.observacao = '';
                this.quantidade = 1;
                this.acrescimos = [];

                this.$emit('modalLimpo', this.modal1, this.modal2, this.observacao, this.quantidade, this.acrescimos)
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

                this.$emit('popularCarrinho', this.Itens, this.temItens = true, this.modal1, this.modal2, this.observacao, this.quantidade, this.acrescimos);
            }
        }
    }
</script>