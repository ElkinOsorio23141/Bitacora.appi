using System.Data;

namespace Ekisa.Api.BotFetal.Services.Common
{
    public class ParameterCommon
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }


        public static void AddParameter(IDbCommand command, ParameterCommon[] parameters)
        {

            if (command.Parameters.Count > 0)
                command.Parameters.Clear();

            foreach (var parameter in parameters)
            {

                var p = command.CreateParameter();
                p.ParameterName = parameter.Name;
                p.Value = parameter.Value;
                command.Parameters.Add(p);
            }
        }
    }
}
