using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryCXP_Expenses
    {
        private static Entities.CXP_Expenses cxp_expenses;
        private static Entities.CXP_ExpensesCollection CXP_ExpensesCollection;

        /// <summary>
        /// Elimina un registro de la tabla CXP_Expenses a traves del procedimiento  [CXP].[up_CXP_ExpensesDelete] para este objeto, pasando como parametro un valor para el campo  ExpenseID
        /// </summary>
        /// <param name="expenseID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteCXP_Expenses(long expenseID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpensesDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "ExpenseID", expenseID, DbType.Int64, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [CXP].[CXP_Expenses] 
        /// a traves del procedimiento almacenado  [CXP].[up_CXP_Expenses] Insert para este proposito.
        /// </summary>
        /// <param name="cxp_expenses"> Objeto del tipo Entities.cCXP_Expenses con la informacion del registro actual en CXP_ExpensesBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo ExpenseID al momento del INSERT</returns>
        public static int saveCXP_Expenses(Entities.CXP_Expenses cxp_expenses)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpensesInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "ExpenseID", cxp_expenses.ExpenseID, DbType.Int64, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"ExpenseTypesID", cxp_expenses.ExpenseTypesID,DbType.Int32, ParameterDirection.Input)
                if (cxp_expenses.ExpenseTypesID == 0)
                    Helper.createParameter(comando, "ExpenseTypesID", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseTypesID", cxp_expenses.ExpenseTypesID, DbType.Int32, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"AccountID", cxp_expenses.AccountID,DbType.Int64, ParameterDirection.Input)
                if (cxp_expenses.AccountID == 0)
                    Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountID", cxp_expenses.AccountID, DbType.Int64, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ExpenseName", cxp_expenses.ExpenseName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expenses.ExpenseName))
                    Helper.createParameter(comando, "ExpenseName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseName", cxp_expenses.ExpenseName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ExpenseDescription", cxp_expenses.ExpenseDescription,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expenses.ExpenseDescription))
                    Helper.createParameter(comando, "ExpenseDescription", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseDescription", cxp_expenses.ExpenseDescription, DbType.String, ParameterDirection.Input);
                #endregion

                Helper.createParameter(comando, "ExpenseAmount", cxp_expenses.ExpenseAmount, DbType.Decimal, ParameterDirection.Input);
                #region Helper.createParameter( comando,"Note", cxp_expenses.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expenses.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", cxp_expenses.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", cxp_expenses.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expenses.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", cxp_expenses.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", cxp_expenses.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxp_expenses.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", cxp_expenses.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", cxp_expenses.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expenses.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", cxp_expenses.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", cxp_expenses.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxp_expenses.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", cxp_expenses.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@ExpenseID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla CXP_Expenses
        /// desde la base de datos a traves del procedimiento almacenado CXP.up_CXP_ExpensesSelect y devolver el objeto de entidad  Entities.CXP_Expenses con el resultado.
        /// </summary>
        /// <param name="expenseID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.CXP_Expenses</returns>
        public static object getCXP_Expenses(long expenseID, string accountLoginUser, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpensesSelect]");

                if (expenseID != 0)
                    Helper.createParameter(comando, "ExpenseID", expenseID, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseID", DBNull.Value, DbType.Int64, ParameterDirection.Input);

                if (!string.IsNullOrEmpty(accountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                cxp_expenses = null;
                CXP_ExpensesCollection = new Entities.CXP_ExpensesCollection();
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
                            cxp_expenses = new Entities.CXP_Expenses();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, cxp_expenses);

                            CXP_ExpensesCollection.Add(cxp_expenses);
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
                        retObject = cxp_expenses;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = CXP_ExpensesCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.CXP_Expenses]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.CXP_Expenses]</returns>
        public static Entities.CXP_ExpensesCollection getCXP_ExpensesCollectionFromXML(string xmlString)
        {

            Entities.CXP_ExpensesCollection entityCollection = new Entities.CXP_ExpensesCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.CXP_ExpensesCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.CXP_Expenses cxp_expenses)
        {
            if (!record.IsDBNull(record.GetOrdinal("ExpenseID")))
                cxp_expenses.ExpenseID = (long)record["ExpenseID"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseTypesID")))
                cxp_expenses.ExpenseTypesID = (int)record["ExpenseTypesID"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseTypesName")))
                cxp_expenses.ExpenseTypesName = (string)record["ExpenseTypesName"];

            if (!record.IsDBNull(record.GetOrdinal("AccountID")))
                cxp_expenses.AccountID = (long)record["AccountID"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseName")))
                cxp_expenses.ExpenseName = (string)record["ExpenseName"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseDescription")))
                cxp_expenses.ExpenseDescription = (string)record["ExpenseDescription"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseAmount")))
                cxp_expenses.ExpenseAmount = (decimal)record["ExpenseAmount"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                cxp_expenses.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                cxp_expenses.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                cxp_expenses.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                cxp_expenses.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                cxp_expenses.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}