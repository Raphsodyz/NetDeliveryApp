using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Moq;
using NetDeliveryAppAplicacao.DTOs;
using NetDeliveryAppAplicacao.DTOs.IdentityDTO;
using NetDeliveryAppAplicacao.Interfaces.Identity;
using NetDeliveryAppServicos.Controllers;
using Xunit;

namespace NetDeliveryAppTestes.ApiTestes.Identity
{
    public class UsuariosControllerTeste
    {
        [Fact]
        public async Task Login_LoginEfetuado_RetornarOk()
        {
            //Arrange
            var usuario = new LoginDTO()
            {
                Email = "arthurvsr@gmail.com",
                PasswordHash = "1234"
            };

            var identityTest = new Mock<IUsuariosAplicacao>();
            identityTest.Setup(i => i.Login(usuario))
                .ReturnsAsync(SignInResult.Success);

            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Login(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(resultado);
        }

        [Fact]
        public async Task Login_ErroLogin_RetornarUnauthorized()
        {
            //Arrange
            var usuario = new LoginDTO()
            {
                Email = "arthurvsr@gmail.com",
                PasswordHash = "1234"
            };

            var identityTest = new Mock<IUsuariosAplicacao>();
            identityTest.Setup(i => i.Login(usuario))
                .ReturnsAsync(SignInResult.Failed);

            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Login(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public async Task Login_ErroLoginException_Retornar500()
        {
            //Arrange
            var usuario = new LoginDTO()
            {
                Email = "arthurvsr@gmail.com",
                PasswordHash = "1234"
            };

            var identityTest = new Mock<IUsuariosAplicacao>();
            identityTest.Setup(i => i.Login(usuario))
                .Throws<Exception>();

            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Login(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(resultado);
        }

        [Fact]
        public async Task Registrar_RegistroFeito_RetornarCreated()
        {
            //Arrange
            var usuario = new UsuarioDTO()
            {
                UserName = "Arthur",
                PhoneNumber = "999999999",
                Email = "arthurvsr@gmail.com",
                PasswordHash = "1234",
                Foto = "wregergerg",
                EnderecoId = 0,
                Endereco = new EnderecoDTO()
            };

            var identityTest = new Mock<IUsuariosAplicacao>();
            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Registrar(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(resultado);
        }

        [Fact]
        public async Task Registrar_RegistroErrado_RetornarBadRequest()
        {
            //Arrange
            var usuario = new UsuarioDTO();
            usuario = null;

            var identityTest = new Mock<IUsuariosAplicacao>();
            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Registrar(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(resultado);
        }

        [Fact]
        public async Task Registrar_ErroRegistrarException_Retornar500()
        {
            //Arrange
            var usuario = new UsuarioDTO()
            {
                UserName = "Arthur",
                PhoneNumber = "999999999",
                Email = "arthurvsr@gmail.com",
                PasswordHash = "1234",
                Foto = "wregergerg",
                EnderecoId = 0,
                Endereco = new EnderecoDTO()
            };

            var identityTest = new Mock<IUsuariosAplicacao>();
            identityTest.Setup(i => i.Registrar(usuario))
                .Throws<Exception>();

            var controller = new UsuariosController(identityTest.Object);

            //Act
            var resultado = await controller.Registrar(usuario);

            //Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.ObjectResult>(resultado);
        }
    }
}
