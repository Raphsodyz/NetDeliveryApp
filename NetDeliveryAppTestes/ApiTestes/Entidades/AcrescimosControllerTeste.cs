using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
    public class AcrescimosControllerTeste
    {
        [Fact]
        public async Task Encontrar_AcrescimoInexistente_RetornarNotFound()
        {
            //Arrange
            IAcrescimoAplicacao acrescimo = null;
            var controller = new AcrescimosController(acrescimo);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task Encontrar_AcrescimoEncontrado_RetornarOk()
        {
            //Arrange
            AcrescimoDTO acrescimo = new AcrescimoDTO();

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Encontrar(It.IsAny<int>()))
                .ReturnsAsync(acrescimo);

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task Listar_AcrescimosDoBanco_RetornarOk()
        {
            //Arrange
            List<AcrescimoDTO> ListaAcrescimos = new List<AcrescimoDTO>();
            AcrescimoDTO acrescimo = new AcrescimoDTO();

            ListaAcrescimos.Add(acrescimo);

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(ListaAcrescimos);

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]

        public async Task Listar_BancoIndisponivel_RetornarBadRequest()
        {
            //Arrange
            List<AcrescimoDTO> listaAcrescimo = new List<AcrescimoDTO>();
            AcrescimoDTO acrescimo = new AcrescimoDTO();

            listaAcrescimo.Add(acrescimo);

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .Throws<Exception>();

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task Adicionar_NovoAcrescimo_RetornarCreated()
        {
            //Arrange
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoAcrescimo);

            //Assert
            Assert.IsType<CreatedResult>(resultado);

            novoAcrescimo.Id.Should().NotBe(null, "Não pode ser vazio o ID.");
            novoAcrescimo.Valor.Should().NotBe(null, "Não pode ser vazio o Valor.");
            novoAcrescimo.Nome.Should().NotBeNull();
            novoAcrescimo.Id.Should().Be(0);
            novoAcrescimo.Valor.Should().Be(2);
            novoAcrescimo.Categoria.Should().BeOfType<CategoriaDTO>();
        }

        [Fact]
        public async Task Adicionar_AcrescimoIncompleto_RetornarBadrequest()
        {
            //Arrange
            AcrescimoDTO novoAcrescimo = null;

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoAcrescimo);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Adicionar_DataAnnotationAcrescimoTeste_AcrescimoCorreto()
        {
            //Assert
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            //Act
            var erros = ValidarObjeto(novoAcrescimo);

            //Assert
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Adicionar_DataAnnotationTeste_AcrescimoComErros()
        {
            //Assert
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = -5,
                Nome = null,
                Valor = -24,
                CategoriaId = 0,
                Categoria = null
            };

            //Act
            var erros = ValidarObjeto(novoAcrescimo);

            //Assert
            Assert.True(erros.Count == 4);
        }

        [Fact]
        public async Task Editar_AcrescimoExistente_RetornarOk()
        {
            //Arrange
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<AcrescimoDTO>())).Returns(Task.FromResult(novoAcrescimo));

            var acrescimoEditado = new AcrescimoDTO()
            {
                Id = novoAcrescimo.Id + 3,
                Nome = novoAcrescimo.Nome + " minas",
                Valor = 20
            };

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(acrescimoEditado);

            //Assert
            resultado.Should().BeOfType<OkResult>();

            acrescimoEditado.Id.Should().Be(3);
            acrescimoEditado.Nome.Should().Be("Queijo minas");
            acrescimoEditado.Valor.Should().Be(20);
        }

        [Fact]
        public async Task Editar_AcrescimoExistente_RetornarErro()
        {
            //Arrange
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Editar(novoAcrescimo)).Throws<Exception>();

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(novoAcrescimo);

            //Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Deletar_AcrescimoExistente_RetornarOk()
        {
            //Arrange
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Returns(Task.FromResult(novoAcrescimo));

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Deletar_AcrescimoInexistente_RetornarNotFound()
        {
            //Arrange
            var novoAcrescimo = new AcrescimoDTO()
            {
                Id = 0,
                Nome = "Queijo",
                Valor = 2,
                CategoriaId = 0,
                Categoria = new CategoriaDTO()
            };

            var repositoryTest = new Mock<IAcrescimoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Throws<Exception>();

            var controller = new AcrescimosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<NotFoundObjectResult>();
        }

        private static IList<ValidationResult> ValidarObjeto(AcrescimoDTO acrescimo)
        {
            var validar = new List<ValidationResult>();
            var contexto = new ValidationContext(acrescimo, null, null);
            Validator.TryValidateObject(acrescimo, contexto, validar, true);
            return validar;
        }
    }
}
