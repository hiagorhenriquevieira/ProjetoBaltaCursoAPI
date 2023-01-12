using Flunt.Notifications;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Inputs;
using Todo.Domain.Commands.Inputs.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Commands.Handlers
{
    public class UpdateTodoHandler :
        Notifiable<Notification>,
        IHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoHandler(ITodoRepository repository) 
            => _repository = repository;
        
        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
        
            if (!command.IsValid)
                return new GenericCommandResult(success: command.IsValid, message: "Ops, parece que sua tarefa esta errada!", data: command.Notifications);

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);

            _repository.Update(todo);

            return new GenericCommandResult(success: command.IsValid, message: "Tarefa atualizada", data: todo);
        }
    }
}