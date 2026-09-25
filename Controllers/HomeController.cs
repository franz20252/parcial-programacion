using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using parcial_programacion.Data;
using parcial_programacion.Models;

namespace parcial_programacion.Controllers;

public class HomeController : Controller
{
    private readonly MascotaDbContext _context;

    public HomeController(MascotaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var mascotas = await _context.Mascotas
            .AsNoTracking()
            .OrderBy(mascota => mascota.Id)
            .ToListAsync();

        return View(mascotas);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarMascota(Mascota mascota)
    {
        if (!ModelState.IsValid)
        {
            var mascotas = await _context.Mascotas
                .AsNoTracking()
                .OrderBy(registro => registro.Id)
                .ToListAsync();

            return View("Index", mascotas);
        }

        _context.Mascotas.Add(mascota);
        await _context.SaveChangesAsync();
        TempData["Mensaje"] = $"{mascota.Nombre} fue registrada correctamente.";
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
