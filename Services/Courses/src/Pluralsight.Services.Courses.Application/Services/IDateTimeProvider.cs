using System;

namespace Pluralsight.Services.Courses.Application.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}