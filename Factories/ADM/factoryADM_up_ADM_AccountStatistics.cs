using System;
using System.Xml;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public class factoryADM_up_ADM_AccountStatistics
    {

        /// <summary>
        /// Permite obtener registros desde la base de datos a traves del procedimiento almacenado ADM.up_ADM_AccountStatistics
        /// </summary>
        /// <param name=<"columna">ID del campo principal de la tabla</param>
        /// <returns></returns>
        public static Entities.up_ADM_AccountStatisticsCollection execute_ADM_up_ADM_AccountStatisticsCollection(Int32 day, Int32 month, Int32 year, String accountLoginUser, Int64 accountID)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_AccountStatistics]");
                comando.CommandType = CommandType.StoredProcedure;

                if (day == 0)
                    Helper.createParameter(comando, "Day", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Day", day, DbType.Int32, ParameterDirection.Input);

                if (month == 0)
                    Helper.createParameter(comando, "Month", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Month", month, DbType.Int32, ParameterDirection.Input);

                if (year == 0)
                    Helper.createParameter(comando, "Year", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Year", year, DbType.Int32, ParameterDirection.Input);

                if (string.IsNullOrEmpty(accountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);

                if (accountID == 0)
                    Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountID", accountID, DbType.Int64, ParameterDirection.Input);


                Entities.up_ADM_AccountStatistics up_adm_accountstatistics = null;
                var up_ADM_AccountStatisticsList = new Entities.up_ADM_AccountStatisticsCollection();

                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    #region Llenado de reader a traves de comando.ExecuteReader

                    IDataReader reader = null;
                    using (reader = comando.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            up_adm_accountstatistics = new Entities.up_ADM_AccountStatistics();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, up_adm_accountstatistics);

                            up_ADM_AccountStatisticsList.Add(up_adm_accountstatistics);
                        }
                    }
                    #endregion

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                return up_ADM_AccountStatisticsList;
            }
        }

        /// <summary>
        /// Devuelve un objeto Entities.ADM_up_ADM_AccountStatisticsCollection
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>Coleccion de tipo Entities.ADM_up_ADM_AccountStatisticsCollection</returns>
        public static Entities.up_ADM_AccountStatisticsCollection getADM_up_ADM_AccountStatisticsCollectionFromXMLString(string xmlString)
        {

            Entities.up_ADM_AccountStatisticsCollection entityCollection = new Entities.up_ADM_AccountStatisticsCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            Entities.up_ADM_AccountStatisticsCollection up_ADM_AccountStatisticsList = new Entities.up_ADM_AccountStatisticsCollection();
            up_ADM_AccountStatisticsList = (Entities.up_ADM_AccountStatisticsCollection)obj;

            return up_ADM_AccountStatisticsList;
        }

        private static void mapDataRecords(IDataRecord record, Entities.up_ADM_AccountStatistics up_adm_accountstatistics)
        {
            if (!record.IsDBNull(record.GetOrdinal("IncomeName")))
                up_adm_accountstatistics.IncomeName = (string)record["IncomeName"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeAmount")))
                up_adm_accountstatistics.IncomeAmount = (decimal)record["IncomeAmount"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseName")))
                up_adm_accountstatistics.ExpenseName = (string)record["ExpenseName"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseAmount")))
                up_adm_accountstatistics.ExpenseAmount = (decimal)record["ExpenseAmount"];


        }
    }
}