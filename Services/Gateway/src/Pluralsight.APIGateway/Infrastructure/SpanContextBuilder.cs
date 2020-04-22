namespace Pluralsight.APIGateway.Infrastructure
{
    using System;
    using Ntrada;
    using Ntrada.Extensions.RabbitMq;
    using OpenTracing;

    public class SpanContextBuilder : ISpanContextBuilder
    {
        private readonly IServiceProvider _serviceProvider;

        public SpanContextBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string Build(ExecutionData executionData)
        {
            var tracer = _serviceProvider.GetService(typeof(ITracer)) as ITracer;
            var spanContext = tracer is null ? string.Empty :
                tracer.ActiveSpan is null ? string.Empty : tracer.ActiveSpan.Context.ToString();

            return spanContext;
        }
    }
}