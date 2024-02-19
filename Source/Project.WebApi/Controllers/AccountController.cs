using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Commands;
using Project.Application.Queries;

namespace Project.WebApi.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateAccountAsync(CreateAccountCommand request)
    {
        var response = await _mediator.Send(request);

        if (response.Success)
            return StatusCode(201, response);
        else
            return Conflict(response);
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> AuthenticateAsync(AuthenticationQuery request)
    {
        var response = await _mediator.Send(request);

        if (response.Sucess)
            return Ok(response);
        else
            return BadRequest(response); // Invalid credentials.
    }
}