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
    }
}