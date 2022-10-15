using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Ekisa.Api.BotFetal.Models
{
    public class ChatBotCita
    {
        [Key]
        [JsonIgnore]

        public decimal? NumeroCita { get; set; }
        public string IdPaciente { get; set; }
        public DateTime FechaCita { get; set; }
        public string NombresPaciente { get; set; }
        public string Procedimiento { get; set; }
        public string Profesional { get; set; }
        public string Institucion { get; set; }
        public string Celular { get; set; }
    }
}
