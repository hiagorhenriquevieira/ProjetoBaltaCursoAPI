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
    public class UpdateTodoHandlerTest
    {
        private Mock<ITodoRepository> _mock;

        public UpdateTodoHandlerTest()
            => _mock = new Mock<ITodoRepository>();

        [TestMethod]
        public void Deve_retornar_valido_quando_executar_a_atualizacao_da_tarefa()
        {
            //Arrange
            var sut = new UpdateTodoHandler(_mock.Object);
            var todoItem = new TodoItem("Titulo antigo", "Hiagor", new DateTime(2001, 03, 17));
            MockTodoRepository.SetupGetById(todoItem, _mock);

            var updateTodoCommand = new UpdateTodoCommand(id: new Guid(), title: "Titulo novo", user: "Hiagor");
            
            //Act
            var result = sut.Handle(updateTodoCommand);
            
            TodoItem todoAtualizado = (TodoItem)result.Data;

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expected: "Titulo novo", actual: todoAtualizado.Title);
            MockTodoRepository.VerifyUpdate(1, _mock);
            MockTodoRepository.VerifyGetById(1, _mock);
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_nao_conseguir_executar_atualizacao_da_tarefa()
        {
            //Arrange
            var sut = new UpdateTodoHandler(_mock.Object);

            var createTodoCommand = new UpdateTodoCommand();

            //Act
            var result = sut.Handle(createTodoCommand);

            //Assert
            Assert.IsFalse(result.Success);
            MockTodoRepository.VerifyUpdate(0, _mock);
            MockTodoRepository.VerifyGetById(0, _mock);
        }
    }
}