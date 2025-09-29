using System.Diagnostics;
using lohran_mendes_DR4_AT_S2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using lohran_mendes_DR4_AT_S2.Views.ViewNotes;

namespace lohran_mendes_DR4_AT_S2.Controllers;

public class ViewNotesController : Controller
{
    private readonly ILogger<ViewNotesController> _logger;
    private readonly string _filePath;

    public ViewNotesController(ILogger<ViewNotesController> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _filePath = Path.Combine(env.WebRootPath, "files", "anotacoes.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new ViewNotesModel();
        if (System.IO.File.Exists(_filePath))
        {
            var lines = System.IO.File.ReadAllLines(_filePath, Encoding.UTF8);
            foreach (var line in lines)
            {
                var parts = line.Split("|:|", StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    model.Anotacoes.Add(new AnotacaoModel { Titulo = parts[0], Descricao = parts[1] });
                }
            }
        }
        return View((object)model);
    }

    [HttpPost]
    public IActionResult Index(ViewNotesModel model)
    {
        if (ModelState.IsValid)
        {
            var anotacao = model.Anotacao;
            var line = anotacao.Titulo + "|:|" + anotacao.Descricao;
            System.IO.File.AppendAllText(_filePath, line + "\n", Encoding.UTF8);
            return RedirectToAction("Index");
        }
        // Recarregar anotações existentes para exibir na view
        if (System.IO.File.Exists(_filePath))
        {
            var lines = System.IO.File.ReadAllLines(_filePath, Encoding.UTF8);
            foreach (var line in lines)
            {
                var parts = line.Split("|:|", StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    model.Anotacoes.Add(new AnotacaoModel { Titulo = parts[0], Descricao = parts[1] });
                }
            }
        }
        return View((object)model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}