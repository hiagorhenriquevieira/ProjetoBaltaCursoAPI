using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class CreateTodoHandler :
        Notifiable<Notification>,
        IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public CreateTodoHandler(ITodoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(success: command.IsValid, message: "Ops, parece que sua tarefa esta errada!", data: command.Notifications);

            var todo = new TodoItem(title: command.Title, user: command.User, date: command.Date);

            _repository.Create(todo);

            return new GenericCommandResult(success: command.IsValid, message: "Tarefa salva", data: todo);
        }
    }
}
