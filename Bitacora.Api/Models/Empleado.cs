using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bitacora.Api.Models
{
    public class Empleado
    {
        [Key]
        [JsonIgnore]
        public int IdEmpleado { get; set; }
    }
}
