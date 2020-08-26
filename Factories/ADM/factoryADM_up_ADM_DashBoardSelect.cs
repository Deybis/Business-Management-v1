using System;
using System.Xml;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public class factoryADM_up_ADM_DashBoardSelect
    {

        /// <summary>
        /// Permite obtener registros desde la base de datos a traves del procedimiento almacenado ADM.up_ADM_DashBoardSelect
        /// </summary>
        /// <param name=<"columna">ID del campo principal de la tabla</param>
        /// <returns></returns>
        public static Entities.up_ADM_DashBoardSelectCollection execute_ADM_up_ADM_DashBoardSelectCollection(UInt64 accountID, String accountLoginUser)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_DashBoardSelect]");
                comando.CommandType = CommandType.StoredProcedure;

                if(accountID == 0)
                Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);
                else
                Helper.createParameter(comando, "AccountID", accountID, DbType.Int64, ParameterDirection.Input);

                if(string.IsNullOrEmpty(accountLoginUser))
                Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);

                Entities.up_ADM_DashBoardSelect up_adm_dashboardselect = null;
                var up_ADM_DashBoardSelectList = new Entities.up_ADM_DashBoardSelectCollection();

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
                            up_adm_dashboardselect = new Entities.up_ADM_DashBoardSelect();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, up_adm_dashboardselect);

                            up_ADM_DashBoardSelectList.Add(up_adm_dashboardselect);
                        }
                    }
                    #endregion

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                return up_ADM_DashBoardSelectList;
            }
        }

        /// <summary>
        /// Devuelve un objeto Entities.ADM_up_ADM_DashBoardSelectCollection
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>Coleccion de tipo Entities.ADM_up_ADM_DashBoardSelectCollection</returns>
        public static Entities.up_ADM_DashBoardSelectCollection getADM_up_ADM_DashBoardSelectCollectionFromXMLString(string xmlString)
        {

            Entities.up_ADM_DashBoardSelectCollection entityCollection = new Entities.up_ADM_DashBoardSelectCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            Entities.up_ADM_DashBoardSelectCollection up_ADM_DashBoardSelectList = new Entities.up_ADM_DashBoardSelectCollection();
            up_ADM_DashBoardSelectList = (Entities.up_ADM_DashBoardSelectCollection)obj;

            return up_ADM_DashBoardSelectList;
        }

        private static void mapDataRecords(IDataRecord record, Entities.up_ADM_DashBoardSelect up_adm_dashboardselect)
        {
            if (!record.IsDBNull(record.GetOrdinal("AccountID")))
                up_adm_dashboardselect.AccountID = (long)record["AccountID"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyName")))
                up_adm_dashboardselect.CompanyName = (string)record["CompanyName"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyImage")))
                up_adm_dashboardselect.CompanyImage = (byte[])record["CompanyImage"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyPhoneNumber")))
                up_adm_dashboardselect.CompanyPhoneNumber = (string)record["CompanyPhoneNumber"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyEmail")))
                up_adm_dashboardselect.CompanyEmail = (string)record["CompanyEmail"];

            if (!record.IsDBNull(record.GetOrdinal("IncomesTotal")))
                up_adm_dashboardselect.IncomesTotal = (decimal)record["IncomesTotal"];

            if (!record.IsDBNull(record.GetOrdinal("ExpensesTotal")))
                up_adm_dashboardselect.ExpensesTotal = (decimal)record["ExpensesTotal"];

            if (!record.IsDBNull(record.GetOrdinal("TaskID")))
                up_adm_dashboardselect.TaskID = (long)record["TaskID"];

            if (!record.IsDBNull(record.GetOrdinal("TaskName")))
                up_adm_dashboardselect.TaskName = (string)record["TaskName"];

            if (!record.IsDBNull(record.GetOrdinal("TaskDate")))
                up_adm_dashboardselect.TaskDate = Convert.ToDateTime(record["TaskDate"]);

            if (!record.IsDBNull(record.GetOrdinal("TaskStatusName")))
                up_adm_dashboardselect.TaskStatusName = (string)record["TaskStatusName"];               
        }
    }
}