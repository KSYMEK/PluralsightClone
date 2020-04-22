namespace Pluralsight.Services.Identity.Infrastructure.Exceptions
{
    using System;
    using Application.Commands;
    using Application.Events.Rejected;
    using Convey.MessageBrokers.RabbitMQ;
    using Core.Exceptions;

    public class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
        {
            return exception switch
            {
                EmailInUseException ex => new SignedUpRejected(ex.Email, ex.Message, ex.Code),
                InvalidCredentialsException ex => new SignInRejected(ex.Email, ex.Message, ex.Code),
                InvalidEmailException ex => message switch
                {
                    SignIn command => new SignInRejected(command.Email, ex.Message, ex.Code),
                    SignedUpRejected command => new SignedUpRejected(command.Email, ex.Message, ex.Code),
                    _ => null
                },
                _ => null
            };
        }
    }
}