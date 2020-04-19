using System;
using Convey.CQRS.Events;

namespace Pluralsight.Services.Courses.Application.Events
{
    [Contract]
    public class CourseCreated : IEvent
    {
        public Guid CourseId { get; }

        public CourseCreated(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}