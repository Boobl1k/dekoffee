using System.Net.Mime;
using Main.Application.Interfaces.Services;
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
    private readonly ISearchService _searchService;

    public CatalogController(IProductService<Product> productService, ISearchService searchService)
    {
        _productService = productService;
        _searchService = searchService;
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

        var result = _searchService
            .CreateSearchBuilder(await _productService.GetProducts(), keyword)
            .InTitle()
            .InCountry()
            .InDescription()
            .SearchProducts();

        return Ok(result.Select(DisplayProductDto.FromEntity));
    }
}