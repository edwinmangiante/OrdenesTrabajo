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
            {
                Usuario usuario = Usuario.Crear(usuarioNuevo);
                if (usuario != null)
                {
                    DataSource.Add(usuario);
                    DataSource = new SortableSearchableList<Usuario>(DataSource.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre));
                    Current = usuario;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se creó el usuario correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar crear el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Editar(Usuario usuarioEditar)
        {
            try
            {
                Usuario usuario = Usuario.Editar(usuarioEditar);
                if (usuario != null)
                {
                    /*DataSource.Add(usuario);
                    DataSource = new SortableSearchableList<Usuario>(DataSource.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre));
                    Current = usuario;*/
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se editó el usuario correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar editar el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Eliminar(Usuario usuarioEliminar)
        {
            try
            {
                Usuario.Eliminar(usuarioEliminar);
                DataSource.Remove(usuarioEliminar);
                DataSource = new SortableSearchableList<Usuario>(DataSource.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre));
                RaisePropertyChanged("DataSource");
                RaisePropertyChanged("Current");
                Controller.MensajeInformacion("Se eliminó el usuario correctamente.");
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar eliminar el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Baja(Usuario usuarioBaja)
        {
            try
            {
                usuarioBaja.FechaBaja = DateTime.Now;
                Usuario.Editar(usuarioBaja);
                RaisePropertyChanged("DataSource");
                RaisePropertyChanged("Current");
                Controller.MensajeInformacion("Se dió de baja el usuario correctamente.");
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar eliminar el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Alta(Usuario usuarioAlta)
        {
            try
            {
                usuarioAlta.FechaBaja = null;
                Usuario.Editar(usuarioAlta);
                RaisePropertyChanged("DataSource");
                RaisePropertyChanged("Current");
                Controller.MensajeInformacion("Se dió de baja el usuario correctamente.");
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar eliminar el usuario, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }
    }
}
