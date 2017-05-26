namespace AuthTokens.Extensions
{
    using AuthTokens.JWT;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public static class TokenProviderAppBuilderExtension
    {
        public static IApplicationBuilder UseTokenProvider(this IApplicationBuilder app, SecurityKey signingKey)
        {
            var options = new TokenProviderOptions
            {
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            return app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
