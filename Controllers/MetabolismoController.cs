using Microsoft.AspNetCore.Mvc;
using MEXIGEO.Models;
using MEXIGEO.Servicios;

namespace MEXIGEO.Controllers
{
    [ServiceFilter(typeof(ValidacionInputFiltro))]
    [AutorizacionFiltro]
    public class Metabolismo : Controller
    {
        public IActionResult TasadeConsumoMetabolico()
        {
            return View();
        }
    }
}