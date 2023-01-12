using System;
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Inputs.Contracts;

namespace Todo.Domain.Commands.Inputs
{
    public class CreateTodoCommand : Notifiable<Notification>, ICommand
    {
        public CreateTodoCommand(){ }

        public CreateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

        public bool Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsGreaterOrEqualsThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .IsNotNullOrEmpty(Title, "Title", "Titulo não pode ser nulo!")
                    .IsNotNullOrEmpty(User, "Usuario", "Usuario não pode ser nulo!")
                    .IsGreaterOrEqualsThan(User, 6, "User", "Usuario não pode conter menos de 6 caracteres!")
                    .IsNotNull(Date, "Date", "Data invalida!")
                    .IsNotNullOrEmpty(VerificarData(), "VerificarData", "Data informada é invalida!")
            );
            return IsValid;
        }

        private string VerificarData()
        {
            var dataMinima = new DateTime(1900,03,17);
            if (Date < dataMinima)
                return String.Empty;

            var dataMaxima = new DateTime(2070, 03, 17);
            if(Date > dataMaxima)
                return String.Empty;

            return "Data valida";
        }
    }
}