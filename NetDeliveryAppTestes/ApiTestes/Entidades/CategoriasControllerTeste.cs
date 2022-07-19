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

namespace NetDeliveryAppTestes.ApiTestes
{
    public class CategoriasControllerTeste
    {
        [Fact]
        public async Task Encontrar_CategoriaInexistente_RetornarNotFound()
        {
            //Arrange
            ICategoriaAplicacao categoria = null;
            var controller = new CategoriasController(categoria);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task Encontrar_CategoriaEncontrada_RetornarOk()
        {
            //Arrange
            CategoriaDTO categoria = new CategoriaDTO();

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Encontrar(It.IsAny<int>()))
                .ReturnsAsync(categoria);

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task Listar_CategoriasDoBanco_RetornarOk()
        {
            //Arrange
            List<CategoriaDTO> listarCategorias = new List<CategoriaDTO>();
            CategoriaDTO categoria = new CategoriaDTO();

            listarCategorias.Add(categoria);

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(listarCategorias);

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]

        public async Task Listar_BancoIndisponivel_RetornarBadRequest()
        {
            //Arrange
            List<CategoriaDTO> listarCategoria = new List<CategoriaDTO>();
            CategoriaDTO categoria = new CategoriaDTO();

            listarCategoria.Add(categoria);

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .Throws<Exception>();

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task Adicionar_NovaCategoria_RetornarCreated()
        {
            //Arrange
            var novaCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete"
            };

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novaCategoria);

            //Assert
            Assert.IsType<CreatedResult>(resultado);

            novaCategoria.Id.Should().NotBe(null, "Não pode ser vazio o ID.");
            novaCategoria.Nome.Should().NotBeNull();
            novaCategoria.Id.Should().Be(0);
        }

        [Fact]
        public async Task Adicionar_CategoriaIncompleta_RetornarBadrequest()
        {
            //Arrange
            CategoriaDTO novoCategoria = null;

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoCategoria);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Adicionar_DataAnnotationCategoriaTeste_CategoriaCorreta()
        {
            //Assert
            var novoCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete"
            };

            //Act
            var erros = ValidarObjeto(novoCategoria);

            //Assert
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Adicionar_DataAnnotationCategoriaTeste_CategoriaComErros()
        {
            //Assert
            var novoCategoria = new CategoriaDTO()
            {
                Id = -5,
                Nome = null,
            };

            //Act
            var erros = ValidarObjeto(novoCategoria);

            //Assert
            Assert.True(erros.Count == 2);
        }

        [Fact]
        public async Task Editar_CategoriaExistente_RetornarOk()
        {
            //Arrange
            var novaCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete"
            };

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<CategoriaDTO>())).Returns(Task.FromResult(novaCategoria));

            var categoriaEditada = new CategoriaDTO()
            {
                Id = novaCategoria.Id + 3,
                Nome = novaCategoria.Nome + " especial",
            };

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(categoriaEditada);

            //Assert
            resultado.Should().BeOfType<OkResult>();

            categoriaEditada.Id.Should().Be(3);
            categoriaEditada.Nome.Should().Be("Sorvete especial");
        }

        [Fact]
        public async Task Editar_CategoriaExistente_RetornarErro()
        {
            //Arrange
            var novaCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete",
            };

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Editar(novaCategoria)).Throws<Exception>();

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(novaCategoria);

            //Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Deletar_CategoriaExistente_RetornarOk()
        {
            //Arrange
            var novaCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete",
            };

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Returns(Task.FromResult(novaCategoria));

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Deletar_CategoriaInexistente_RetornarNotFound()
        {
            //Arrange
            var novaCategoria = new CategoriaDTO()
            {
                Id = 0,
                Nome = "Sorvete"
            };

            var repositoryTest = new Mock<ICategoriaAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Throws<Exception>();

            var controller = new CategoriasController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<NotFoundObjectResult>();
        }

        private static IList<ValidationResult> ValidarObjeto(CategoriaDTO categoriaDTO)
        {
            var validar = new List<ValidationResult>();
            var contexto = new ValidationContext(categoriaDTO, null, null);
            Validator.TryValidateObject(categoriaDTO, contexto, validar, true);
            return validar;
        }
        
    }

}