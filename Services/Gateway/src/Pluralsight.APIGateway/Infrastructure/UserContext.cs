namespace Pluralsight.APIGateway.Infrastructure
{
    using System.Collections.Generic;

    internal class UserContext
    {
        public string Id { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Role { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}