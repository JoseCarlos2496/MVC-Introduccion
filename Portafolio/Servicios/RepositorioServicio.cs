using Portafolio.Interfaces;
using Portafolio.Models;

namespace Portafolio.Servicios
{
    public class RepositorioServicio : IRepositorioServicio
    {
        public List<ProyectoDTO> ObtenerProyectos()
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

    }
}
