using Microsoft.AspNetCore.Authorization;
using OpenIddict.Validation.AspNetCore;

namespace Main;

public class OpenIdDictAuthorize : AuthorizeAttribute
{
    public OpenIdDictAuthorize() =>
        AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
}