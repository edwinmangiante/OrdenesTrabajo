using DAL;
using DAL.ParametrosBusqueda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ws_ordenes
{
    [ServiceContract]
    public interface IOrdenesTrabajo
    {
        [OperationContract]
        void DoWork();

        #region Login

        [OperationContract]
        Usuario ObtenerUsuario(string user, string dominio, string contraseña, string appName);

        #endregion Login

        #region Usuarios 

        [OperationContract]
        Usuario[] ObtenerUsuariosPorParametros(ParametrosBusquedaUsuarios parametros);

        #endregion Usuarios
    }
}
