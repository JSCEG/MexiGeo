using MEXIGEO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEXIGEO.Servicios.Interfaces
{
    public interface IRepositorioHome
    {
        Task<List<SeccionSNIER>> ObtenerSeccionesConModulos();
        Task<List<ModuloSNIER>> ObtenerModulosPorSeccion(int seccionId);
        Task<List<SeccionSNIER>> ObtenerSeccionesConModulosPorRol(string rolUsuario);
    }
}