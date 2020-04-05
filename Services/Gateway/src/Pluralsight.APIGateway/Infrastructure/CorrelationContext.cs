namespace Pluralsight.APIGateway.Infrastructure {
    using System;

    internal class CorrelationContext {
        public string CorrelationId { get; set; }
        public string SpanContext { get; set; }
        public UserContext User { get; set; }
        public string ResourceId { get; set; }
        public string TraceId { get; set; }
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}