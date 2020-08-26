using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryCXC_Incomes
    {
        private static Entities.CXC_Incomes cxc_incomes;
        private static Entities.CXC_IncomesCollection CXC_IncomesCollection;

        /// <summary>
        /// Elimina un registro de la tabla CXC_Incomes a traves del procedimiento  [CXC].[up_CXC_IncomesDelete] para este objeto, pasando como parametro un valor para el campo  IncomeID
        /// </summary>
        /// <param name="incomeID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteCXC_Incomes(long incomeID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomesDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "IncomeID", incomeID, DbType.Int64, ParameterDirection.Input);

                int result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Exception exx = new Exception(ex.Message, ex);
                    exx.Data.Add("Number", ex.Number);

                    throw exx;
                }
                return result;
            }
        }

        /// <summary>
        ///  Guarda registros en la tabla [CXC].[CXC_Incomes] 
        /// a traves del procedimiento almacenado  [CXC].[up_CXC_Incomes] Insert para este proposito.
        /// </summary>
        /// <param name="cxc_incomes"> Objeto del tipo Entities.cCXC_Incomes con la informacion del registro actual en CXC_IncomesBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo IncomeID al momento del INSERT</returns>
        public static int saveCXC_Incomes(Entities.CXC_Incomes cxc_incomes)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomesInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "IncomeID", cxc_incomes.IncomeID, DbType.Int64, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"IncomeTypesID", cxc_incomes.IncomeTypesID,DbType.Int32, ParameterDirection.Input)
                if (cxc_incomes.IncomeTypesID == 0)
                    Helper.createParameter(comando, "IncomeTypesID", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeTypesID", cxc_incomes.IncomeTypesID, DbType.Int32, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"UserID", cxc_incomes.AccountID,DbType.Int64, ParameterDirection.Input)
                if (cxc_incomes.AccountID == 0)
                    Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountID", cxc_incomes.AccountID, DbType.Int64, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"IncomeName", cxc_incomes.IncomeName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incomes.IncomeName))
                    Helper.createParameter(comando, "IncomeName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeName", cxc_incomes.IncomeName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"IncomeDescription", cxc_incomes.IncomeDescription,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incomes.IncomeDescription))
                    Helper.createParameter(comando, "IncomeDescription", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeDescription", cxc_incomes.IncomeDescription, DbType.String, ParameterDirection.Input);
                #endregion

                Helper.createParameter(comando, "IncomeAmount", cxc_incomes.IncomeAmount, DbType.Decimal, ParameterDirection.Input);
                #region Helper.createParameter( comando,"Note", cxc_incomes.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incomes.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", cxc_incomes.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", cxc_incomes.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incomes.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", cxc_incomes.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", cxc_incomes.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxc_incomes.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", cxc_incomes.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", cxc_incomes.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incomes.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", cxc_incomes.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", cxc_incomes.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxc_incomes.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", cxc_incomes.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@IncomeID"]).Value);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Exception exx = new Exception(ex.Message, ex);
                    exx.Data.Add("Number", ex.Number);

                    throw exx;
                }
                return result;
            }
        }

        /// <summary>
        /// Metodo que permite obtener datos de la tabla CXC_Incomes
        /// desde la base de datos a traves del procedimiento almacenado CXC.up_CXC_IncomesSelect y devolver el objeto de entidad  Entities.CXC_Incomes con el resultado.
        /// </summary>
        /// <param name="incomeID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.CXC_Incomes</returns>
        public static object getCXC_Incomes(long incomeID,string accountLoginUser, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomesSelect]");

                if (incomeID != 0)
                    Helper.createParameter(comando, "IncomeID", incomeID, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeID", DBNull.Value, DbType.Int64, ParameterDirection.Input);

                if (!string.IsNullOrEmpty(accountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                cxc_incomes = null;
                CXC_IncomesCollection = new Entities.CXC_IncomesCollection();
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
                            cxc_incomes = new Entities.CXC_Incomes();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, cxc_incomes);

                            CXC_IncomesCollection.Add(cxc_incomes);
                        }
                    }
                    #endregion
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message, ex);
                }

                #endregion

                #region Return Values

                Object retObject = null;
                switch (entityType)
                {
                    case myEnums.EntityType.Entity:
                        retObject = cxc_incomes;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = CXC_IncomesCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.CXC_Incomes]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.CXC_Incomes]</returns>
        public static Entities.CXC_IncomesCollection getCXC_IncomesCollectionFromXML(string xmlString)
        {

            Entities.CXC_IncomesCollection entityCollection = new Entities.CXC_IncomesCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.CXC_IncomesCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.CXC_Incomes cxc_incomes)
        {
            if (!record.IsDBNull(record.GetOrdinal("IncomeID")))
                cxc_incomes.IncomeID = (long)record["IncomeID"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeTypesID")))
                cxc_incomes.IncomeTypesID = (int)record["IncomeTypesID"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeTypesName")))
                cxc_incomes.IncomeTypesName = (string)record["IncomeTypesName"];

            if (!record.IsDBNull(record.GetOrdinal("AccountID")))
                cxc_incomes.AccountID = (long)record["AccountID"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeName")))
                cxc_incomes.IncomeName = (string)record["IncomeName"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeDescription")))
                cxc_incomes.IncomeDescription = (string)record["IncomeDescription"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeAmount")))
                cxc_incomes.IncomeAmount = (decimal)record["IncomeAmount"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                cxc_incomes.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                cxc_incomes.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                cxc_incomes.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                cxc_incomes.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                cxc_incomes.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}