using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
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
        return Ok((await _productService.GetProducts()).ToList());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct([FromQuery] Guid id)
    {
        return await _productService.GetProduct(id) is not { } product
            ? BadRequestInvalidObject(nameof(Product))
            : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var product = new Product
        {
            Title = productDto.Title,
            Price = productDto.Price,
            Description = productDto.Description,
            Net = productDto.Net,
            Gross = productDto.Gross,
            Country = productDto.Country,
            EnergyValue = productDto.EnergyValue,
            IsBlocked = productDto.IsBlocked
        };
        if (await _productService.CreateProduct(product) is not { } result)
            throw new Exception("Product is not created");

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct([FromQuery] Guid id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        product.Title = productDto.Title;
        product.Price = productDto.Price;
        product.Description = productDto.Description;
        product.Net = productDto.Net;
        product.Gross = productDto.Gross;
        product.Country = productDto.Country;
        product.EnergyValue = productDto.EnergyValue;
        product.IsBlocked = productDto.IsBlocked;

        var result = await _productService.UpdateProduct(product);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromQuery] Guid id)
    {
        if (await _productService.GetProduct(id) is not { } product)
            return BadRequest();

        await _productService.DeleteProduct(product);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> BlockUnblockProduct([FromQuery] Guid id,
        [FromBody] BlockUnblockProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequest();

        product.IsBlocked = productDto.IsBlocked;
        var result = await _productService.UpdateProduct(product);
        return Ok(result);
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchByKeywords(string? keyword)
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

        return Ok(result);
    }
}