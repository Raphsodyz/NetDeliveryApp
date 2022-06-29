using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppAplicacao.Interfaces.Identity;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppServicos.Controllers;
using Xunit;

namespace ProdutosControllerTest.ApiTestes
{
    public class ProdutosControllerTeste
    {
        [Fact]
        public async Task Encontrar_ProdutoInexistente_RetornarNotFound()
        {
            //Arrange
            IProdutoAplicacao produto = null;
            var controller = new ProdutosController(produto);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task Encontrar_ProdutoEncontrado_RetornarOk()
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO();

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Encontrar(It.IsAny<int>()))
                .ReturnsAsync(produto);

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }
        
        [Fact]
        public async Task Listar_ProdutosDoBanco_RetornarOk()
        {
            //Arrange
            List<ProdutoDTO> ListaProdutos = new List<ProdutoDTO>();
            ProdutoDTO produto = new ProdutoDTO();

            ListaProdutos.Add(produto);

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(ListaProdutos);

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]

        public async Task Listar_BancoIndisponivel_RetornarBadRequest()
        {
            //Arrange
            List<IProdutoAplicacao> produtos = new List<IProdutoAplicacao>();
            for(int i = 0; i < produtos.Count; i++)
            {
                var controller = new ProdutosController(produtos[i]);

                //Act
                var resultado = await controller.Listar();

                //Assert
                Assert.IsType<BadRequestObjectResult>(resultado);
            }
        }

        [Fact]
        public async Task Adicionar_NovoProduto_RetornarCreated()
        {
            //Arrange
            var admin = new LoginDTO()
            {
                Email = "",
                PasswordHash = ""
            };

            var novoProduto = new ProdutoDTO()
            {
                Id = 7,
                Nome = "Qualquer coisa",
                Valor = 10
            };

            var loginTest = new Mock<IUsuariosAplicacao>();
            var lController = new UsuariosController(loginTest.Object);

            var repositoryTest = new Mock<IProdutoAplicacao>();
            var pController = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await pController.Adicionar(novoProduto);

            //Assert
            var itemCriado = (resultado as CreatedAtActionResult).Value as ProdutoDTO;
            novoProduto.Should().BeEquivalentTo(itemCriado,
                options => options.ComparingByMembers<ProdutoDTO>()
                    .ExcludingMissingMembers()
            );
            itemCriado.Id.Should().Be(7);
            itemCriado.Valor.Should().Be(10);
        }

        [Fact]
        public async Task Editar_UsuarioNaoAutorizado_RetornarUnauthorized() 
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO();

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<ProdutoDTO>())).Returns((ProdutoDTO p) => { return p; });

            var controller = new ProdutosController(repositoryTest.Object);

            //Act

            //Assert
        }
    }
}