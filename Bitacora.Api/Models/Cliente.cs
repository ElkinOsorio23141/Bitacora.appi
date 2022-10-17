using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Bitacora.Api.Models
{
    public class Cliente
    {
        [Key]
        [JsonIgnore]
        public int Idcliente { get; set; }
    }   
}
