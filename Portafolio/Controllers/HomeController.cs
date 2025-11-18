using System.Diagnostics;
using Portafolio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<ProyectoDTO> ObtenerProyectos()
        {
            return new List<ProyectoDTO>()
            {
                new ()
                {
                    Titulo = "Proyecto 1",
                    Descripcion = "Descripcion del proyecto 1",
                    ImagenUrl = "/images/amazon.png",
                    Link = "https://www.amazon.com"
                },
                new()
                {
                    Titulo = "Proyecto 2",
                    Descripcion = "Descripcion del proyecto 2",
                    ImagenUrl = "/images/Reddit.png",
                    Link = "https://www.reddit.com"
                },
                new()
                {
                    Titulo = "Proyecto 3",
                    Descripcion = "Descripcion del proyecto 3",
                    ImagenUrl = "/images/The-New-York-Times.png",
                    Link = "https://www.nytimes.com"
                },
                new()
                {
                    Titulo = "Proyecto 4",
                    Descripcion = "Descripcion del proyecto 4",
                    ImagenUrl = "/images/Steam.png",
                    Link = "https://www.steampowered.com"
                },
            };
        }

        public IActionResult Index()
        {
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexDTO() { Proyectos = proyectos };
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
