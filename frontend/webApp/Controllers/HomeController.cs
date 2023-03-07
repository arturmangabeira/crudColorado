using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webApp.Models;

namespace webApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
