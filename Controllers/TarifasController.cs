using Microsoft.AspNetCore.Mvc;
using MEXIGEO.Models;
using MEXIGEO.Servicios;

namespace MEXIGEO.Controllers
{
    [ServiceFilter(typeof(ValidacionInputFiltro))]

    [AutorizacionFiltro]
    public class TarifasController : Controller
    {
        private readonly IRepositorioTarifas repositorioTarifas;
        public TarifasController(IRepositorioTarifas repositorioTarifas)
        {

            this.repositorioTarifas = repositorioTarifas;
        }
        public async Task<IActionResult> TarifasMI()
        {
            var tarifas = await repositorioTarifas.ObtenerTarifasAsync();
            return View(tarifas); // Pasa los datos a la vista
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTarifasPorMesAnioYDivision(string mesAnio, string division)
        {
            var tarifas = await repositorioTarifas.ObtenerTarifasPorMesAnioYDivisionAsync(mesAnio, division);
            return Json(tarifas);
        }

    }
}
