namespace Pluralsight.Services.Identity.Application.Services
{
    public interface IRng
    {
        string Generate(int lenght = 50, bool removeSpecialChars = false);
    }
}