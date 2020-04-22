namespace Pluralsight.Services.Identity.Infrastructure
{
    using Application;

    public interface IAppContextFactory
    {
        IAppContext Create();
    }
}