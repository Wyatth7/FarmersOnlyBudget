using System.Security.Claims;
using System.Text.Encodings.Web;
using FarmersOnlyBudget.Api.Services;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace FarmersOnlyBudget.Api.Security.Authentication;

public class FirebaseAuthSchemeHandler : AuthenticationHandler<FirebaseAuthSchemeOptions>
{ 
    public FirebaseAuthSchemeHandler(IOptionsMonitor<FirebaseAuthSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authHeaderPresent = Request.Headers.TryGetValue("authorization", out var bearer);
        var authInfoService = Context.RequestServices.GetService<IAuthenticatedUserService>()!;

        try
        {
            var token = bearer[0]?.Split("Bearer ")[1];
        
            if (!authHeaderPresent || string.IsNullOrEmpty(token))
                return Fail();

            var firebaseToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);

            if (firebaseToken is null || !await authInfoService.Exists(firebaseToken.Uid)) return Fail();

            await authInfoService.Init(firebaseToken);
            return AuthenticateResult.Success(CreateTicket());
        }
        catch (Exception e)
        {
            return Fail();
        }
        
    }

    private AuthenticationTicket CreateTicket()
    {
        var claims = new[] { new Claim(ClaimTypes.Name, "test") };
        var principle = new ClaimsPrincipal(new ClaimsIdentity(claims, "Tokens"));
        return new AuthenticationTicket(principle, Scheme.Name);
    }

    private static AuthenticateResult Fail()
    {
        return AuthenticateResult.Fail("You do not have access to this resource.");
    }
}