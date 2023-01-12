using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class UpdateTodoCommand : Notifiable<Notification>, ICommand
    {
        public UpdateTodoCommand() { }

        public UpdateTodoCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterOrEqualsThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .IsGreaterOrEqualsThan(User, 6, "User", "Usuario não pode conter menos de 6 caracteres!")
                    .IsNotNullOrEmpty(Title, "Title","Titulo não pode ser nulo!")
                    .IsNotNullOrEmpty(User, "User","Usuario não pode ser nulo!")
            );
            return IsValid;
        }
    }
}