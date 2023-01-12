using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Queries
{
    [TestClass]
    public class TodoQueriesTest
    {
        private List<TodoItem> _items;

        public TodoQueriesTest()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Primeiro Titulo", "Hiagor", new DateTime(2001, 01, 01)));
            _items.Add(new TodoItem("Segundo Titulo", "Albert", new DateTime(2001, 01, 01)));
            _items.Add(new TodoItem("Terceiro Titulo", "Hiagor", new DateTime(2001, 01, 01)));
            _items.Add(new TodoItem("Quarto Titulo", "Hiagor", new DateTime(2001, 01, 01)));
            _items.Add(new TodoItem("Quinto Titulo", "Hiagor", new DateTime(2002, 01, 01)));

            _items[0].MarkAsDone();
            _items[4].MarkAsDone();
        }

        [TestMethod]
        public void Deve_retornar_apenas_as_tarefas_do_usuario_que_foi_informado()
        {
            //Arrange & Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Hiagor"));

            //Assert
            Assert.AreEqual(expected: 4, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_as_tarefas_concluidas_do_usuario_que_foi_informado()
        {
            //Arrange & Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("Hiagor"));

            //Assert
            Assert.AreEqual(expected: 2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_as_tarefas_que_ainda_nao_foram_concluidas_do_usuario_que_foi_informado()
        {
            //Arrange & Act
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("Albert"));

            //Assert
            Assert.AreEqual(expected: 1, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_as_tarefas_que_ainda_nao_foram_concluidas_no_periodo_informado()
        {
            //Arrange & Act
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("Hiagor",new DateTime(2001,01,01), false));

            //Assert
            Assert.AreEqual(expected: 2, result.Count());
        }

        [TestMethod]
        public void Deve_retornar_apenas_as_tarefas_que_foram_concluidas_no_periodo_informado()
        {
            //Arrange & Act
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("Hiagor",new DateTime(2001, 01, 01), true));

            //Assert
            Assert.AreEqual(expected: 1, result.Count());
        }
    }
}
