using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using MEXIGEO.Models;
using MEXIGEO.Servicios;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Configuration;




namespace MEXIGEO.Controllers
{
    [ServiceFilter(typeof(ValidacionInputFiltro))]
    [AutorizacionFiltro]
    public class AtlasController : Controller
    {
        private readonly IRepositorioAtlas repositorioAtlas;


        public AtlasController(IRepositorioAtlas repositorioAtlas)
        {

            this.repositorioAtlas = repositorioAtlas;
        }




        public IActionResult AZEL()
        {
            return View();
        }




    }
}
