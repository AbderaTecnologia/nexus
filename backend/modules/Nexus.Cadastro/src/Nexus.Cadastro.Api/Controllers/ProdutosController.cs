using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Application.Produtos.Queries;

namespace Nexus.Cadastro.Api.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Produtos([FromQuery] ProdutosQuery query)
    {
        var produtos = await _mediator.Send(query);
        return Ok(produtos);
    }
}