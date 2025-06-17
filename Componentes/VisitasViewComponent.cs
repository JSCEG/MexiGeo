using Microsoft.AspNetCore.Mvc;
using MEXIGEO.Servicios;
using System.Threading.Tasks;

namespace MEXIGEO.Componentes
{
    public class VisitasViewComponent : ViewComponent
    {
        private readonly IRepositorioAcceso _repositorioAcceso;

        public VisitasViewComponent(IRepositorioAcceso repositorioAcceso)
        {
            _repositorioAcceso = repositorioAcceso;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalVisitas = _repositorioAcceso.ObtenerTotalVisitas();
            return View(totalVisitas);
        }
    }
}
