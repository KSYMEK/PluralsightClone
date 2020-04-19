using System;
using Pluralsight.Services.Courses.Application.Services;

namespace Pluralsight.Services.Courses.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}