using Microsoft.AspNetCore.Mvc;
using MEXIGEO.Servicios;
using System.Threading.Tasks;
using System.Data;

namespace MEXIGEO.Controllers
{
    [ServiceFilter(typeof(ValidacionInputFiltro))]
    [AutorizacionFiltro]


    public class ErrorController : Controller
    {
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        public IActionResult ActividadSospechosa()
        {
            return View();
        }
    }

}
