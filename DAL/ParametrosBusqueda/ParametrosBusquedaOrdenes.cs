using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ParametrosBusqueda
{
    public class ParametrosBusquedaOrdenes
    {
        public Int32? Codigo { get; set; }
        public String Descripcion { get; set; }
        public String Direccion { get; set; }
        public String Solicitante { get; set; }
        public String Tipo { get; set; }
        public String Usuario { get; set; }
        public Int32? IncluirBajas { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public ParametrosBusquedaOrdenes()
        {

        }
    }
}
