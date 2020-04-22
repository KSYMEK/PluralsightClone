namespace Pluralsight.Services.Courses.Infrastructure.Exceptions
{
    using System;
    using Application.Exceptions;
    using Convey.MessageBrokers.RabbitMQ;
    using Core.Exceptions;

    public class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message)
        {
            return exception switch
            {
                InvalidCourseTitleException ex => new CourseNameAlreadyExistsException(ex.Message),
                _ => null
            };
        }
    }
}