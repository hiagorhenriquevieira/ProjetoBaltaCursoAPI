using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Inputs;

namespace Todo.Domain.Tests.Commands.Inputs
{
    [TestClass]
    public class UpdateTodoCommandTest
    {
        [TestMethod]
        public void Deve_retornar_valido_quando_command_estiver_completa()
        {
            //Arrange
            var sut = new UpdateTodoCommand(id: new Guid(), title: "Meu titulo", user: "Hiagor");

            //Act & Assert
            Assert.IsTrue(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_command_estiver_vazia()
        {
            //Arrange
            var sut = new UpdateTodoCommand();
            
            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_titulo_nao_for_informado()
        {
            //Arrange
            var sut = new UpdateTodoCommand(id: new Guid(), title: string.Empty, user: "Hiagor");

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_usuario_nao_for_informado()
        {
            //Arrange
            var sut = new UpdateTodoCommand(id: new Guid(), title: "Meu titulo", user: string.Empty);

            //Act & Assert
            Assert.IsFalse(sut.Validate());
        }
    }
}