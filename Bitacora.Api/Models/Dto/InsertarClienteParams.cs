using System;

namespace Bitacora.Api.Models
{
    public class InsertarClienteParams
    {
        public string IdentificacionCliente { get; set; } 
        public int IdTipoIdentificacion { get; set; }
        public string NombreCliente { get; set; }
        public string DirecionCliente { get; set; }
        public string CodigoCiudad { get; set; }
        public string TelefonoCliente { get; set; }
        public string CorreoCliente{ get; set; }  
        public string Observacion{ get; set; }  
        public Boolean EstadoCliente{ get; set; }  
        public string Poliza{ get; set; }  
        public DateTime FechaVencePoliza{ get; set; }  
        public int NotaPoliza{ get; set; }  
        public string TipoCliente { get; set; }
    }
}
