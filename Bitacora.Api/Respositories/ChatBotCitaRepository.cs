using Ekisa.Api.BotFetal.Interfaces;
using Ekisa.Api.BotFetal.Models;
using Ekisa.Api.BotFetal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ekisa.Api.BotFetal.Models.Context;
using Ekisa.Api.BotFetal.Services.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Ekisa.Api.BotFetal.Respositories
{
    public class ChatBotCitaRepository : Repository<ChatBotCita>, IChatBotCitaRepository
    {
        private readonly CommandContext _commandContext;

        public ChatBotCitaRepository(EkisaAppContext contextApp, IConfiguration configuration) : base(contextApp)
        {
            this._commandContext = new CommandContext(configuration);
        }

        public List<ChatBotCita> GetAllCitasByFecha(DateTime FechaI,
            DateTime FechaF)
        {
            try
            {
                var command = _commandContext.DbContext;
                var Proc_fac_ConsultarFacturasTraza = new List<ChatBotCita>();
                Proc_fac_ConsultarFacturasTraza = DataTableBase.ConvertDataTable<ChatBotCita>(
                    command.Fill("Bot_Proc_Cit_ConsultarCitasAsignadas",
                        new[]
                        {
                            new ParameterCommon
                                { Name = "@FechaI", Value = FechaI.ToString("yyyy-MM-dd") },
                            new ParameterCommon
                                { Name = "@FechaF", Value = FechaF.ToString("yyyy-MM-dd") }
                        }));
                return Proc_fac_ConsultarFacturasTraza;
            }
            catch (Exception ex) { return null; }
        }

        public int ConfirmarCita(decimal numeroOrden)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("Bot_Proc_Cit_ConfirmarCitas",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@NumeroCita", Value =numeroOrden.ToString() },
                    });

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception ex) { return 0; }
        }

        public int CancelarCita(decimal numeroOrden)
        {
            try
            {
                var command = _commandContext.DbContext;
                var result = command.ExecuteNonQuery("Bot_Proc_Cit_CancelacionCitas",
                    new[]
                    {
                        new ParameterCommon
                            { Name = "@NumeroCita", Value =numeroOrden.ToString() },
                    });

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else { return 0; }
            }
            catch (Exception ex) { return 0; }
        }
    }
}
