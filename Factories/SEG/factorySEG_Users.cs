using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factorySEG_Users
    {
        private static Entities.SEG_Users seg_users;
        private static Entities.SEG_UsersCollection SEG_UsersCollection;

        /// <summary>
        /// Elimina un registro de la tabla SEG_Users a traves del procedimiento  [SEG].[up_SEG_UsersDelete] para este objeto, pasando como parametro un valor para el campo  UserID
        /// </summary>
        /// <param name="userID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deteleSEG_Users(long userID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_UsersDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "UserID", userID, DbType.Int64, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [SEG].[SEG_Users] 
        /// a traves del procedimiento almacenado  [SEG].[up_SEG_Users] Insert para este proposito.
        /// </summary>
        /// <param name="seg_users"> Objeto del tipo Entities.cSEG_Users con la informacion del registro actual en SEG_UsersBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo UserID al momento del INSERT</returns>
        public static int saveSEG_Users(Entities.SEG_Users seg_users)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_UsersInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "UserID", seg_users.UserID, DbType.Int64, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"UserName", seg_users.UserName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.UserName))
                    Helper.createParameter(comando, "UserName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "UserName", seg_users.UserName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"UserLogin", seg_users.UserLogin,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.UserLogin))
                    Helper.createParameter(comando, "UserLogin", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "UserLogin", seg_users.UserLogin, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"UserPassword", seg_users.UserPassword,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.UserPassword))
                    Helper.createParameter(comando, "UserPassword", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "UserPassword", seg_users.UserPassword, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"UserImage", seg_users.UserImage,DbType.Binary, ParameterDirection.Input)
                if (seg_users.UserImage == null)
                    Helper.createParameter(comando, "UserImage", DBNull.Value, DbType.Binary, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "UserImage", seg_users.UserImage, DbType.Binary, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"GenderID", seg_users.GenderID,DbType.Int32, ParameterDirection.Input)
                if (seg_users.GenderID == 0)
                    Helper.createParameter(comando, "GenderID", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "GenderID", seg_users.GenderID, DbType.Int32, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"Note", seg_users.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", seg_users.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", seg_users.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", seg_users.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", seg_users.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (seg_users.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", seg_users.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", seg_users.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(seg_users.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", seg_users.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", seg_users.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (seg_users.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", seg_users.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@UserID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla SEG_Users
        /// desde la base de datos a traves del procedimiento almacenado SEG.up_SEG_UsersSelect y devolver el objeto de entidad  Entities.SEG_Users con el resultado.
        /// </summary>
        /// <param name="userID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.SEG_Users</returns>
        public static object getSEG_Users(long userID, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[SEG].[up_SEG_UsersSelect]");

                if (userID != 0)
                    Helper.createParameter(comando, "UserID", userID, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "UserID", DBNull.Value, DbType.Int64, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                seg_users = null;
                SEG_UsersCollection = new Entities.SEG_UsersCollection();
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
                            seg_users = new Entities.SEG_Users();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, seg_users);

                            SEG_UsersCollection.Add(seg_users);
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
                        retObject = seg_users;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = SEG_UsersCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.SEG_Users]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.SEG_Users]</returns>
        public static Entities.SEG_UsersCollection getSEG_UsersCollectionFromXML(string xmlString)
        {

            Entities.SEG_UsersCollection entityCollection = new Entities.SEG_UsersCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.SEG_UsersCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.SEG_Users seg_users)
        {
            if (!record.IsDBNull(record.GetOrdinal("UserID")))
                seg_users.UserID = (long)record["UserID"];

            if (!record.IsDBNull(record.GetOrdinal("UserName")))
                seg_users.UserName = (string)record["UserName"];

            if (!record.IsDBNull(record.GetOrdinal("UserLogin")))
                seg_users.UserLogin = (string)record["UserLogin"];

            if (!record.IsDBNull(record.GetOrdinal("UserPassword")))
                seg_users.UserPassword = (string)record["UserPassword"];

            if (!record.IsDBNull(record.GetOrdinal("UserImage")))
                seg_users.UserImage = (byte[])record["UserImage"];

            if (!record.IsDBNull(record.GetOrdinal("GenderID")))
                seg_users.GenderID = (int)record["GenderID"];

            if (!record.IsDBNull(record.GetOrdinal("GenderName")))
                seg_users.GenderName = (string)record["GenderName"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                seg_users.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                seg_users.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                seg_users.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                seg_users.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                seg_users.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}