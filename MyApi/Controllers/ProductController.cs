using Microsoft.AspNetCore.Mvc;
using MyApi;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly List<Product> _products = new List<Product>(); // Replace this with a database connection

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_products);
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        // Add validation logic if necessary
        _products.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

}
