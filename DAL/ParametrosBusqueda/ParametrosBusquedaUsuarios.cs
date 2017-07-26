using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ParametrosBusqueda
{
    public class ParametrosBusquedaUsuarios
    {
        public string User { get; set; }
        public string Dominio { get; set; }
        public string NomApe { get; set; }
        public int? CodigoPerfil { get; set; }
        public string NombreApp { get; set; }
        public int? IncluirBajas { get; set; }

        public ParametrosBusquedaUsuarios()
        {
        }
    }
}
