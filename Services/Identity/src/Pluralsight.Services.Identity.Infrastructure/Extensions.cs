using System.Linq;
using Convey;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pluralsight.Services.Identity.Application.Services;
using Pluralsight.Services.Identity.Infrastructure.Contexts;

namespace Pluralsight.Services.Identity.Infrastructure {
	public static class Extensions {
		internal static CorrelationContext GetCorrelactionContext(this IHttpContextAccessor accessor) =>
			accessor.HttpContext?.Request.Headers.TryGetValue("Correlation-Context", out var json) is true
				? JsonConvert.DeserializeObject<CorrelationContext>(json.FirstOrDefault())
				: null;
	}
}