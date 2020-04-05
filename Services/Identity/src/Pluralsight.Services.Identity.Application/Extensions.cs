namespace Pluralsight.Services.Identity.Application {
    using Convey;
    using Convey.CQRS.Commands;
    using Convey.CQRS.Events;

    public static class Extensions {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder) {
            return builder.AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher();
        }
    }
}