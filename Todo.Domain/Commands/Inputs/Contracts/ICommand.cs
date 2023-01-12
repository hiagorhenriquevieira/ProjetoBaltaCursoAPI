namespace Todo.Domain.Commands.Inputs.Contracts
{
    public interface ICommand 
    {
        bool Validate();
    }
}