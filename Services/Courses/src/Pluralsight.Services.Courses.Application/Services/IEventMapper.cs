using System.Collections.Generic;
using Convey.CQRS.Events;
using Pluralsight.Services.Courses.Core.Entities;

namespace Pluralsight.Services.Courses.Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}