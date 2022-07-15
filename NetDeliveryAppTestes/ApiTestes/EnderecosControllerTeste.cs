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
    public class EnderecosControllerTeste
    {
        [Fact]
        public async Task Encontrar_EnderecoInexistente_RetornarNotFound()
        {
            //Arrange
            IEnderecoAplicacao endereco = null;
            var controller = new EnderecosController(endereco);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task Encontrar_EnderecoEncontrado_RetornarOk()
        {
            //Arrange
            EnderecoDTO produto = new EnderecoDTO();

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Encontrar(It.IsAny<int>()))
                .ReturnsAsync(produto);

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task Listar_EnderecosDoBanco_RetornarOk()
        {
            //Arrange
            List<EnderecoDTO> ListaEnderecos = new List<EnderecoDTO>();
            EnderecoDTO endereco = new EnderecoDTO();

            ListaEnderecos.Add(endereco);

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(ListaEnderecos);

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task Listar_BancoIndisponivel_RetornarBadRequest()
        {
            //Arrange
            List<EnderecoDTO> ListaEnderecos = new List<EnderecoDTO>();
            EnderecoDTO endereco = new EnderecoDTO();

            ListaEnderecos.Add(endereco);

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .Throws<Exception>();

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task Adicionar_NovoEndereco_RetornarCreated()
        {
            //Arrange
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoEndereco);

            //Assert
            Assert.IsType<CreatedResult>(resultado);

            novoEndereco.Id.Should().NotBe(null, "Não pode ser vazio o ID.");
            novoEndereco.Numero.Should().NotBe(null, "Não pode ser vazio o Numero.");
            novoEndereco.Rua.Should().NotBeNull();
            novoEndereco.Id.Should().Be(0);
        }

        [Fact]
        public async Task Adicionar_EnderecoIncompleto_RetornarBadrequest()
        {
            //Arrange
            EnderecoDTO novoEndereco = null;

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoEndereco);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Adicionar_DataAnnotationEnderecoTeste_EnderecoCorreto()
        {
            //Assert
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            //Act
            var erros = ValidarObjeto(novoEndereco);

            //Assert
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Adicionar_DataAnnotationEnderecoTeste_EnderecoComErros()
        {
            //Assert
            var novoEndereco = new EnderecoDTO()
            {
                Id = -5,
                Rua = null,
                Numero = -30,
                Bairro = null,
                Cidade = null,
                Observacao = ""
            };

            //Act
            var erros = ValidarObjeto(novoEndereco);

            //Assert
            Assert.True(erros.Count == 5);
        }

        [Fact]
        public async Task Editar_EnderecoExistente_RetornarOk()
        {
            //Arrange
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<EnderecoDTO>())).Returns(Task.FromResult(novoEndereco));

            var enderecoEditado = new EnderecoDTO()
            {
                Id = novoEndereco.Id + 3,
                Rua = novoEndereco.Rua + " do Brasil",
                Numero = 9,
                Bairro = "Mineirão",
                Cidade = "Belo Horizonte",
                Observacao = "Ao lado do supermercado."
            };

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(enderecoEditado);

            //Assert
            resultado.Should().BeOfType<OkResult>();

            enderecoEditado.Id.Should().Be(3);
            enderecoEditado.Rua.Should().Be("Independencia do Brasil");
            enderecoEditado.Numero.Should().Be(9);
            enderecoEditado.Bairro.Should().Be("Mineirão");
            enderecoEditado.Cidade.Should().Be("Belo Horizonte");
        }

        [Fact]
        public async Task Editar_EnderecoExistente_RetornarErro()
        {
            //Arrange
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Editar(novoEndereco)).Throws<Exception>();

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(novoEndereco);

            //Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Deletar_EnderecoExistente_RetornarOk()
        {
            //Arrange
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Returns(Task.FromResult(novoEndereco));

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Deletar_EnderecoInexistente_RetornarNotFound()
        {
            //Arrange
            var novoEndereco = new EnderecoDTO()
            {
                Id = 0,
                Rua = "Independencia",
                Numero = 5,
                Bairro = "Maracanã",
                Cidade = "Bahia",
                Observacao = "Ao lado do supermercado."
            };

            var repositoryTest = new Mock<IEnderecoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Throws<Exception>();

            var controller = new EnderecosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<NotFoundObjectResult>();
        }

        private static IList<ValidationResult> ValidarObjeto(EnderecoDTO enderecoDTO)
        {
            var validar = new List<ValidationResult>();
            var contexto = new ValidationContext(enderecoDTO, null, null);
            Validator.TryValidateObject(enderecoDTO, contexto, validar, true);
            return validar;
        }
    }
}

