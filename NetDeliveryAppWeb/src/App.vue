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
                           class="button icon solid solo fa-arrow-down scrolly">Vamos l�!</a>
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
                <ul class="icons">
                    <li>
                        <a href="#" class="icon brands fa-twitter"><span class="label">Twitter</span></a>
                    </li>
                    <li>
                        <a href="#" class="icon brands fa-facebook-f"><span class="label">Facebook</span></a>
                    </li>
                    <li>
                        <a href="#" class="icon brands fa-instagram"><span class="label">Instagram</span></a>
                    </li>
                    <li>
                        <a href="#" class="icon brands fa-github"><span class="label">GitHub</span></a>
                    </li>
                </ul>
            </nav>
            <div id="main">
                <router-view />
            </div>
            <footer id="footer">
                <section>
                    <form method="post" action="#">
                        <div class="fields">
                            <div class="field">
                                <label for="name">Name</label>
                                <input type="text" name="name" id="name" />
                            </div>
                            <div class="field">
                                <label for="email">Email</label>
                                <input type="text" name="email" id="email" />
                            </div>
                            <div class="field">
                                <label for="message">Message</label>
                                <textarea name="message" id="message" rows="3"></textarea>
                            </div>
                        </div>
                        <ul class="actions">
                            <li><input type="submit" value="Send Message" /></li>
                        </ul>
                    </form>
                </section>
                <section class="split contact">
                    <section class="alt">
                        <h3>Address</h3>
                        <p>
                            1234 Somewhere Road #87257<br />
                            Nashville, TN 00000-0000
                        </p>
                    </section>
                    <section>
                        <h3>Phone</h3>
                        <p><a href="#">(000) 000-0000</a></p>
                    </section>
                    <section>
                        <h3>Email</h3>
                        <p><a href="#">info@untitled.tld</a></p>
                    </section>
                    <section>
                        <h3>Social</h3>
                        <ul class="icons alt">
                            <li>
                                <a href="#" class="icon brands alt fa-twitter"><span class="label">Twitter</span></a>
                            </li>
                            <li>
                                <a href="#" class="icon brands alt fa-facebook-f"><span class="label">Facebook</span></a>
                            </li>
                            <li>
                                <a href="#" class="icon brands alt fa-instagram"><span class="label">Instagram</span></a>
                            </li>
                            <li>
                                <a href="#" class="icon brands alt fa-github"><span class="label">GitHub</span></a>
                            </li>
                        </ul>
                    </section>
                </section>
            </footer>

            <!-- Copyright -->
            <div id="copyright">
                <ul>
                    <li>&copy; Untitled</li>
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
    @import url("https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css");
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
