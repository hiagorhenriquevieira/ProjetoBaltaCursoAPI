using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class CreateTodoCommandTest
    {
        [TestMethod]
        public void Deve_retornar_valido_quando_command_estiver_completa()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: "Meu titulo", "Hiagor", new DateTime(2001,03,17));

            //Act & Assert
            Assert.IsTrue(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_a_data_for_menor_que_a_permitida()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: "Meu titulo", user: "Hiagor", date: new DateTime(1899,03,17));

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_a_data_nao_for_atribuida()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: "Meu titulo", user: "Hiagor", date: new DateTime());

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_a_data_for_maior_que_a_permitida()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: "Meu titulo", user: "Hiagor", date: new DateTime(2091, 03, 17));

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_titulo_estiver_vazio()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: string.Empty, user:"Hiagor", new DateTime(2001, 03, 17));

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_usuario_estiver_vazio()
        {
            //Arrange
            var sut = new CreateTodoCommand(title: "Meu titulo", user: string.Empty, new DateTime(2001, 03, 17));

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_command_estiver_vazia()
        {
            //Arrange
            var sut = new CreateTodoCommand();

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }
    }
}
