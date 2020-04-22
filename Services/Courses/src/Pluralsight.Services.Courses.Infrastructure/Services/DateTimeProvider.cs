namespace Pluralsight.Services.Courses.Infrastructure.Services
{
    using System;
    using Application.Services;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}