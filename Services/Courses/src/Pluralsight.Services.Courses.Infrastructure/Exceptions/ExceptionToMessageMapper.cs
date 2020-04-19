using System;
using Convey.MessageBrokers.RabbitMQ;
using Pluralsight.Services.Courses.Application.Exceptions;
using Pluralsight.Services.Courses.Core.Exceptions;

namespace Pluralsight.Services.Courses.Infrastructure.Exceptions {
    public class ExceptionToMessageMapper : IExceptionToMessageMapper {
        public object Map(Exception exception, object message) {
            return exception switch {
                InvalidCourseTitleException ex => new CourseNameAlreadyExistsException(ex.Message),
                _ => null
            };
        }
    }
}