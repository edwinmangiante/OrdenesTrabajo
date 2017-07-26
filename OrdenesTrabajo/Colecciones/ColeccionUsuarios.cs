using DAL;
using DAL.Login;
using DAL.ParametrosBusqueda;
using OrdenesTrabajo.ClasesUtiles;
using OrdenesTrabajo.Controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdenesTrabajo.Colecciones
{
    public class ColeccionUsuarios : ColeccionEntidades<Usuario>
    {
        internal void ObtenerPorParametros(ParametrosBusquedaUsuarios parametros)
        {
            try
            {
                //using (Controller.srvOrdenesTrabajo = new OrdenesTrabajoClient())
                DataSource = new SortableSearchableList<Usuario>(Usuario.ObtenerPorParametros(parametros).OrderBy(x => x.Apellido).ThenBy(x => x.Nombre));

                if (DataSource == null || DataSource.Count == 0)
                    Controller.MensajeInformacion("No se encontraron usuarios cargados.");
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar obtener los usuarios, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Crear(Usuario usuarioNuevo)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                /*Usuario usuario = Usuario.Crear(usuarioNuevo);
                if (usuario != null)
                {
                    DataSource.Add(usuario);
                    DataSource = new SortableSearchableList<Usuario>(DataSource.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre));
                    Current = usuario;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se creó el usuario correctamente.");
                }*/
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar crear el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }
    }
}
