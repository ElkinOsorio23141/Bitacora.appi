using System.Runtime.Intrinsics.X86;

namespace Bitacora.Api.Models
{
    public class InsertarUsuarioParams
    {
        public string CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }
        public string IdEmpleado { get; set; }
        public string IdPerfil { get; set; }
        public string Estado { get; set; }  
    }
}
