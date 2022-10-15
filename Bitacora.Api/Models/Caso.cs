using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bitacora.Api.Models
{
    public class Caso
    {
        [Key]
        [JsonIgnore]

        public decimal? IdCaso { get; set; }
    }
}
