using Main.Application.Interfaces;
using Main.Application.Models;
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

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = (await _productService.GetProducts()).ToList();
        return Ok(Mapper.Map<List<Product>, List<DisplayProductDto>>(products));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id)
    {
        return await _productService.GetProduct(id) is not { } product
            ? BadRequestInvalidObject(nameof(Product))
            : Ok(Mapper.Map<DisplayProductDto>(product));
    }

    [HttpGet("Search")]
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

        return Ok(Mapper.Map<List<Product>, List<DisplayProductDto>>(result));
    }
}