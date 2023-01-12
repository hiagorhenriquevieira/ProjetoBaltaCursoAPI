using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class MarkTodoAsUndoneHandler :
        Notifiable<Notification>,
        IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public MarkTodoAsUndoneHandler(ITodoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(success: command.IsValid, message: "Ops, parece que sua tarefa esta errada!", data: command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();

            _repository.Update(todo);

            return new GenericCommandResult(success: command.IsValid, message: "Tarefa salva", data: todo);
        }
    }
}