using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.Interfaces;
using NetDeliveryAppDominio.Identity.Usuarios;
using NetDeliveryAppServicos.Controllers;
using Xunit;

namespace NetDeliveryAppTestes.ApiTestes
{
    public class PedidosControllerTeste
    {
        [Fact]
        public async Task Encontrar_PedidoInexistente_RetornarNotFound()
        {
            //Arrange
            IPedidoAplicacao produto = null;
            var controller = new PedidosController(produto);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<NotFoundObjectResult>(resultado);
        }

        [Fact]
        public async Task Encontrar_PedidoEncontrado_RetornarOk()
        {
            //Arrange
            PedidoDTO pedido = new PedidoDTO();

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Encontrar(It.IsAny<int>()))
                .ReturnsAsync(pedido);

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Encontrar(It.IsAny<int>());

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public async Task Listar_PedidosDoBanco_RetornarOk()
        {
            //Arrange
            List<PedidoDTO> ListaPedidos = new List<PedidoDTO>();
            PedidoDTO pedido = new PedidoDTO();

            ListaPedidos.Add(pedido);

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .ReturnsAsync(ListaPedidos);

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]

        public async Task Listar_BancoIndisponivel_RetornarBadRequest()
        {
            //Arrange
            List<PedidoDTO> ListaPedidos = new List<PedidoDTO>();
            PedidoDTO pedido = new PedidoDTO();

            ListaPedidos.Add(pedido);

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Listar())
                .Throws<Exception>();

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Listar();

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task Adicionar_NovoPedido_RetornarCreated()
        {
            //Arrange
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            var repositoryTest = new Mock<IPedidoAplicacao>();
            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoPedido);

            //Assert
            Assert.IsType<CreatedResult>(resultado);

            novoPedido.Id.Should().NotBe(null, "Não pode ser vazio o ID.");
            novoPedido.Valor.Should().NotBe(null, "Não pode ser vazio o Valor.");
            novoPedido.Itens.Should().NotBeNull();
            novoPedido.Id.Should().Be(0);
            novoPedido.Valor.Should().Be(32);
            novoPedido.Pagamento.Should().Be("Cartão de crédito");
        }

        [Fact]
        public async Task Adicionar_PedidoIncompleto_RetornarBadrequest()
        {
            //Arrange
            PedidoDTO novoPedido = null;

            var repositoryTest = new Mock<IPedidoAplicacao>();
            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Adicionar(novoPedido);

            //Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public void Adicionar_DataAnnotationPedidoTeste_PedidoCorreto()
        {
            //Assert
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            //Act
            var erros = ValidarObjeto(novoPedido);

            //Assert
            Assert.True(erros.Count == 0);
        }

        [Fact]
        public void Adicionar_DataAnnotationPedidoTeste_PedidoComErros()
        {
            //Assert
            var novoPedido = new PedidoDTO()
            {
                Id = -2,
                Valor = -432,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = null,
                Pagamento = null,
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            //Act
            var erros = ValidarObjeto(novoPedido);

            //Assert
            Assert.True(erros.Count == 4);
        }

        [Fact]
        public async Task Editar_PedidoExistente_RetornarOk()
        {
            //Arrange
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Editar(It.IsAny<PedidoDTO>())).Returns(Task.FromResult(novoPedido));

            var pedidoEditado = new PedidoDTO()
            {
                Id = novoPedido.Id + 3,
                Itens = novoPedido.Itens + ", creme de açaí",
                Valor = 42
            };

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(pedidoEditado);

            //Assert
            resultado.Should().BeOfType<OkResult>();

            pedidoEditado.Id.Should().Be(3);
            pedidoEditado.Itens.Should().Be("1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon, creme de açaí");
            pedidoEditado.Valor.Should().Be(42);
        }

        [Fact]
        public async Task Editar_PedidoExistente_RetornarErro()
        {
            //Arrange
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Editar(novoPedido)).Throws<Exception>();

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Editar(novoPedido);

            //Assert
            resultado.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task Deletar_PedidoExistente_RetornarOk()
        {
            //Arrange
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Returns(Task.FromResult(novoPedido));

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Deletar_PedidoInexistente_RetornarNotFound()
        {
            //Arrange
            var novoPedido = new PedidoDTO()
            {
                Id = 0,
                Valor = 32,
                Observacao = "Lanche sem salada",
                DataPedido = DateTime.Now,
                Itens = "1 Hamburguer, 1 coca-cola lata, 1 porção de batata cheddar e bacon",
                Pagamento = "Cartão de crédito",
                Troco = "Não.",
                Entregue = false,
                UsuarioId = 0,
                usuario = new Usuario()
            };

            var repositoryTest = new Mock<IPedidoAplicacao>();
            repositoryTest.Setup(r => r.Deletar(It.IsAny<int>())).Throws<Exception>();

            var controller = new PedidosController(repositoryTest.Object);

            //Act
            var resultado = await controller.Deletar(It.IsAny<int>());

            //Assert
            resultado.Should().BeOfType<NotFoundObjectResult>();
        }

        private static IList<ValidationResult> ValidarObjeto(PedidoDTO pedido)
        {
            var validar = new List<ValidationResult>();
            var contexto = new ValidationContext(pedido, null, null);
            Validator.TryValidateObject(pedido, contexto, validar, true);
            return validar;
        }
        
    }
}