using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ekisa.Api.BotFetal.Models
{
    public partial class EkisaAppContext : DbContext
    {
        public EkisaAppContext()
        {
        }

        public EkisaAppContext(DbContextOptions<EkisaAppContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DIEGO-M; Initial Catalog=Quiron; User Id=sa; Password=1234; Integrated Security=True;Trusted_Connection=False;Encrypt=True;");
            }
        }

    }
}
