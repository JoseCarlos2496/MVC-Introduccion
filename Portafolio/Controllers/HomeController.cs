using System.Diagnostics;
using Portafolio.Models;
using Microsoft.AspNetCore.Mvc;
using Portafolio.Interfaces;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioServicio _repositorioServicio;
        private readonly IServicioEmail _servicioEmail;

        public HomeController(IRepositorioServicio repositorioServicio, IServicioEmail servicioEmail)
        {
            _repositorioServicio = repositorioServicio;
            _servicioEmail = servicioEmail;
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

        public IActionResult Proyectos()
        {
            var proyectos = _repositorioServicio.ObtenerProyectos();
            return View(proyectos);
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoDTO dto)
        {
            await _servicioEmail.Enviar(dto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
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
