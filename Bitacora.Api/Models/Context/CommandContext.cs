
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Ekisa.Api.BotFetal.Services.Common;

namespace Ekisa.Api.BotFetal.Models.Context
{
    public class CommandContext
    {


        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommandCommon DbContext { get; private set; }
        private readonly string _ConnectionString;
        private string _Provider;

        public enum EnumDataProvider
        {
            Sql,
            MySql
        }

        public CommandContext(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("EkisaApp");

            this._Provider = configuration.GetSection("DataProvider").Value;
            EnumDataProvider enumProvider;

            Enum.TryParse(_Provider, out enumProvider);

            if (Enum.TryParse(_Provider, out enumProvider))
                GetValue(enumProvider);

        }

        public CommandContext(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {

            EkisaAppContext contextApp = new EkisaAppContext();

            _httpContextAccessor = httpContextAccessor;
            var parametro = Convert.ToInt16(_httpContextAccessor.HttpContext.Request.Headers["Parametro"].ToString());
            if (parametro != 0)
            {
                var stringConexion =
                    "contextApp.Clientes.Where(x => x.IdCliente == parametro).Select(x => x.BaseDatos).FirstOrDefault();";
                _ConnectionString = stringConexion;
            }
            else
            {
                _ConnectionString = configuration.GetConnectionString("EkisaApp");
            }

            this._Provider = configuration.GetSection("DataProvider").Value;
            EnumDataProvider enumProvider;

            Enum.TryParse(_Provider, out enumProvider);

            if (Enum.TryParse(_Provider, out enumProvider))
                GetValue(enumProvider);

        }

        private void GetValue(EnumDataProvider enumProvider)
        {

            var cnx = _ConnectionString;
            DbConnection connection = null;
            DbCommand command = null;

            switch (enumProvider)
            {
                case EnumDataProvider.Sql:
                    connection = new SqlConnection(cnx);
                    command = new SqlCommand();
                    break;

                    //case EnumDataProvider.MySql:
                    //    connection = new MySqlConnection(cnx);
                    //    command = new MySqlCommand();
                    //    break;
            }

            DbContext = new CommandCommon(command, connection);
        }

    }
}

