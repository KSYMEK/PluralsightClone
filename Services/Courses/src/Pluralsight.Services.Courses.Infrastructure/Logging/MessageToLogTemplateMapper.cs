using System;
using System.Collections.Generic;
using Convey.Logging.CQRS;

namespace Pluralsight.Services.Courses.Infrastructure.Logging
{
    public class MessageToLogTemplateMapper : IMessageToLogTemplateMapper
    {
        private static IReadOnlyDictionary<Type, HandlerLogTemplate> MessageTemplates
            => new Dictionary<Type, HandlerLogTemplate>
            {
            };
        
        public HandlerLogTemplate Map<TMessage>(TMessage message) where TMessage : class
        {
            var key = message.GetType();
            return MessageTemplates.TryGetValue(key, out var template) ? template : null;
        }
    }
}