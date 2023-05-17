using System.Net.Mime;
using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.Product;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : CustomControllerBase
{
    private readonly IProductService<Product> _productService;

    public CatalogController(IProductService<Product> productService)
    {
        _productService = productService;
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisplayProductDto>))]
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = (await _productService.GetProducts()).ToList();
        return Ok(products.Select(DisplayProductDto.FromEntity));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayProductDto))]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id)
    {
        return await _productService.GetProduct(id) is not { } product
            ? NotFound()
            : Ok(DisplayProductDto.FromEntity(product));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisplayProductDto>))]
    [HttpGet("search")]
    public async Task<IActionResult> SearchByKeywords([FromQuery] string? keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
            return NoContent();

        var products = await _productService.GetProducts();
        var result = products
            .Where(p => string.Concat(p.Title.ToLower()
                    .Where(c => !char.IsWhiteSpace(c)))
                .Contains(string.Concat(keyword.ToLower()
                    .Where(c => !char.IsWhiteSpace(c)))))
            .ToList();

        return Ok(result.Select(DisplayProductDto.FromEntity));
    }
}