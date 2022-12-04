using System;

namespace Bitacora.Api.Models
{
    public class InsertarEmpleadoParams
    {
        public string Identificacion { get; set; }
        public int IdTipoIdentificacion{ get; set; }  
        public string PrimerNombre{ get; set; }  
        public string SegundoNombre{ get; set; } 
        public string PrimerApellido{ get; set; }  
        public string SegundoApellido{ get; set; } 
        public string Sexo{ get; set; } 
        public DateTime FechaNacimiento { get; set; }  
        public string Direccion{ get; set; }  
        public string Telefono{ get; set; }  
        public string Celular{ get; set; }  
        public string Correo{ get; set; }
        public string Estado { get; set; }

    }
}
