namespace Pluralsight.Services.Courses.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application;
    using Application.Commands;
    using Application.DTO;
    using Application.Queries;
    using Convey;
    using Convey.Logging;
    using Convey.Secrets.Vault;
    using Convey.Types;
    using Convey.WebApi;
    using Convey.WebApi.CQRS;
    using Infrastructure;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddWebApi()
                    .AddApplication()
                    .AddInfrastructure()
                    .Build())
                .Configure(app => app
                    .UseInfrastructure()
                    .UseDispatcherEndpoints(endpoints => endpoints
                        .Get("", ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
                        .Get<GetCourses, IEnumerable<CourseDto>>("courses")
                        .Get<GetCourse, CourseDto>("courses/{courseId}")
                        .Get<GetCourseModule, CourseModuleDto>("courses/modules/{courseModuleId}")
                        .Get<GetCourseModules, IEnumerable<CourseModuleDto>>("courses/{courseId}/modules")
                        .Post<AddCourse>("courses", afterDispatch: (cmd, ctx) => ctx.Response.Created($"courses/{cmd.CourseId}"))
                    ))
                .UseLogging()
                .UseVault()
                .Build()
                .RunAsync();
        }
    }
}