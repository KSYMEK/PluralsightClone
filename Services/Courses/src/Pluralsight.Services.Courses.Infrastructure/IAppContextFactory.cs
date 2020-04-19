using Pluralsight.Services.Courses.Application;

namespace Pluralsight.Services.Courses.Infrastructure
{
    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}