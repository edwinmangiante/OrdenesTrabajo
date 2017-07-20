using DAL.Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Login
{
    public class Opcion
    {
        #region Propiedades

        public int Codigo { get; set; }
        public string Aplicacion { get; set; }
        public string Descripcion { get; set; }
        public bool CanSelect { get; set; }
        public bool CanInsert { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
        public bool CanBajaAlta { get; set; }

        #endregion Propiedades

        #region Constructores

        public Opcion()
        {
        }

        #endregion Constructores

        #region Métodos 

        public static List<Opcion> ObtenerPorPerfil(int codigoPerfil, string appName)
        {
            try
            {
                SqlConnection connection = null;
                return ObtenerPorPerfil(codigoPerfil, appName, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Opcion> ObtenerPorPerfil(int codigoPerfil, string appName, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                List<Opcion> opciones = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtieneOpciones", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd, codigoPerfil, appName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        opciones = new List<Opcion>();
                        while(reader.Read())
                        {
                            Opcion opc = new Opcion();
                            opc.Codigo = Convert.ToInt32(reader["opc_codigo"]);
                            opc.Aplicacion = reader["opc_aplicacion"].ToString();
                            opc.Descripcion = reader["opc_descripcion"].ToString();
                            opc.CanSelect = Convert.ToInt32(reader["opc_can_select"]) == 1 ? true : false;
                            opc.CanInsert = Convert.ToInt32(reader["opc_can_insert"]) == 1 ? true : false;
                            opc.CanUpdate = Convert.ToInt32(reader["opc_can_update"]) == 1 ? true : false;
                            opc.CanDelete = Convert.ToInt32(reader["opc_can_delete"]) == 1 ? true : false;
                            opc.CanBajaAlta = Convert.ToInt32(reader["opc_can_baal"]) == 1 ? true : false;

                            opciones.Add(opc);
                        }
                    }
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return opciones;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static void AddParameters(SqlCommand cmd, int codigoPerfil, string appName)
        {
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            pa_per_codigo.Value = codigoPerfil;
            SqlParameter pa_opc_aplicacion = cmd.Parameters.Add("@opc_aplicacion", SqlDbType.VarChar, 50);
            pa_opc_aplicacion.Value = appName;
        }

        #endregion Métodos

        #region Equals, HashCode y ToString

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Opcion opc = obj as Opcion;
            if (opc == null)
                return false;
            else
            {
                if (opc.Codigo == this.Codigo &&
                    opc.Aplicacion == this.Aplicacion)
                    return true;
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Codigo.GetHashCode() ^
                   this.Aplicacion.GetHashCode();
        }

        public static bool operator ==(Opcion opcA, Opcion opcB)
        {
            if (object.ReferenceEquals(opcA, opcB))
                return true;

            if ((object)opcA == null || (object)opcB == null)
                return false;

            return opcA.Equals(opcB);
        }

        public static bool operator !=(Opcion opcA, Opcion opcB)
        {
            return !(opcA == opcB);
        }

        public override string ToString()
        {
            return Descripcion;
        }

        #endregion Equals, HashCode y ToString
    }
}
