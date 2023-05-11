using Main.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

public class CustomControllerBase : ControllerBase
{
    internal ObjectResult UnauthorizedClient()
    {
        return StatusCode(StatusCodes.Status401Unauthorized,
            new ModelStateDto { Errors = { "Not authorized" } });
    }

    internal BadRequestObjectResult BadRequest(string errorText) =>
        BadRequest(new ModelStateDto { Errors = { errorText } });
}