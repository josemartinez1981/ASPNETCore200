namespace AuthTokens.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.IdentityModel.Tokens;
    using System;

    public static class TokenAuthenticationAppBuilderExtension
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder app, SecurityKey signingKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = "ExampleIssuer",

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = "ExampleAudience",

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            return app.UseJwtBearerAuthentication(
                new JwtBearerOptions
                    {
                        AutomaticAuthenticate = true,
                        AutomaticChallenge = true,
                        TokenValidationParameters = tokenValidationParameters
                    });
        }
    }
}
