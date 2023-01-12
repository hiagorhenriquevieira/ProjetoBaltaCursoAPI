using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class MarkTodoAsDoneHandler :
        Notifiable<Notification>,
        IHandler<MarkTodoAsDoneCommand>
    {
        private readonly ITodoRepository _repository;

        public MarkTodoAsDoneHandler(ITodoRepository repository)
            => _repository = repository;

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(success: command.IsValid, message: "Ops, parece que sua tarefa esta errada!", data: command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();

            _repository.Update(todo);

            return new GenericCommandResult(success: command.IsValid, message: "Tarefa salva", data: todo);
        }
    }
}