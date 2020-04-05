namespace Pluralsight.Services.Identity.Infrastructure.Exceptions {
    using System;
    using System.Net;
    using Convey.WebApi.Exceptions;
    using Core.Exceptions;

    public class ExceptionToResponseMapper : IExceptionToResponseMapper {
        public ExceptionResponse Map(Exception exception) {
            return exception switch {
                DomainException ex => new ExceptionResponse(new {code = ex.Code, reason = ex.Message},
                    HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new {code = "error", reason = "We obtained a problem, try again later."},
                    HttpStatusCode.BadRequest)
            };
        }
    }
}