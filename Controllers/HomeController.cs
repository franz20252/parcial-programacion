using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using parcial_programacion.Models;

namespace parcial_programacion.Controllers;

public class HomeController : Controller
{
    private static readonly List<Mascota> Mascotas = new();

    public IActionResult Index()
    {
        return View(Mascotas);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RegistrarMascota(Mascota mascota)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", Mascotas);
        }

        Mascotas.Add(mascota);
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
