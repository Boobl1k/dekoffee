using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace Main.Controllers;

public class CustomControllerBase : ControllerBase
{
    internal ForbidResult ForbidUnauthorizedClient() =>
        Forbid(new AuthenticationProperties(new Dictionary<string, string?>
        {
            [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.UnauthorizedClient,
            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                "Not authorized"
        }), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    internal BadRequestObjectResult BadRequestInvalidObject(string typeName) =>
        BadRequest($"Invalid {typeName}");
}