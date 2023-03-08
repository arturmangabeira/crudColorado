using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webApp.Models;
using webApp.Services.Interfaces;

namespace webApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IClienteService _service;

    public HomeController(ILogger<HomeController> logger, IClienteService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [Route("Home/obter-todos")]
    public async Task<IActionResult> ObterTodos()
    {
        var clientes = await _service.ObterTodos();
        return Json(clientes);
    }

    [Route("Home/obter-cliente-por-filtro")]
    public async Task<IActionResult> ObterTodos(string nome)
    {
        var clientes = await _service.ObterClientePorFiltro(nome);
        return Json(clientes);
    }

    public async Task<IActionResult> Index()
    {
        var clientes = await _service.ObterTodos();        
        return View(clientes);        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Cadastrar()
    {
        return View();
    }

    [Route("Home/Editar/{CodCliente}")]
    public IActionResult Editar(int CodCliente)
    {
        ViewData["codCliente"] = CodCliente;
        return View();
    }

    [Route("Home/Visualizar/{CodCliente}")]
    public IActionResult Visualizar(int CodCliente)
    {
        ViewData["codCliente"] = CodCliente;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
