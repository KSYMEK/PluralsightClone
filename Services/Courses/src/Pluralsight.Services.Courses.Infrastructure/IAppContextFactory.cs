namespace Pluralsight.Services.Courses.Infrastructure
{
    using Application;

    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}