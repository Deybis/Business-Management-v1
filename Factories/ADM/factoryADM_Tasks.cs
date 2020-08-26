using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryADM_Tasks
    {
        private static Entities.ADM_Tasks adm_tasks;
        private static Entities.ADM_TasksCollection ADM_TasksCollection;

        /// <summary>
        /// Elimina un registro de la tabla ADM_Tasks a traves del procedimiento  [ADM].[up_ADM_TasksDelete] para este objeto, pasando como parametro un valor para el campo  TaskID
        /// </summary>
        /// <param name="taskID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteADM_Tasks(long taskID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TasksDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "TaskID", taskID, DbType.Int64, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [ADM].[ADM_Tasks] 
        /// a traves del procedimiento almacenado  [ADM].[up_ADM_Tasks] Insert para este proposito.
        /// </summary>
        /// <param name="adm_tasks"> Objeto del tipo Entities.cADM_Tasks con la informacion del registro actual en ADM_TasksBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo TaskID al momento del INSERT</returns>
        public static int saveADM_Tasks(Entities.ADM_Tasks adm_tasks)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TasksInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "TaskID", adm_tasks.TaskID, DbType.Int64, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"AccountID", adm_tasks.AccountID,DbType.Int64, ParameterDirection.Input)
                if (adm_tasks.AccountID == 0)
                    Helper.createParameter(comando, "AccountID", DBNull.Value, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountID", adm_tasks.AccountID, DbType.Int64, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"TaskStatusID", adm_tasks.TaskStatusID,DbType.Int32, ParameterDirection.Input)
                if (adm_tasks.TaskStatusID == 0)
                    Helper.createParameter(comando, "TaskStatusID", DBNull.Value, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskStatusID", adm_tasks.TaskStatusID, DbType.Int32, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"TaskName", adm_tasks.TaskName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_tasks.TaskName))
                    Helper.createParameter(comando, "TaskName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskName", adm_tasks.TaskName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"TaskDate", adm_tasks.TaskDate,DbType.DateTime, ParameterDirection.Input)
                if (adm_tasks.TaskDate.Year == 1)
                    Helper.createParameter(comando, "TaskDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskDate", adm_tasks.TaskDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"Note", adm_tasks.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_tasks.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", adm_tasks.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", adm_tasks.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_tasks.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", adm_tasks.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", adm_tasks.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (adm_tasks.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", adm_tasks.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", adm_tasks.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_tasks.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", adm_tasks.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", adm_tasks.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (adm_tasks.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", adm_tasks.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@TaskID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla ADM_Tasks
        /// desde la base de datos a traves del procedimiento almacenado ADM.up_ADM_TasksSelect y devolver el objeto de entidad  Entities.ADM_Tasks con el resultado.
        /// </summary>
        /// <param name="taskID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.ADM_Tasks</returns>
        public static object getADM_Tasks(long taskID, string accountLoginUser, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TasksSelect]");

                if (taskID != 0)
                    Helper.createParameter(comando, "TaskID", taskID, DbType.Int64, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskID", DBNull.Value, DbType.Int64, ParameterDirection.Input);

                if (!string.IsNullOrEmpty(accountLoginUser))
                    Helper.createParameter(comando, "AccountLoginUser", accountLoginUser, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "AccountLoginUser", DBNull.Value, DbType.String, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                adm_tasks = null;
                ADM_TasksCollection = new Entities.ADM_TasksCollection();
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
                            adm_tasks = new Entities.ADM_Tasks();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, adm_tasks);

                            ADM_TasksCollection.Add(adm_tasks);
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
                        retObject = adm_tasks;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = ADM_TasksCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.ADM_Tasks]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.ADM_Tasks]</returns>
        public static Entities.ADM_TasksCollection getADM_TasksCollectionFromXML(string xmlString)
        {

            Entities.ADM_TasksCollection entityCollection = new Entities.ADM_TasksCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.ADM_TasksCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.ADM_Tasks adm_tasks)
        {
            if (!record.IsDBNull(record.GetOrdinal("TaskID")))
                adm_tasks.TaskID = (long)record["TaskID"];

            if (!record.IsDBNull(record.GetOrdinal("AccountID")))
                adm_tasks.AccountID = (long)record["AccountID"];

            if (!record.IsDBNull(record.GetOrdinal("TaskStatusID")))
                adm_tasks.TaskStatusID = (int)record["TaskStatusID"];

            if (!record.IsDBNull(record.GetOrdinal("TaskStatusName")))
                adm_tasks.TaskStatusName = (string)record["TaskStatusName"];

            if (!record.IsDBNull(record.GetOrdinal("TaskName")))
                adm_tasks.TaskName = (string)record["TaskName"];

            if (!record.IsDBNull(record.GetOrdinal("TaskDate")))
                adm_tasks.TaskDate = Convert.ToDateTime(record["TaskDate"]);

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                adm_tasks.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                adm_tasks.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                adm_tasks.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                adm_tasks.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                adm_tasks.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}