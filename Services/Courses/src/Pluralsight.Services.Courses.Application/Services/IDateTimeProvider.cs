namespace Pluralsight.Services.Courses.Application.Services
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}