using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IProductService<Product> _productService;

    public CatalogController(IProductService<Product> productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _productService.GetProducts());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        return Ok(await _productService.GetProduct(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct()
    {
        return Ok();
    }
}