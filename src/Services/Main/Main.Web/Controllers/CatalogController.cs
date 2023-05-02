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

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var product = Mapper.Map<Product>(productDto);

        if (await _productService.CreateProduct(product) is not { } result)
            throw new Exception("Product is not created");

        return Ok(Mapper.Map<DisplayProductDto>(result));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        product = Mapper.Map(productDto, product);
        var result = await _productService.UpdateProduct(product);

        return Ok(Mapper.Map<DisplayProductDto>(result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        if (await _productService.GetProduct(id) is not { } product)
            return BadRequest();

        await _productService.DeleteProduct(product);
        return Ok();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> BlockUnblockProduct([FromRoute] Guid id,
        [FromBody] BlockUnblockProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequest();

        product = Mapper.Map(productDto, product);

        var result = await _productService.UpdateProduct(product);
        return Ok(Mapper.Map<DisplayProductDto>(result));
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