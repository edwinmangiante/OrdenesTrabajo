using System;
using System.Collections.Generic;
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
