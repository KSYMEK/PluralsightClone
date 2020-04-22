namespace Pluralsight.Services.Courses.Application
{
    using System;
    using System.Collections.Generic;

    public interface IIdentityContext
    {
        Guid Id { get; }
        string Role { get; }
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        IDictionary<string, string> Claims { get; }
    }
}