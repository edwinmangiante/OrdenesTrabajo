using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Conexion
{
    internal class Connection : IDisposable
    {
        private static readonly string login = "data source=localhost;initial catalog=Login;persist security info=True;Integrated Security = SSPI";
        private static readonly string logerror = "";
        private static readonly string ordenes = "";

        internal static SqlConnection Conectar(string conexion)
        {
            try
            {
                SqlConnection connection = null;
                string conn = "";
                if (conexion == "login")
                    conn = login;
                else if (conexion == "logerror")
                    conn = logerror;
                else if (conexion == "ordenes")
                    conn = ordenes;

                if (!string.IsNullOrWhiteSpace(conn))
                    connection = new SqlConnection(conn);

                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
