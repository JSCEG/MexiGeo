using Microsoft.AspNetCore.Mvc;
using MEXIGEO.Servicios;
using System.Threading.Tasks;
using System.Data;

namespace MEXIGEO.Controllers
{
    [ServiceFilter(typeof(ValidacionInputFiltro))]
    [AutorizacionFiltro]


    public class EstacionesdeCarga : Controller
    {
        public IActionResult Electrolineras()
        {
            return View();
        }
    }

}
