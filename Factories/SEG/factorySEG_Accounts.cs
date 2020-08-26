using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factorySEG_Accounts
    {
        private static Entities.SEG_Accounts seg_accounts;
        private static Entities.SEG_AccountsCollection SEG_AccountsCollection;

        /// <summary>
        /// Elimina un registro de la tabla SEG_Accounts a traves del procedimiento  [SEG].[up_SEG_AccountsDelete] para este objeto, pasando como parametro un valor para el campo  AccountID
        /// </summary>
        /// <param name="accountID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteSEG_Accounts(long accountID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_AccountsDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "AccountID", accountID, DbType.Int64, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [SEG].[SEG_Accounts] 
        /// a traves del procedimiento almacenado  [SEG].[up_SEG_Accounts] Insert para este proposito.
        /// </summary>
        /// <param name="seg_accounts"> Objeto del tipo Entities.cSEG_Accounts con la informacion del registro actual en SEG_AccountsBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo AccountID al momento del INSERT</returns>
        public static int saveSEG_Accounts(Entities.SEG_Accounts seg_accounts)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_AccountsInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "AccountID", seg_accounts.AccountID, DbType.Int64, ParameterDirection.InputOutput);

                #region Helper.createParameter( comando,"AccountLoginUser", seg_accounts.AccountLoginUser,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.AccountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", seg_accounts.AccountLoginUser, DbType.String, ParameterDirection.Input);
                #endregion

                Helper.createParameter(comando, "StatusID", seg_accounts.StatusID, DbType.Int32, ParameterDirection.Input);

                #region Helper.createParameter( comando,"AccountLoginPassword", seg_accounts.AccountLoginPassword,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.AccountLoginPassword))
                    Helper.createParameter(comando, "AccountLoginPassword", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginPassword", seg_accounts.AccountLoginPassword, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CompanyName", seg_accounts.CompanyName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.CompanyName))
                    Helper.createParameter(comando, "CompanyName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CompanyName", seg_accounts.CompanyName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CompanyImage", seg_accounts.CompanyImage,DbType.Binary, ParameterDirection.Input)
                if (seg_accounts.CompanyImage == null)
                    Helper.createParameter(comando, "CompanyImage", DBNull.Value, DbType.Binary, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CompanyImage", seg_accounts.CompanyImage, DbType.Binary, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CompanyPhoneNumber", seg_accounts.CompanyPhoneNumber,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.CompanyPhoneNumber))
                    Helper.createParameter(comando, "CompanyPhoneNumber", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CompanyPhoneNumber", seg_accounts.CompanyPhoneNumber, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CompanyEmail", seg_accounts.CompanyEmail,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.CompanyEmail))
                    Helper.createParameter(comando, "CompanyEmail", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CompanyEmail", seg_accounts.CompanyEmail, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"AccountActive", seg_accounts.AccountActive,DbType.String, ParameterDirection.Input)
                Helper.createParameter(comando, "AccountActive", seg_accounts.AccountActive, DbType.Boolean, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"AccountIdentifyToken", seg_accounts.AccountIdentifyToken,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.AccountIdentifyToken))
                    Helper.createParameter(comando, "AccountIdentifyToken", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountIdentifyToken", seg_accounts.AccountIdentifyToken, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"Note", seg_accounts.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", seg_accounts.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", seg_accounts.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", seg_accounts.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", seg_accounts.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (seg_accounts.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", seg_accounts.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", seg_accounts.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_accounts.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", seg_accounts.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", seg_accounts.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (seg_accounts.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", seg_accounts.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@AccountID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla SEG_Accounts
        /// desde la base de datos a traves del procedimiento almacenado SEG.up_SEG_AccountsSelect y devolver el objeto de entidad  Entities.SEG_Accounts con el resultado.
        /// </summary>
        /// <param name="accountID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.SEG_Accounts</returns>
        public static object getSEG_Accounts(long accountID, string accountLoginUser, string companyEmail, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_AccountsSelect]");

                if (accountID != 0)
                    Helper.createParameter(comando, "AccountID", accountID, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);


                if (!string.IsNullOrEmpty(accountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);

                if (!string.IsNullOrEmpty(companyEmail))
                    Helper.createParameter(comando, "CompanyEmail", companyEmail, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CompanyEmail", DBNull.Value, DbType.String, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                seg_accounts = new Entities.SEG_Accounts();
                SEG_AccountsCollection = new Entities.SEG_AccountsCollection();
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
                            seg_accounts = new Entities.SEG_Accounts();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, seg_accounts);

                            SEG_AccountsCollection.Add(seg_accounts);
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
                        retObject = seg_accounts;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = SEG_AccountsCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.SEG_Accounts]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.SEG_Accounts]</returns>
        public static Entities.SEG_AccountsCollection getSEG_AccountsCollectionFromXML(string xmlString)
        {

            Entities.SEG_AccountsCollection entityCollection = new Entities.SEG_AccountsCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.SEG_AccountsCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.SEG_Accounts seg_accounts)
        {
            if (!record.IsDBNull(record.GetOrdinal("AccountID")))
                seg_accounts.AccountID = (long)record["AccountID"];

            if (!record.IsDBNull(record.GetOrdinal("StatusID")))
                seg_accounts.StatusID = (Int32)record["StatusID"];

            if (!record.IsDBNull(record.GetOrdinal("AccountLoginUser")))
                seg_accounts.AccountLoginUser = (string)record["AccountLoginUser"];

            if (!record.IsDBNull(record.GetOrdinal("AccountLoginPassword")))
                seg_accounts.AccountLoginPassword = (string)record["AccountLoginPassword"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyName")))
                seg_accounts.CompanyName = (string)record["CompanyName"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyImage")))
                seg_accounts.CompanyImage = (byte[])record["CompanyImage"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyPhoneNumber")))
                seg_accounts.CompanyPhoneNumber = (string)record["CompanyPhoneNumber"];

            if (!record.IsDBNull(record.GetOrdinal("CompanyEmail")))
                seg_accounts.CompanyEmail = (string)record["CompanyEmail"];

            if (!record.IsDBNull(record.GetOrdinal("AccountActive")))
                seg_accounts.AccountActive = (Boolean)record["AccountActive"];

            if (!record.IsDBNull(record.GetOrdinal("AccountIdentifyToken")))
                seg_accounts.AccountIdentifyToken = (string)record["AccountIdentifyToken"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                seg_accounts.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                seg_accounts.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                seg_accounts.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                seg_accounts.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                seg_accounts.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}