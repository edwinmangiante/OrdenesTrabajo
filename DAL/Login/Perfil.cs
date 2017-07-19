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

        #region Métodos 

        public static Perfil ObtenerPerfilPorUsuario(Usuario usuario)
        {
            try
            {
                SqlConnection connection = null;
                return ObtenerPerfilPorUsuario(usuario, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Perfil ObtenerPerfilPorUsuario(Usuario usuario, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Perfil perfil = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtienePerfil", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd, usuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            perfil = new Perfil();
                            perfil.Codigo = Convert.ToInt32(reader["per_codigo"]);
                            perfil.Descripcion = reader["per_descripcion"].ToString();
                            perfil.Opciones = Opcion.ObtenerPorPerfil(perfil.Codigo);
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

        private static void AddParameters(SqlCommand cmd, Usuario usuario)
        {
            SqlParameter pa_usu_usuario = cmd.Parameters.Add("@usu_usuario", SqlDbType.VarChar, 20);
            pa_usu_usuario.Value = usuario.User;
            SqlParameter pa_usu_dominio = cmd.Parameters.Add("@usu_dominio", SqlDbType.VarChar, 50);
            pa_usu_dominio.Value = usuario.Domain;
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            pa_per_codigo.Value = usuario.CodigoPerfil;
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
