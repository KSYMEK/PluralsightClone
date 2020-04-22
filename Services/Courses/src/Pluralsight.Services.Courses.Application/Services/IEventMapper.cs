namespace Pluralsight.Services.Courses.Application.Services
{
    using System.Collections.Generic;
    using Convey.CQRS.Events;
    using Core.Entities;

    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}