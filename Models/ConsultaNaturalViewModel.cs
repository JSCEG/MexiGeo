using System.Data;

namespace MEXIGEO.Models
{
    public class ConsultaNaturalViewModel
    {
        public string Pregunta { get; set; }
        public string ConsultaSQL { get; set; }
        public DataTable Resultados { get; set; }
    }
}

