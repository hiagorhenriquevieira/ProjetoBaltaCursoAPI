using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}