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
    public class MarkTodoAsDoneHandlerTest
    {
        private Mock<ITodoRepository> _mock;

        public MarkTodoAsDoneHandlerTest() 
            => _mock = new Mock<ITodoRepository>();

        [TestMethod]
        public void Deve_retornar_valido_quando_executar_a_atualizacao_da_tarefa_para_concluida()
        {
            //Arrange
            var sut = new MarkTodoAsDoneHandler(_mock.Object);
            var todoItem = new TodoItem("Titulo antigo", "Hiagor", new DateTime(2001, 03, 17));
            MockTodoRepository.SetupGetById(todoItem, _mock);

            var markTodoAsDoneCommand = new MarkTodoAsDoneCommand(new Guid(),"Hiagor");

            //Act
            var result = sut.Handle(markTodoAsDoneCommand);

            TodoItem todoAtualizado = (TodoItem)result.Data;

            //Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(expected: true, actual: todoAtualizado.Done);
            MockTodoRepository.VerifyUpdate(1, _mock);
            MockTodoRepository.VerifyGetById(1, _mock);
        }

        [TestMethod]
        public void Deve_retornar_invalido_quando_nao_conseguir_atualizar_a_tarefa_para_concluida()
        {
            //Arrange
            var sut = new MarkTodoAsDoneHandler(_mock.Object);

            var markTodoAsDoneCommand = new MarkTodoAsDoneCommand();

            //Act
            var result = sut.Handle(markTodoAsDoneCommand);

            //Assert
            Assert.IsFalse(result.Success);
            MockTodoRepository.VerifyUpdate(0, _mock);
            MockTodoRepository.VerifyGetById(0, _mock);
        }
    }
}
