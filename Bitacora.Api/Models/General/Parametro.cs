using System.ComponentModel.DataAnnotations;

namespace Ekisa.Api.BotFetal.Models
{
    public class Parametro
    {
        [Key]
        public short Idparametro { get; set; }
        public short IdCliente { get; set; }
        public short IdProceso { get; set; }
        public string NombreParametro { get; set; }
        public string ValorParametro { get; set; }
        public string Descripcion { get; set; }
        public string TextoCampo { get; set; }
    }
}
