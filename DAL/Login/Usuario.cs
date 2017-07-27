using DAL.Conexion;
using DAL.ParametrosBusqueda;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Login
{
    public class Usuario : ICloneable
    {
        #region Propiedades

        public string User { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CodigoPerfil { get; set; }
        public Perfil PerfilUsuario { get; set; }
        public string DescripcionPerfil { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string AppName { get; set; }

        private static Usuario usuario { get; set; }

        #endregion Propiedades

        #region Constructores

        public Usuario()
        {
        }

        private Usuario(SqlDataReader reader, string appName)
        {
            usuario = new Usuario();
            usuario.User = reader["usu_usuario"].ToString();
            usuario.Domain = reader["usu_dominio"].ToString();
            usuario.Password = reader["usu_contraseña"].ToString();
            usuario.Nombre = reader["usu_nombre"].ToString();
            usuario.Apellido = reader["usu_apellido"].ToString();
            usuario.CodigoPerfil = Convert.ToInt32(reader["usu_per_codigo"]);
            usuario.PerfilUsuario = Perfil.ObtenerPerfilPorUsuario(usuario, appName);
            usuario.DescripcionPerfil = usuario.PerfilUsuario.Descripcion;
            usuario.FechaAlta = Convert.ToDateTime(reader["usu_fecha_alta"]);
            usuario.FechaBaja = reader["usu_fecha_baja"] != DBNull.Value ? Convert.ToDateTime(reader["usu_fecha_baja"]) : (DateTime?)null;
            //return usuario;
        }

        #endregion Constructores

        #region Login

        public static Usuario ObtenerUsuario(string user, string dominio, string contraseña, string appName)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.User = user;
                usuario.Domain = dominio;
                usuario.Password = contraseña;
                usuario.AppName = appName;
                SqlConnection connection = null;
                return ObtenerUsuario(usuario, connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static Usuario ObtenerUsuario(Usuario usu, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                //Usuario usu = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtenerUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParametersLogin(cmd, usu);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.Read())
                            new Usuario(reader, usu.AppName);
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return usuario;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static void AddParametersLogin(SqlCommand cmd, Usuario usuario)
        {
            SqlParameter pa_usu_usuario = cmd.Parameters.Add("@usu_usuario", SqlDbType.VarChar, 20);
            pa_usu_usuario.Value = usuario.User;
            SqlParameter pa_usu_dominio = cmd.Parameters.Add("@usu_dominio", SqlDbType.VarChar, 50);
            pa_usu_dominio.Value = usuario.Domain;
            SqlParameter pa_usu_contraseña = cmd.Parameters.Add("@usu_contraseña", SqlDbType.VarChar, 100);
            pa_usu_contraseña.Value = usuario.Password;
        }

        #endregion Login

        #region Métodos

        public static Usuario ObtenerPorPK(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = null)
                    return ObtenerPorPK(usuario, connection);
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

        public static List<Usuario> ObtenerPorParametros(ParametrosBusquedaUsuarios parametros)
        {
            try
            {
                using (SqlConnection connection = null)
                    return ObtenerPorParametros(parametros, connection);
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

        public static Usuario Crear(Usuario usuarioACrear)
        {
            try
            {
                using (SqlConnection connection = null)
                    return Crear(usuarioACrear, connection);
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

        private static Usuario ObtenerPorPK(Usuario usu, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                //Usuario usu = null;
                using (SqlCommand cmd = new SqlCommand("dbo.ObtenerUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    ParametrosBusquedaUsuarios parametros = new ParametrosBusquedaUsuarios();
                    parametros.User = usu.User;
                    parametros.Dominio = usu.Domain;
                    parametros.NombreApp = usu.AppName;
                    AddSearchParameters(cmd, parametros);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                        if (reader.Read())
                            new Usuario(reader, parametros.NombreApp);
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return usuario;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static List<Usuario> ObtenerPorParametros(ParametrosBusquedaUsuarios parametros, SqlConnection connection)
        {
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                List<Usuario> usuarios = null;
                using (SqlCommand cmd = new SqlCommand("dbo.GetUsuarios", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddSearchParameters(cmd, parametros);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        usuarios = new List<Usuario>();
                        while (reader.Read())
                        {
                            new Usuario(reader, parametros.NombreApp);
                            usuarios.Add(usuario);
                        }
                    }
                }

                if (connection.State != ConnectionState.Closed)
                    connection.Close();

                connection.Dispose();

                return usuarios;
            }
            else
                throw new Exception("La conexión está vacía.");
        }

        private static Usuario Crear(Usuario usuarioACrear, SqlConnection connection)
        {
            Usuario usr = new Usuario();
            connection = Connection.Conectar("login");
            if (connection != null)
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.ABMUsuarios", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddABMParameters(cmd, usuarioACrear);

                    int a = cmd.ExecuteNonQuery();

                    usr.Domain = usuarioACrear.Domain;
                    usr.User = usuarioACrear.User;
                }
            }

            return ObtenerPorPK(usr);
        }

        private static void AddSearchParameters(SqlCommand cmd, ParametrosBusquedaUsuarios parametros)
        {
            SqlParameter pa_usu_usuario = cmd.Parameters.Add("@usu_usuario", SqlDbType.VarChar, 20);
            if (!string.IsNullOrWhiteSpace(parametros.User))
                pa_usu_usuario.Value = parametros.User;
            else
                pa_usu_usuario.Value = DBNull.Value;
            SqlParameter pa_usu_dominio = cmd.Parameters.Add("@usu_dominio", SqlDbType.VarChar, 50);
            if (!string.IsNullOrWhiteSpace(parametros.Dominio))
                pa_usu_dominio.Value = parametros.Dominio;
            else
                pa_usu_dominio.Value = DBNull.Value;
            SqlParameter pa_usu_nomape = cmd.Parameters.Add("@usu_nomape", SqlDbType.VarChar, 100);
            if (!string.IsNullOrWhiteSpace(parametros.NomApe))
                pa_usu_nomape.Value = parametros.NomApe;
            else
                pa_usu_nomape.Value = DBNull.Value;
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            if (parametros.CodigoPerfil.HasValue)
                pa_per_codigo.Value = parametros.CodigoPerfil.Value;
            else
                pa_per_codigo.Value = DBNull.Value;
            SqlParameter pa_opc_aplicacion = cmd.Parameters.Add("@opc_aplicacion", SqlDbType.VarChar, 50);
            if (!string.IsNullOrWhiteSpace(parametros.NombreApp))
                pa_opc_aplicacion.Value = parametros.NombreApp;
            else
                pa_opc_aplicacion.Value = DBNull.Value;
            SqlParameter pa_incluir_bajas = cmd.Parameters.Add("@incluir_bajas", SqlDbType.Int);
            if (parametros.IncluirBajas.HasValue)
                pa_incluir_bajas.Value = parametros.IncluirBajas.Value;
            else
                pa_incluir_bajas.Value = DBNull.Value;
        }

        private static void AddABMParameters(SqlCommand cmd, Usuario usuario)
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
            SqlParameter pa_usu_contraseña = cmd.Parameters.Add("@usu_contraseña", SqlDbType.VarChar, 100);
            if (!string.IsNullOrWhiteSpace(usuario.Password))
                pa_usu_contraseña.Value = usuario.Password;
            else
                pa_usu_contraseña.Value = DBNull.Value;
            SqlParameter pa_usu_nombre = cmd.Parameters.Add("@usu_nombre", SqlDbType.VarChar, 100);
            if (!string.IsNullOrWhiteSpace(usuario.Nombre))
                pa_usu_nombre.Value = usuario.Nombre;
            else
                pa_usu_nombre.Value = DBNull.Value;
            SqlParameter pa_usu_apellido = cmd.Parameters.Add("@usu_apellido", SqlDbType.VarChar, 100);
            if (!string.IsNullOrWhiteSpace(usuario.Apellido))
                pa_usu_apellido.Value = usuario.Apellido;
            else
                pa_usu_apellido.Value = DBNull.Value;
            SqlParameter pa_per_codigo = cmd.Parameters.Add("@per_codigo", SqlDbType.Int);
            if (usuario.PerfilUsuario != null)
                pa_per_codigo.Value = usuario.CodigoPerfil;
            else
                pa_per_codigo.Value = DBNull.Value;
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

        #region Clonable
        //la hacemos iclonable porque no hay webservices, sino la parcial es la que tiene que ser iclonable!
        public Usuario Clone()
        {
            return (Usuario)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion Clonable
    }
}
