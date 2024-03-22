using Microsoft.AspNetCore.Mvc;
using Products.API.Entities;
using Products.API.Repository;

namespace Products.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }
    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _repo.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetByID(string id)
    {
        var product = await _repo.GetByID(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }


    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] Product product)
    {
        await _repo.CreateProduct(product);
        return CreatedAtAction(nameof(GetByID), new { id = product.ID }, product);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateProduct([FromBody] Product product)
    {
        var result = await _repo.UpdateProduct(product);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteProduct([FromBody] Product product)
    {
        var result = await _repo.DeleteProduct(product);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(string id)
    {
        var result = await _repo.DeleteProduct(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
