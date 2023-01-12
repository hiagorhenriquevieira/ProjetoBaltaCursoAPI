using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
    {
        public MarkTodoAsDoneCommand() { }

        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterOrEqualsThan(User, 6, "User", "Usuario não pode conter menos de 6 caracteres!")
                    .IsNotNullOrEmpty(User, "User", "Usuário não pode ser nulo!")
            );
            return IsValid;
        }
    }
}