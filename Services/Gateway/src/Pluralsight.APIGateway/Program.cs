namespace Pluralsight.APIGateway {
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Convey;
    using Convey.Logging;
    using Convey.Metrics.AppMetrics;
    using Infrastructure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Ntrada;
    using Ntrada.Extensions.RabbitMq;
    using Ntrada.Hooks;

    public class Program {
        public static Task Main(string[] args) {
            return CreateHostBuilder(args).Build().RunAsync();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.ConfigureAppConfiguration(builder => {
                            const string extension = "yml";
                            var ntradaConfig = Environment.GetEnvironmentVariable("NTRADA_CONFIG");
                            var configPath = args?.FirstOrDefault() ?? ntradaConfig ?? $"ntrada.{extension}";

                            if (!configPath.EndsWith($".{extension}"))
                                configPath += $".{extension}";

                            builder.AddYamlFile(configPath, false);
                        }).ConfigureServices(services => services.AddNtrada()
                            .AddSingleton<IContextBuilder, CorrelationContextBuilder>()
                            .AddSingleton<ISpanContextBuilder, SpanContextBuilder>()
                            .AddSingleton<IHttpRequestHook, HttpRequestHook>()
                            .AddConvey()
                            .AddMetrics())
                        .Configure(app => app.UseNtrada())
                        .UseLogging();
                });
        }
    }
}