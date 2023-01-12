using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.Tests.Commands.Mocks;

namespace Todo.Domain.Tests.Commands.Handlers
{
    [TestClass]
    public class CreateTodoHandlerTest
    {
        private Mock<ITodoRepository> _mock;

        public CreateTodoHandlerTest()
            => _mock = new Mock<ITodoRepository>();

        [TestMethod]
        public void Deve_retornar_valido_quando_executar_a_criacao_da_tarefa_completa()
        {
            //Arrange
            var sut = new CreateTodoHandler(_mock.Object);

            var createTodoCommand = new CreateTodoCommand("Meu titulo", "Hiagor", new DateTime(2001, 03, 17));

            //Act
            var result = sut.Handle(createTodoCommand);

            //Assert
            Assert.IsTrue(result.Success);
            MockTodoRepository.VerifyCreate(1, _mock);
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_nao_conseguir_executar_a_criacao_completa()
        {
            //Arrange
            var sut = new CreateTodoHandler(_mock.Object);

            var createTodoCommand = new CreateTodoCommand();

            //Act
            var result = sut.Handle(createTodoCommand);

            //Assert
            Assert.IsFalse(result.Success);
            MockTodoRepository.VerifyCreate(0, _mock);
        }
    }
}
