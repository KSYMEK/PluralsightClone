using System;
using System.Linq;
using System.Security.Cryptography;
using Pluralsight.Services.Identity.Application.Services;

namespace Pluralsight.Services.Identity.Infrastructure.Auth {
	
	internal sealed class Rng : IRng {
		private static readonly string[] SpecialChars = new[] {"/", "\\", "=", "+", "?", ":", "&"};
		
		public string Generate(int lenght = 50, bool removeSpecialChars = false) {
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