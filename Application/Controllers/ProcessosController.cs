using Microsoft.AspNetCore.Mvc;
using Project.Domain.Interfaces;
using Project.Domain.Entities;

namespace Application.Controllers;

public class ProcessosController : Controller
{
    private readonly IProcessoRepository _repo;
    public ProcessosController(IProcessoRepository repo) => _repo = repo;

    public async Task<IActionResult> Index()
    {
        var lista = await _repo.ListarAsync();
        return View(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string numero)
    {
        var p = new Processo { Numero = numero };
        await _repo.AdicionarAsync(p);
        return RedirectToAction(nameof(Index));
    }
}
