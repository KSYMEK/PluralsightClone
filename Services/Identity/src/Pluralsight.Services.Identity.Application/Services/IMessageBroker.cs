namespace Pluralsight.Services.Identity.Application.Services {
    using System.Threading.Tasks;
    using Convey.CQRS.Events;

    public interface IMessageBroker {
        Task PublishAsync(params IEvent[] events);
    }
}