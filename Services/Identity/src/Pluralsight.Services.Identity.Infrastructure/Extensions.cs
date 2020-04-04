using System.Collections.Generic;
using System.Linq;
using System.Text;
using Convey.MessageBrokers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Pluralsight.Services.Identity.Infrastructure.Contexts;

namespace Pluralsight.Services.Identity.Infrastructure {
	public static class Extensions {
		internal static CorrelationContext GetCorrelationContext(this IHttpContextAccessor accessor) =>
			accessor.HttpContext?.Request.Headers.TryGetValue("Correlation-Context", out var json) is true
				? JsonConvert.DeserializeObject<CorrelationContext>(json.FirstOrDefault())
				: null;

		internal static string GetSpanContext(this IMessageProperties messageProperties, string header) {
			if (messageProperties is null)
				return string.Empty;

			if (messageProperties.Headers.TryGetValue(header, out var span) && span is byte[] bytes)
				return Encoding.UTF8.GetString(bytes);

			return string.Empty;
		}

		internal static IDictionary<string, object> GetHeadersToForward(this IMessageProperties messageProperties) {
			const string sagaHeader = "Saga";
			if (messageProperties?.Headers is null || !messageProperties.Headers.TryGetValue(sagaHeader, out var saga))
				return null;

			return saga is null ? null : new Dictionary<string, object> {[sagaHeader] = saga};
		}
	}
}