using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Commands;
using Project.Application.Queries;

namespace Project.WebApi.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductCommand request)
    {
        var response = await _mediator.Send(request);
        return StatusCode(201, response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductsAsync([FromQuery] GetAllProductsQuery request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}