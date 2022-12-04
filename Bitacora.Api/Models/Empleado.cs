using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bitacora.Api.Models
{
    public class Empleado
    {
        [Key]
        [JsonIgnore]
        public string IdEmpleado { get; set; }
    }
}
