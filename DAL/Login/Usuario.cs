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
    public class Usuario
    {
        #region Propiedades

        public string User { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CodigoPerfil { get; set; }
        public Perfil PerfilUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        #endregion Propiedades

        #region Constructores

        public Usuario()
        {
        }

        #endregion Constructores

        #region Métodos

        public static Usuario ObtenerUsuario(string user, string dominio, string contraseña)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.User = user;
                usuario.Domain = dominio;
                usuario.Password = contraseña;
                SqlConnection connection = null;
                return ObtenerUsuario(usuario, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Usuario ObtenerUsuario(Usuario usuario, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                Usuario usu = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtenerUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd, usuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usu = new Usuario();
                            usu.User = reader["usu_usuario"].ToString();
                            usu.Domain = reader["usu_dominio"].ToString();
                            usu.Password = reader["usu_contraseña"].ToString();
                            usu.Nombre = reader["usu_nombre"].ToString();
                            usu.Apellido = reader["usu_apellido"].ToString();
                            usu.CodigoPerfil = Convert.ToInt32(reader["usu_per_codigo"]);
                            usu.PerfilUsuario = Perfil.ObtenerPerfilPorUsuario(usu);
                            usu.FechaAlta = Convert.ToDateTime(reader["usu_fecha_alta"]);
                            usu.FechaBaja = reader["usu_fecha_baja"] != null ? Convert.ToDateTime(reader["usu_fecha_baja"]) : (DateTime?)null;
                        }
                    }
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return usu;
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
            SqlParameter pa_usu_contraseña = cmd.Parameters.Add("@usu_contraseña", SqlDbType.VarChar, 100);
            pa_usu_contraseña.Value = usuario.Password;
        }

        #endregion Métodos

        #region Equals, HashCode y ToString

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Usuario usu = obj as Usuario;
            if (usu == null)
                return false;
            else
            {
                if (usu.User == this.User &&
                    usu.Domain == this.Domain)
                    return true;
                else
                    return false;
            }
        }

        public override int GetHashCode()
        {
            return this.User.GetHashCode() ^
                   this.Domain.GetHashCode();
        }

        public static bool operator ==(Usuario usuA, Usuario usuB)
        {
            if (object.ReferenceEquals(usuA, usuB))
                return true;

            if ((object)usuA == null || (object)usuB == null)
                return false;

            return usuA.Equals(usuB);
        }

        public static bool operator !=(Usuario usuA, Usuario usuB)
        {
            return !(usuA == usuB);
        }

        public override string ToString()
        {
            return Apellido + ", " + Nombre + " (" + PerfilUsuario.Descripcion + ")";
        }

        #endregion Equals, HashCode y ToString
    }
}
