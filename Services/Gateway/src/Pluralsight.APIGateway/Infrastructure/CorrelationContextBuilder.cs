﻿namespace Pluralsight.APIGateway.Infrastructure
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Ntrada;
    using Ntrada.Extensions.RabbitMq;
    using OpenTracing;

    public class CorrelationContextBuilder : IContextBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public CorrelationContextBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object Build(ExecutionData executionData)
        {
            var tracer = _serviceProvider.GetService(typeof(ITracer)) as ITracer;
            var spanContext = tracer is null ? string.Empty :
                tracer.ActiveSpan is null ? string.Empty : tracer.ActiveSpan.Context.ToString();

            var name = string.Empty;
            if (executionData.Route.Config is {} &&
                executionData.Route.Config.TryGetValue("routing_key", out var routingKey))
                name = routingKey ?? string.Empty;


            if (string.IsNullOrWhiteSpace(name))
                name = $"{executionData.Context.Request.Method} {executionData.Context.Request.Path}";

            return new CorrelationContext
            {
                CorrelationId = executionData.RequestId,
                User = new UserContext
                {
                    Id = executionData.UserId,
                    Claims = executionData.Claims,
                    Role = executionData.Claims.FirstOrDefault(c => c.Key == ClaimTypes.Role).Value,
                    IsAuthenticated = !string.IsNullOrWhiteSpace(executionData.UserId)
                },
                ResourceId = executionData.ResourceId,
                TraceId = executionData.TraceId,
                ConnectionId = executionData.Context.Connection.Id,
                Name = name,
                CreatedAt = DateTime.UtcNow,
                SpanContext = spanContext
            };
        }
    }
}