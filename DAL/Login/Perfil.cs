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
    public class Perfil
    {
        #region Propiedades

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<Opcion> Opciones { get; set; }

        #endregion Propiedades

        #region Constructores

        public Perfil()
        {
        }

        #endregion Constructores

        #region Login 

        public static Perfil ObtenerPerfilPorUsuario(Usuario usuario, string appName)
        {
            try
            {
                SqlConnection connection = null;
                return ObtenerPerfilPorUsuario(usuario, appName, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Perfil ObtenerPerfilPorUsuario(Usuario usuario, string appName, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                Perfil perfil = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtienePerfil", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddLoginParameters(cmd, usuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = new Perfil();
                            perfil.Codigo = Convert.ToInt32(reader["per_codigo"]);
                            perfil.Descripcion = reader["per_descripcion"].ToString();
                            perfil.Opciones = Opcion.ObtenerPorPerfil(perfil.Codigo, appName);
                        }
                    }
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return perfil;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static void AddLoginParameters(SqlCommand cmd, Usuario usuario)
        {
            SqlParameter pa_usu_usuario = cmd.Parameters.Add("@usu_usuario", SqlDbType.VarChar, 20);
            pa_usu_usuario.Value = usuario.User;
            SqlParameter pa_usu_dominio = cmd.Parameters.Add("@usu_dominio", SqlDbType.VarChar, 50);
            pa_usu_dominio.Value = usuario.Domain;
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            pa_per_codigo.Value = usuario.CodigoPerfil;
        }

        #endregion Login

        #region Métodos

        public static List<Perfil> ObtenerPerfiles(string appName)
        {
            try
            {
                SqlConnection connection = null;
                return ObtenerPerfiles(appName, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Perfil> ObtenerPerfiles(string appName, SqlConnection connection)
        {
            List<Perfil> perfiles = null;
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.GetPerfiles", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    Usuario usu = new Usuario();
                    usu.User = "";
                    usu.Domain = "";
                    usu.CodigoPerfil = 0;
                    usu.AppName = appName;
                    AddSearchParameters(cmd, usu);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        perfiles = new List<Perfil>();
                        while (reader.Read())
                        {
                            Perfil perfil = new Perfil();
                            perfil.Codigo = Convert.ToInt32(reader["per_codigo"]);
                            perfil.Descripcion = reader["per_descripcion"].ToString();
                            perfil.Opciones = Opcion.ObtenerPorPerfil(perfil.Codigo, appName);

                            perfiles.Add(perfil);
                        }
                    }
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return perfiles;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static void AddSearchParameters(SqlCommand cmd, Usuario usuario)
        {
            SqlParameter pa_usu_usuario = cmd.Parameters.Add("@usu_usuario", SqlDbType.VarChar, 20);
            if (!string.IsNullOrWhiteSpace(usuario.User))
                pa_usu_usuario.Value = usuario.User;
            else
                pa_usu_usuario.Value = DBNull.Value;
            SqlParameter pa_usu_dominio = cmd.Parameters.Add("@usu_dominio", SqlDbType.VarChar, 50);
            if (!string.IsNullOrWhiteSpace(usuario.Domain))
                pa_usu_dominio.Value = usuario.Domain;
            else
                pa_usu_dominio.Value = DBNull.Value;
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            if (usuario.CodigoPerfil != 0)
                pa_per_codigo.Value = usuario.CodigoPerfil;
            else
                pa_per_codigo.Value = DBNull.Value;
            SqlParameter pa_opc_aplicacion = cmd.Parameters.Add("@opc_aplicacion", SqlDbType.VarChar, 50);
            if (!string.IsNullOrWhiteSpace(usuario.AppName))
                pa_opc_aplicacion.Value = usuario.AppName;
            else
                pa_opc_aplicacion.Value = DBNull.Value;
        }

        #endregion Métodos

        #region Equals, HashCode y ToString

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Perfil per = obj as Perfil;
            if (per == null)
                return false;
            else
            {
                if (per.Codigo == this.Codigo)
                    return true;
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Codigo.GetHashCode();
        }

        public static bool operator ==(Perfil perA, Perfil perB)
        {
            if (object.ReferenceEquals(perA, perB))
                return true;

            if ((object)perA == null || (object)perB == null)
                return false;

            return perA.Equals(perB);
        }

        public static bool operator !=(Perfil perA, Perfil perB)
        {
            return !(perA == perB);
        }

        public override string ToString()
        {
            return Descripcion;
        }

        #endregion Equals, HashCode y ToString
    }
}
