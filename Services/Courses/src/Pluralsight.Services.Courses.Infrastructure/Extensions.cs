namespace Pluralsight.Services.Courses.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Application;
    using Application.Services;
    using Contexts;
    using Convey;
    using Convey.CQRS.Commands;
    using Convey.CQRS.Events;
    using Convey.CQRS.Queries;
    using Convey.Discovery.Consul;
    using Convey.Docs.Swagger;
    using Convey.HTTP;
    using Convey.LoadBalancing.Fabio;
    using Convey.MessageBrokers;
    using Convey.MessageBrokers.Outbox;
    using Convey.MessageBrokers.Outbox.Mongo;
    using Convey.MessageBrokers.RabbitMQ;
    using Convey.Metrics.AppMetrics;
    using Convey.Persistence.MongoDB;
    using Convey.Persistence.Redis;
    using Convey.Tracing.Jaeger;
    using Convey.Tracing.Jaeger.RabbitMQ;
    using Convey.WebApi;
    using Convey.WebApi.CQRS;
    using Convey.WebApi.Swagger;
    using Core.Repositories;
    using Decorators;
    using Exceptions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Mongo.Documents;
    using Mongo.Repositories;
    using Newtonsoft.Json;
    using Services;

    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddTransient<ICourseRepository, CourseRepository>();
            builder.Services.AddTransient<ICourseModuleRepository, CourseModuleRepository>();
            builder.Services.AddTransient<ICourseEpisodeRepository, CourseEpisodeRepository>();
            builder.Services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            builder.Services.AddTransient<IAppContextFactory, AppContextFactory>();
            builder.Services.AddTransient(ctx => ctx.GetRequiredService<IAppContextFactory>().Create());
            builder.Services.TryDecorate(typeof(ICommandHandler<>), typeof(OutboxCommandHandlerDecorator<>));
            builder.Services.TryDecorate(typeof(IEventHandler<>), typeof(OutboxEventHandlerDecorator<>));

            return builder
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddConsul()
                .AddFabio()
                .AddRabbitMq(plugins: p => p.AddJaegerRabbitMqPlugin())
                .AddMessageOutbox(o => o.AddMongo())
                .AddExceptionToMessageMapper<ExceptionToMessageMapper>()
                .AddMongo()
                .AddRedis()
                .AddMetrics()
                .AddJaeger()
                .AddMongoRepository<CourseDocument, Guid>("courses")
                .AddMongoRepository<CourseModuleDocument, Guid>("courseModules")
                .AddMongoRepository<CourseEpisodeDocument, Guid>("courseEpisodes")
                .AddWebApiSwaggerDocs();
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandler()
                .UseSwaggerDocs()
                .UseJaeger()
                .UseConvey()
                .UsePublicContracts<ContractAttribute>()
                .UseMetrics()
                .UseRabbitMq();

            return app;
        }

        internal static CorrelationContext GetCorrelationContext(this IHttpContextAccessor accessor)
        {
            return accessor.HttpContext?.Request.Headers.TryGetValue("Correlation-Context", out var json) is true
                ? JsonConvert.DeserializeObject<CorrelationContext>(json.FirstOrDefault() ?? string.Empty)
                : null;
        }

        internal static IDictionary<string, object> GetHeadersToForward(this IMessageProperties messageProperties)
        {
            const string sagaHeader = "Saga";
            if (messageProperties?.Headers is null ||
                !messageProperties.Headers.TryGetValue(sagaHeader, out var saga)) return null;

            return saga is null
                ? null
                : new Dictionary<string, object>
                {
                    [sagaHeader] = saga
                };
        }

        internal static string GetSpanContext(this IMessageProperties messageProperties, string header)
        {
            if (messageProperties is null) return string.Empty;

            if (messageProperties.Headers.TryGetValue(header, out var span) && span is byte[] spanBytes)
                return Encoding.UTF8.GetString(spanBytes);

            return string.Empty;
        }
    }
}