using Main.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

public class CustomControllerBase : ControllerBase
{
    internal ObjectResult UnauthorizedClient()
    {
        return StatusCode(StatusCodes.Status401Unauthorized,
            new ModelStateDto { Errors = new List<string> { "Not authorized" } });
    }

    internal BadRequestObjectResult BadRequest(string errorText) =>
        BadRequest(new ModelStateDto { Errors = new List<string> { errorText } });
}