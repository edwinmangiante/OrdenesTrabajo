using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DAL;
using DAL.ParametrosBusqueda;

namespace ws_ordenes
{
    public class OrdenesTrabajo : IOrdenesTrabajo
    {
        public void DoWork()
        {
        }

        #region Login

        public Usuario ObtenerUsuario(string user, string dominio, string contraseña, string appName)
        {
            try
            {
                return Usuario.ObtenerUsuario(user, dominio, contraseña, appName);
            }
            catch (Exception ex)
            {
                //logerror
                throw ex;
            }
        }

        #endregion Login

        #region Usuarios 

        public Usuario[] ObtenerUsuariosPorParametros(ParametrosBusquedaUsuarios parametros)
        {
            try
            {
                return Usuario.ObtenerPorParametros(parametros);
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }

        #endregion Usuarios
    }
}
