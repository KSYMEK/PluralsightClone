using System;
using System.Net;
using Convey.WebApi.Exceptions;
using Pluralsight.Services.Courses.Application.Exceptions;
using Pluralsight.Services.Courses.Core.Exceptions;

namespace Pluralsight.Services.Courses.Infrastructure.Exceptions {
    public class ExceptionToResponseMapper : IExceptionToResponseMapper {
        public ExceptionResponse Map(Exception exception) {
            return exception switch {
                DomainException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                AppException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "We obtained a problem, try again later."},
                    HttpStatusCode.BadRequest)
            };
        }
    }
}