using System.Data;
using System.Data.Common;
namespace Ekisa.Api.BotFetal.Services.Common
{
    public class CommandCommon
    {
        private readonly DbCommand _command;

        public CommandCommon(DbCommand command, DbConnection connection)
        {
            _command = command;
            _command.Connection = connection;
            _command.CommandType = System.Data.CommandType.StoredProcedure;

        }

        //DEVUELVE LA CANTIDAD DE FILAS AFECTADAS RECIBE NOMBRE Y PARAMETROS DEL SP
        public int ExecuteNonQuery(string procedure, ParameterCommon[] parameters)
        {

            _command.CommandText = procedure;
            ParameterCommon.AddParameter(_command, parameters);
            _command.Connection.Open();
            var rowCount = _command.ExecuteNonQuery();
            return rowCount;
        }

        //SOBRECARGA DE METODO ExecuteNonQuery SIN PARAMETROS
        public int ExecuteNonQuery(string procedure)
        {
            return ExecuteNonQuery(procedure, new ParameterCommon[0]);
        }


        // Devuelve un datatable con los parametros enviados => Nombre y parametros del procedimiento almacenado
        public DataTable Fill(string procedure, ParameterCommon[] parameters)
        {
            _command.CommandText = procedure;
            ParameterCommon.AddParameter(_command, parameters);
            var dataTable = new DataTable();
            if (_command.Connection.State == ConnectionState.Closed)
            {
                _command.Connection.Open();
            }
            var datareader = _command.ExecuteReader();
            dataTable.Load(datareader);
            datareader.Close();
            _command.Connection.Close();

            return dataTable;
        }

        //SOBRECARGA DE METODO FILL POR SI NO RECIBE PARAMETROS SOLO EL NOMBRE DEL SP
        public DataTable Fill(string procedure)
        {
            return Fill(procedure, new ParameterCommon[0]);
        }


        //DEVUELVE LA PRIMERA COLUMNA DE LA PRIMERA FILA DEL CONJUNTO DE  RESULTADOS
        public object ExecuteScalar(string procedure, ParameterCommon[] parameters)
        {
            _command.CommandText = procedure;

            ParameterCommon.AddParameter(_command, parameters);

            _command.Connection.Open();
            var value = _command.ExecuteScalar();
            _command.Connection.Close();

            return value;
        }

        //SOBRECARGA DE METODO ExecuteScalar SIN PARAMETROS
        public object ExecuteScalar(string procedure)
        {
            return ExecuteScalar(procedure, new ParameterCommon[0]);
        }

    }
}
