using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bitacora.Api.Models
{
    public class Usuario
    {
        [Key]
        [JsonIgnore]

        public int IdUsuario { get; set; }
    }
}

