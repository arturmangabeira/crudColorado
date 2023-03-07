using Microsoft.AspNetCore.Mvc;
using application;
using System;
using System.Collections.Generic;
using application.interfaces;
using application.models;

namespace webApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ILogger<ClienteController> _logger;
    private readonly IClienteAppService _clienteAppService;       
    public ClienteController(ILogger<ClienteController> logger,
                            IClienteAppService clienteAppService)
    {
        _logger = logger;
        _clienteAppService = clienteAppService;
    }

    [HttpGet]
    [Route("obter-cliente-por-filtro")]
    public IActionResult ObterClientePorFiltro(string nome)
    {
        var result = _clienteAppService.ObterClientePorFiltro(nome);

        return Ok(result);
    }

    [HttpGet]
    [Route("obter-todos-cliente")]
    public IActionResult ObterTodosCliente()
    {
        var result = _clienteAppService.ObterTodosCliente();

        return Ok(result);
    }

    [HttpGet]
    [Route("obter-cliente-por-codigo-cliente")]
    public IActionResult ObterClientePorCodigoCliente(int CodigoCliente)
    {
        var result = _clienteAppService.ObterClientePorCodigoCliente(CodigoCliente);

        return Ok(result);
    }

    [HttpPost]
    [Route("inserir-cliente")]
    public IActionResult InserirCliente(ClienteModel clienteModel)
    {
        var result = _clienteAppService.InserirCliente(clienteModel);

        return Ok(result);
    }

    [HttpPut]
    [Route("atualizar-cliente")]
    public IActionResult AtualizarCliente(ClienteModel clienteModel)
    {
        var result = _clienteAppService.AtualizarCliente(clienteModel);

        return Ok(result);
    }

    [HttpDelete]
    [Route("excluir-cliente")]
    public IActionResult ExcluirCliente(int codigoCliente)
    {
        var result = _clienteAppService.ExcluirCliente(codigoCliente);

        return Ok(result);
    }
}
