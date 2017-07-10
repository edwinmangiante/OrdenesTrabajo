using DAL.ParametrosBusqueda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrdenTrabajo : ICloneable
    {
        #region Propiedades

        public Int32 CodigoInterno { get; set; }
        public Int32 Codigo { get; set; }
        public String Descripcion { get; set; }
        public String Observaciones { get; set; }
        public String Direccion { get; set; } //Por ahora queda acá porque es de la orden, se puede mover al solicitante
        public String Solicitante { get; set; } //Debería haber una clase con estos datos si es que los tenemos 1 a 1
        public String Tipo { get; set; } //Debería haber una clase con los tipos! 1 a 1 o ver si 1 orden puede ser de vrs tipos
        public List<String> Detalle { get; set; } //Debería haber una clase DetalleOrden con datos particulares de c/trab en particular (no debería quedar vacía). 1 a *
        public DateTime FechaLG { get; set; }
        public DateTime? FechaCierre { get; set; }
        public String Usuario { get; set; } //Clase usuario con los datos del usr loggueado que agregó.
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        #endregion Propiedades

        #region Constructores

        public OrdenTrabajo()
        {

        }

        //ver si conviene mapear todo acá!!
        internal OrdenTrabajo(OrdenTrabajo orden)
        {

        }

        #endregion Constructores

        #region Métodos Públicos 
        //ver si conviene hacer métodos estáticos o instanciar la clase para acceder a los métodos!

        /// <summary>
        /// Obtiene una OrdenTrabajo por su clave Primaria.
        /// </summary>
        /// <param name="ord">La OrdenTrajo con solo con la Pk seteada.</param>
        /// <returns>OrdenTrabajo.</returns>
        public static OrdenTrabajo ObtenerPorPK(OrdenTrabajo ord)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(""))
                    return ObtenerPorPK(ord, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <returns></returns>
        public static List<OrdenTrabajo> ObtenerTodos(ParametrosBusquedaOrdenes parametros)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(""))
                    return ObtenerTodos(parametros, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documetar
        /// </summary>
        /// <param name="ordACrear"></param>
        /// <returns></returns>
        public static OrdenTrabajo Crear(OrdenTrabajo ordACrear)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(""))
                    return Crear(ordACrear, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <param name="ordAEditar"></param>
        /// <returns></returns>
        public static OrdenTrabajo Editar(OrdenTrabajo ordAEditar)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(""))
                    return Editar(ordAEditar, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <param name="ordAEliminar"></param>
        public static void Eliminar(OrdenTrabajo ordAEliminar)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(""))
                    Eliminar(ordAEliminar, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <param name="ordABaja"></param>
        public static void Baja(OrdenTrabajo ordABaja)
        {
            try
            {
                ordABaja.FechaBaja = DateTime.Now;
                using (SqlConnection connection = new SqlConnection(""))
                    Editar(ordABaja, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <param name="ordAAlta"></param>
        public static void Alta(OrdenTrabajo ordAAlta)
        {
            try
            {
                ordAAlta.FechaBaja = null;
                using (SqlConnection connection = new SqlConnection(""))
                    Editar(ordAAlta, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        /// <summary>
        /// documentar
        /// </summary>
        /// <param name="ord"></param>
        public static void Cierre(OrdenTrabajo ord)
        {
            try
            {
                ord.FechaCierre = DateTime.Now;
                using (SqlConnection connection = new SqlConnection(""))
                    Editar(ord, connection);
            }
            catch (Exception ex)
            {
                //si hubiera ws ahí tendría que haber otro try catch y ahí loguear el error!
                string hostName = Dns.GetHostName();
                string ipAddress = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                LogError.CreateLog(ex, System.Reflection.MethodBase.GetCurrentMethod().Name, "", ipAddress);
                throw ex;
            }
        }

        public static DateTime GetDateTime()
        {
            //este método es para asegurarnos que no nos modifiquen la fecha de la PC, debería estar en el ws, que,
            //una vez instalado en el servidor, devolvería la fecha del servidor. Si no hay ws, hay que hacer una consulta 
            //por un sp a la base de datos, porque esto hecho así no tiene ningún sentido.
            return DateTime.Now;
        }

        #endregion Métodos Públicos

        #region Métodos Internos y Privados

        private static OrdenTrabajo ObtenerPorPK(OrdenTrabajo ord, SqlConnection connection)
        {
            OrdenTrabajo orden = null;

            return orden;
        }

        private static List<OrdenTrabajo> ObtenerTodos(ParametrosBusquedaOrdenes parametros, SqlConnection connection)
        {
            List<OrdenTrabajo> ordenes = null;
            if (connection.State != ConnectionState.Open)
                connection.Open();

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                AddSearchParameters(cmd, parametros, "SELECT");
                //AddParameters(cmd, ord, "SELECT");

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ordenes = new List<OrdenTrabajo>();
                    while (reader.Read())
                    {
                        OrdenTrabajo orden = new OrdenTrabajo();

                        ordenes.Add(orden);
                    }
                }
            }

            return ordenes;
        }

        private static OrdenTrabajo Crear(OrdenTrabajo ordACrear, SqlConnection connection)
        {
            //crear con el obj ordACrear
            OrdenTrabajo ordNueva = new OrdenTrabajo();
            ordNueva.CodigoInterno = 0; //cdo hacemos el executenonquery obtenemos este codigo!
            ordNueva.Codigo = ordACrear.CodigoInterno;

            return ObtenerPorPK(ordNueva);
        }

        private static OrdenTrabajo Editar(OrdenTrabajo ordAEditar, SqlConnection connection)
        {
            //editar con el obj ordAEditar
            OrdenTrabajo ordEditada = new OrdenTrabajo();
            ordEditada.CodigoInterno = ordAEditar.CodigoInterno; //cdo hacemos el executenonquery obtenemos este codigo!
            ordEditada.Codigo = ordAEditar.Codigo;

            return ObtenerPorPK(ordEditada);
        }

        private static void Eliminar(OrdenTrabajo ordAEliminar, SqlConnection connection)
        {
            //eliminar con el obj ordAEliminar
        }

        /* por ahora uso el Editar
        private static void Baja(OrdenTrabajo ordABaja, SqlConnection connection)
        {
            //eliminar con el obj ordAEliminar
        }

        private static void Alta(OrdenTrabajo ordAAlta, SqlConnection connection)
        {
            //eliminar con el obj ordAEliminar
        }
        */

        private static void AddSearchParameters(SqlCommand cmd, ParametrosBusquedaOrdenes parametros, string accion)
        {
            SqlParameter paCodigoInterno = cmd.Parameters.Add("@ord_id", SqlDbType.Int);
            SqlParameter paCodigo = cmd.Parameters.Add("@ord_codigo", SqlDbType.Int);
            SqlParameter paDescripcion = cmd.Parameters.Add("@ord_descripcion", SqlDbType.VarChar, 300);
            SqlParameter paObservacion = cmd.Parameters.Add("@ord_observacion", SqlDbType.VarChar, -1);
            SqlParameter paDireccion = cmd.Parameters.Add("@ord_direccion", SqlDbType.VarChar, 150);
            SqlParameter paSolicitante = cmd.Parameters.Add("@ord_solicitante", SqlDbType.VarChar, 100);
            SqlParameter paTipo = cmd.Parameters.Add("@ord_tipo", SqlDbType.VarChar, 100);
            SqlParameter paUsuario = cmd.Parameters.Add("@ord_usuario", SqlDbType.VarChar, 100);
            SqlParameter paFechaLG = cmd.Parameters.Add("@ord_fecha_lg", SqlDbType.Date);
            SqlParameter paFechaCierre = cmd.Parameters.Add("@ord_fecha_cierre", SqlDbType.DateTime);
            SqlParameter paFechaAlta = cmd.Parameters.Add("@ord_fecha_alta", SqlDbType.DateTime);
            SqlParameter paFechaBaja = cmd.Parameters.Add("@ord_fecha_baja", SqlDbType.DateTime);
            SqlParameter paAccion = cmd.Parameters.Add("@accion", SqlDbType.VarChar, 20);
            SqlParameter paFechaDesde = cmd.Parameters.Add("@ord_fecha_desde", SqlDbType.DateTime);
            SqlParameter paFechaHasta = cmd.Parameters.Add("@ord_fecha_hasta", SqlDbType.DateTime);
            SqlParameter paIncluirBajas = cmd.Parameters.Add("@incluir_bajas", SqlDbType.Int);

            paCodigoInterno.Value = 0;
            if (parametros.Codigo.HasValue)
                paCodigo.Value = parametros.Codigo.Value;
            else
                paCodigo.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(parametros.Descripcion))
                paDescripcion.Value = parametros.Descripcion;
            else
                paDescripcion.Value = DBNull.Value;
            paObservacion.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(parametros.Direccion))
                paDireccion.Value = parametros.Direccion;
            else
                paDireccion.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(parametros.Solicitante))
                paSolicitante.Value = parametros.Solicitante;
            else
                paSolicitante.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(parametros.Tipo))
                paTipo.Value = parametros.Tipo;
            else
                paTipo.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(parametros.Usuario))
                paUsuario.Value = parametros.Usuario;
            else
                paUsuario.Value = DBNull.Value;
            paFechaLG.Value = DBNull.Value;
            paFechaCierre.Value = DBNull.Value;
            paFechaAlta.Value = DBNull.Value;
            paFechaBaja.Value = DBNull.Value;

            paAccion.Value = accion;
            if (parametros.FechaDesde.HasValue)
                paFechaDesde.Value = parametros.FechaDesde.Value;
            else
                paFechaDesde.Value = DBNull.Value;
            if (parametros.FechaHasta.HasValue)
                paFechaHasta.Value = parametros.FechaHasta.Value;
            else
                paFechaHasta.Value = DBNull.Value;
            if (parametros.IncluirBajas.HasValue)
                paIncluirBajas.Value = parametros.IncluirBajas.Value;
            else
                paIncluirBajas.Value = DBNull.Value;
        }

        private static void AddParameters(SqlCommand cmd, OrdenTrabajo orden, string accion)
        {
            SqlParameter paCodigoInterno = cmd.Parameters.Add("@ord_id", SqlDbType.Int);
            SqlParameter paCodigo = cmd.Parameters.Add("@ord_codigo", SqlDbType.Int);
            SqlParameter paDescripcion = cmd.Parameters.Add("@ord_descripcion", SqlDbType.VarChar, 300);
            SqlParameter paObservacion = cmd.Parameters.Add("@ord_observacion", SqlDbType.VarChar, -1);
            SqlParameter paDireccion = cmd.Parameters.Add("@ord_direccion", SqlDbType.VarChar, 150);
            SqlParameter paSolicitante = cmd.Parameters.Add("@ord_solicitante", SqlDbType.VarChar, 100);
            SqlParameter paTipo = cmd.Parameters.Add("@ord_tipo", SqlDbType.VarChar, 100);
            SqlParameter paUsuario = cmd.Parameters.Add("@ord_usuario", SqlDbType.VarChar, 100);
            SqlParameter paFechaLG = cmd.Parameters.Add("@ord_fecha_lg", SqlDbType.Date);
            SqlParameter paFechaCierre = cmd.Parameters.Add("@ord_fecha_cierre", SqlDbType.DateTime);
            SqlParameter paFechaAlta = cmd.Parameters.Add("@ord_fecha_alta", SqlDbType.DateTime);
            SqlParameter paFechaBaja = cmd.Parameters.Add("@ord_fecha_baja", SqlDbType.DateTime);
            SqlParameter paAccion = cmd.Parameters.Add("@accion", SqlDbType.VarChar, 20);
            SqlParameter paFechaDesde = cmd.Parameters.Add("@ord_fecha_desde", SqlDbType.DateTime);
            SqlParameter paFechaHasta = cmd.Parameters.Add("@ord_fecha_hasta", SqlDbType.DateTime);
            SqlParameter paIncluirBajas = cmd.Parameters.Add("@incluir_bajas", SqlDbType.Int);

            paCodigoInterno.Value = 0;
            paCodigo.Value = orden.Codigo;
            if (!string.IsNullOrWhiteSpace(orden.Descripcion))
                paDescripcion.Value = orden.Descripcion;
            else
                paDescripcion.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(orden.Observaciones))
                paObservacion.Value = orden.Observaciones;
            else
                paObservacion.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(orden.Direccion))
                paDireccion.Value = orden.Direccion;
            else
                paDireccion.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(orden.Solicitante))
                paSolicitante.Value = orden.Solicitante;
            else
                paSolicitante.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(orden.Tipo))
                paTipo.Value = orden.Tipo;
            else
                paTipo.Value = DBNull.Value;
            if (!string.IsNullOrWhiteSpace(orden.Usuario))
                paUsuario.Value = orden.Usuario;
            else
                paUsuario.Value = DBNull.Value;
            paFechaLG.Value = orden.FechaLG;
            if (orden.FechaCierre.HasValue)
                paFechaCierre.Value = orden.FechaCierre.Value;
            else
                paFechaCierre.Value = DBNull.Value;
            paFechaAlta.Value = orden.FechaAlta;
            if (orden.FechaBaja.HasValue)
                paFechaBaja.Value = orden.FechaBaja.Value;
            else
                paFechaBaja.Value = DBNull.Value;

            paAccion.Value = accion;
            paFechaDesde.Value = DBNull.Value;
            paFechaHasta.Value = DBNull.Value;
            paIncluirBajas.Value = DBNull.Value;
        }

        #endregion Métodos Internos y Privados

        #region Equals, Hash y ToString

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            OrdenTrabajo ord = obj as OrdenTrabajo;
            if (ord == null)
                return false;
            else
            {
                if (ord.CodigoInterno == this.CodigoInterno &&
                    ord.Codigo == this.Codigo)
                    return true;
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return this.CodigoInterno.GetHashCode() ^
                    this.Codigo.GetHashCode();
        }

        public static bool operator ==(OrdenTrabajo ordA, OrdenTrabajo ordB)
        {
            if (object.ReferenceEquals(ordA, ordB))
                return true;

            if ((object)ordA == null || (object)ordB == null)
                return false;

            return ordA.Equals(ordB);
        }

        public static bool operator !=(OrdenTrabajo ordA, OrdenTrabajo ordB)
        {
            return !(ordA == ordB);
        }

        public override string ToString()
        {
            return Codigo + " - " + Descripcion;
        }

        #endregion Equals, Hash y ToString

        #region Clonable
        //la hacemos iclonable porque no hay webservices, sino la parcial es la que tiene que ser iclonable!
        public OrdenTrabajo Clone()
        {
            return (OrdenTrabajo)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion Clonable
    }
}
