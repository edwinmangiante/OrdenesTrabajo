using DAL;
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
    public class ColeccionOrdenes : ColeccionEntidades<OrdenTrabajo>
    {
        internal void ObtenerPorParametros(ParametrosBusquedaOrdenes parametros)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                DataSource = new SortableSearchableList<OrdenTrabajo>(OrdenTrabajo.ObtenerTodos(parametros).OrderBy(x => x.Codigo).ThenBy(x => x.CodigoInterno));
                //ver si conviene traer todos y usar linq para filtrar la busqueda
                if (DataSource == null || DataSource.Count == 0)
                    Controller.MensajeInformacion("No se encontraron Ordenes de Trabajo.");
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar obtener las ordenes de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Crear(OrdenTrabajo ordenNueva)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo orden = OrdenTrabajo.Crear(ordenNueva);
                if (orden != null)
                {
                    DataSource.Add(orden);
                    DataSource = new SortableSearchableList<OrdenTrabajo>(DataSource.OrderBy(x => x.Codigo).ThenBy(x => x.CodigoInterno));
                    Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se creó la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar crear la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Editar(OrdenTrabajo ordenEditada)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo orden = OrdenTrabajo.Editar(ordenEditada);
                if (orden != null)
                {
                    //DataSource.Add(orden);
                    DataSource = new SortableSearchableList<OrdenTrabajo>(DataSource.OrderBy(x => x.Codigo).ThenBy(x => x.CodigoInterno));
                    Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se editó la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar editar la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Eliminar(OrdenTrabajo orden)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo.Eliminar(orden);
                if (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(orden);
                    //Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se eliminó la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar eliminar la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Baja(OrdenTrabajo orden)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo.Baja(orden);
                if (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(orden);
                    //Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se dió de baja la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar dar de baja la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Alta(OrdenTrabajo orden)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo.Alta(orden);
                if (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(orden);
                    //Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se dió de alta la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar dar de alta la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }

        internal void Cierre(OrdenTrabajo orden)
        {
            try
            {//si hubiera un ws, los try catch estarían en la parcial que llamaría a los métodos!!
                OrdenTrabajo.Cierre(orden);
                if (DataSource != null && DataSource.Count > 0)
                {
                    DataSource.Remove(orden);
                    //Current = orden;
                    RaisePropertyChanged("DataSource");
                    RaisePropertyChanged("Current");
                    Controller.MensajeInformacion("Se cerró la orden de trabajo correctamente.");
                }
            }
            catch (Exception ex)
            {
                Controller.MensajeError("Ocurrió un error al intentar cerrar la orden de trabajo, " +
                    "intente nuevamente y si el error persiste comuniquese con Sistemas. (" + ex.Message + ").");
            }
        }
    }
}
