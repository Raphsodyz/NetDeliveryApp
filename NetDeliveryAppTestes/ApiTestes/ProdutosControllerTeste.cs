using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
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
            List<ProdutoDTO> produtos = new List<ProdutoDTO>();

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(produtos);

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
        public async Task Editar_UsuarioNaoAutorizado_RetornarUnauthorized() 
        {
            //Arrange

            //Act

            //Assert
        }
    }
}