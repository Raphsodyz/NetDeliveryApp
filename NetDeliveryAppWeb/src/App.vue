<template>
    <div id="app">
        <div id="wrapper" class="fade-in">
            <div id="intro">
                <h1>
                    Olá, bem vindo ao<br />
                    NetDeliveryApp
                </h1>
                <p>Seu sistema para venda e anuncios de hamburguers.</p>
                <ul class="actions">
                    <li>
                        <a href="#header"
                           class="button icon solid solo fa-arrow-down scrolly">Vamos lá!</a>
                    </li>
                </ul>
            </div>
            <header id="header">
                <a href="index.html" class="logo">NetDeliveryApp</a>
            </header>
            <nav id="nav">
                <ul class="links">
                    <li class="active">
                        <router-link to="/">Início</router-link>
                    </li>
                    <li>
                        <router-link to="/Carrinho">Carrinho</router-link>
                    </li>
                    <li>
                        <router-link to="/Cadastro">Cadastro</router-link>
                    </li>
                </ul>
            </nav>
            <div id="main">
                <router-view />
            </div>
            <footer id="footer">
                <ul class="icons">
                    <li><a href="https://twitter.com/" target="_blank" class="icon brands fa-twitter"><span class="label">Twitter</span></a></li>
                    <li><a href="https://www.facebook.com/" target="_blank" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a></li>
                    <li><a href="https://github.com/Raphsodyz" target="_blank" class="icon brands fa-github"><span class="label">GitHub</span></a></li>
                    <li><a href="https://www.linkedin.com/in/arthur-vin%C3%ADcius-souza-ribeiro-7bbb07107/" target="_blank" class="icon brands fa-linkedin-in"><span class="label">LinkedIn</span></a></li>
                    <li><a href="" class="icon solid fa-toolbox"><span class="label">Administrador</span></a></li>
                </ul>
            </footer>
            <div id="copyright">
                <ul>
                    <li>&copy; NetDeliveryApp</li>
                    <li>Design: <a href="https://html5up.net">HTML5 UP</a></li>
                </ul>
            </div>
        </div>
    </div>
</template>

<style>
    @import "../public/css/Styles.css";
    @import "../public/css/noscript.css";
    @import url(../public/css/fontawesome-all.min.css);
    @import url("https://fonts.googleapis.com/css?family=Merriweather:300,700,300italic,700italic|Source+Sans+Pro:900");
</style>

<script>
    import Index from "./views/Index.vue";

export default {
  name: "App",
  components: {
    Index,
  },
};
</script>
