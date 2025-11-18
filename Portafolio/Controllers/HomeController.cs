using System.Diagnostics;
using Portafolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioServicio _repositorioServicio;

        public HomeController(ILogger<HomeController> logger, IRepositorioServicio repositorioServicio)
        {
            _logger = logger;
            _repositorioServicio = repositorioServicio;
        }


        public IActionResult Index()
        {
            List<ProyectoDTO> proyectos = _repositorioServicio.ObtenerProyectos().Take(3).ToList();
            HomeIndexDTO modelo = new HomeIndexDTO() { Proyectos = proyectos };
            //Persona persona = new Persona()
            //{
            //    Nombre = "Jose Araujo M.",
            //    Edad = 29
            //};

            //return View("Index", persona);
            //return View(persona);
            return View(modelo);
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
}
