using Moq;
using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Commands.Mocks
{
    public static class MockTodoRepository
    {
        public static void VerifyUpdate(int callCount, Mock<ITodoRepository> mock)
           => mock.Verify(x => x.Update(It.IsAny<TodoItem>()), Times.Exactly(callCount));

        public static void VerifyGetById(int callCount, Mock<ITodoRepository> mock)
            => mock.Verify(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>()), Times.Exactly(callCount));

        public static void VerifyCreate(int callCount, Mock<ITodoRepository> mock)
            => mock.Verify(x => x.Create(It.IsAny<TodoItem>()), Times.Exactly(callCount));

        public static void SetupGetById(TodoItem returns, Mock<ITodoRepository> mock) 
            => mock.Setup(x => x.GetById(It.IsAny<Guid>(), It.IsAny<string>())).Returns(returns);

    }
}