using System.Diagnostics;
using lohran_mendes_DR4_AT_S2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lohran_mendes_DR4_AT_S2.Controllers;

public class ViewNotesController : Controller
{
    private readonly ILogger<ViewNotesController> _logger;

    public ViewNotesController(ILogger<ViewNotesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}