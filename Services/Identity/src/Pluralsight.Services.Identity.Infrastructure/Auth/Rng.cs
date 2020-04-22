namespace Pluralsight.Services.Identity.Infrastructure.Auth
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using Application.Services;

    internal sealed class Rng : IRng
    {
        private static readonly string[] SpecialChars = {"/", "\\", "=", "+", "?", ":", "&"};

        public string Generate(int lenght = 50, bool removeSpecialChars = false)
        {
            using var rng = new RNGCryptoServiceProvider();
            var bytes = new byte[lenght];
            rng.GetBytes(bytes);
            var result = Convert.ToBase64String(bytes);

            return removeSpecialChars
                ? SpecialChars.Aggregate(result, (current, chars) => current.Replace(chars, string.Empty))
                : result;
        }
    }
}