using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentAssertions;
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
            List<ProdutoDTO> ListaProdutos = new List<ProdutoDTO>();
            ProdutoDTO produto = new ProdutoDTO();

            ListaProdutos.Add(produto);

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .Throws<Exception>();

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task Adicionar_NovoProduto_RetornarCreated()
        {
            //Arrange
            var novoProduto = new ProdutoDTO()
            {
                Id = 7,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 10,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IProdutoAplicacao>();
            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoProduto);

            //Assert
            Assert.IsType<CreatedResult>(resultado);

            novoProduto.Id.Should().NotBe(null, "Não pode ser vazio o ID.");
            novoProduto.Valor.Should().NotBe(null, "Não pode ser vazio o Valor.");
            novoProduto.Nome.Should().NotBeNull();
            novoProduto.Id.Should().Be(7);
            novoProduto.Valor.Should().Be(10);
            novoProduto.Categoria.Should().BeOfType<CategoriaDTO>();
        }

        [Fact]
        public async Task Adicionar_ProdutoIncompleto_RetornarBadrequest()
        {
            //Arrange
            ProdutoDTO novoProduto = null;

            var repositoryTest = new Mock<IProdutoAplicacao>();
            var pController = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await pController.Adicionar(novoProduto);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Adicionar_DataAnnotationProdutoTeste_ProdutoCorreto()
        {
            //Assert
            var novoProduto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 15,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            //Act
            var erros = ValidarObjeto(novoProduto);

            //Assert
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Adicionar_DataAnnotationTeste_ProdutoComErros()
        {
            //Assert
            var novoProduto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "",
                Ingredientes = "",
                Valor = -15,
                Sabor = "",
                Volume = "",
                Foto = "",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            //Act
            var erros = ValidarObjeto(novoProduto);

            //Assert
            Assert.True(erros.Count == 6);
        }

        [Fact]
        public async Task Editar_ProdutoExistente_RetornarOk() 
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 15,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<ProdutoDTO>())).Returns(Task.FromResult(produto));

            var produtoEditado = new ProdutoDTO()
            {
                Id = produto.Id + 3,
                Nome = "Sorvete de " + produto.Nome,
                Valor = 20
            };

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(produtoEditado);

            //Assert
            resultado.Should().BeOfType<OkResult>();

            produtoEditado.Id.Should().Be(3);
            produtoEditado.Nome.Should().Be("Sorvete de Açaí");
            produtoEditado.Valor.Should().Be(20);
        }

        [Fact]
        public async Task Editar_ProdutoExistente_RetornarErro()
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 15,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Editar(produto)).Throws<Exception>();

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(produto);

            //Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Deletar_ProdutoExistente_RetornarOk()
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 15,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Returns(Task.FromResult(produto));

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Deletar_ProdutoInexistente_RetornarNotFound()
        {
            //Arrange
            ProdutoDTO produto = new ProdutoDTO()
            {
                Id = 0,
                Nome = "Açaí",
                Ingredientes = "Creme de açaí, adicionais a gosto.",
                Valor = 15,
                Sabor = "açaí",
                Volume = "500ml",
                Foto = "https://www.acai.com.br/acai.jpg",
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IProdutoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Throws<Exception>();

            var controller = new ProdutosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<NotFoundObjectResult>();
        }

        private static IList<ValidationResult> ValidarObjeto(ProdutoDTO produto)
        {
            var validar = new List<ValidationResult>();
            var contexto = new ValidationContext(produto, null, null);
            Validator.TryValidateObject(produto, contexto, validar, true);
            return validar;
        }
    }
}