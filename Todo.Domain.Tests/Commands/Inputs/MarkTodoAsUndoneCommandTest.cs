using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class MarkTodoAsUndoneCommandTest
    {
        [TestMethod]
        public void Deve_retornar_invalido_quando_command_estiver_vazia()
        {
            //Arrange
            var sut = new MarkTodoAsUndoneCommand();

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_valido_quando_command_estiver_completa()
        {
            //Arrange
            var sut = new MarkTodoAsUndoneCommand(new Guid(), "Hiagor");

            //Act & Assert
            Assert.IsTrue(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_usuario_estiver_vazio()
        {
            //Arrange
            var sut = new MarkTodoAsUndoneCommand(new Guid(), string.Empty);

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }
    }
}
