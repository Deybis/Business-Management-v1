using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryADM_TaskStatus
    {
        private static Entities.ADM_TaskStatus adm_taskstatus;
        private static Entities.ADM_TaskStatusCollection ADM_TaskStatusCollection;

        /// <summary>
        /// Elimina un registro de la tabla ADM_TaskStatus a traves del procedimiento  [ADM].[up_ADM_TaskStatusDelete] para este objeto, pasando como parametro un valor para el campo  TaskStatusID
        /// </summary>
        /// <param name="taskStatusID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteADM_TaskStatus(int taskStatusID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TaskStatusDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "TaskStatusID", taskStatusID, DbType.Int32, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [ADM].[ADM_TaskStatus] 
        /// a traves del procedimiento almacenado  [ADM].[up_ADM_TaskStatus] Insert para este proposito.
        /// </summary>
        /// <param name="adm_taskstatus"> Objeto del tipo Entities.cADM_TaskStatus con la informacion del registro actual en ADM_TaskStatusBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo TaskStatusID al momento del INSERT</returns>
        public static int saveADM_TaskStatus(Entities.ADM_TaskStatus adm_taskstatus)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TaskStatusInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "TaskStatusID", adm_taskstatus.TaskStatusID, DbType.Int32, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"TaskStatusName", adm_taskstatus.TaskStatusName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_taskstatus.TaskStatusName))
                    Helper.createParameter(comando, "TaskStatusName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskStatusName", adm_taskstatus.TaskStatusName, DbType.String, ParameterDirection.Input);
                #endregion

                Helper.createParameter(comando, "IsActive", adm_taskstatus.IsActive, DbType.Boolean, ParameterDirection.Input);
                #region Helper.createParameter( comando,"Note", adm_taskstatus.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_taskstatus.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", adm_taskstatus.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", adm_taskstatus.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_taskstatus.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", adm_taskstatus.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", adm_taskstatus.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (adm_taskstatus.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", adm_taskstatus.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", adm_taskstatus.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(adm_taskstatus.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", adm_taskstatus.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", adm_taskstatus.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (adm_taskstatus.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", adm_taskstatus.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@TaskStatusID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla ADM_TaskStatus
        /// desde la base de datos a traves del procedimiento almacenado ADM.up_ADM_TaskStatusSelect y devolver el objeto de entidad  Entities.ADM_TaskStatus con el resultado.
        /// </summary>
        /// <param name="taskStatusID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.ADM_TaskStatus</returns>
        public static object getADM_TaskStatus(int taskStatusID, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_TaskStatusSelect]");

                if (taskStatusID != 0)
                    Helper.createParameter(comando, "TaskStatusID", taskStatusID, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "TaskStatusID", DBNull.Value, DbType.Int32, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                adm_taskstatus = null;
                ADM_TaskStatusCollection = new Entities.ADM_TaskStatusCollection();
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
                            adm_taskstatus = new Entities.ADM_TaskStatus();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, adm_taskstatus);

                            ADM_TaskStatusCollection.Add(adm_taskstatus);
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
                        retObject = adm_taskstatus;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = ADM_TaskStatusCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.ADM_TaskStatus]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.ADM_TaskStatus]</returns>
        public static Entities.ADM_TaskStatusCollection getADM_TaskStatusCollectionFromXML(string xmlString)
        {

            Entities.ADM_TaskStatusCollection entityCollection = new Entities.ADM_TaskStatusCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.ADM_TaskStatusCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.ADM_TaskStatus adm_taskstatus)
        {
            if (!record.IsDBNull(record.GetOrdinal("TaskStatusID")))
                adm_taskstatus.TaskStatusID = (int)record["TaskStatusID"];

            if (!record.IsDBNull(record.GetOrdinal("TaskStatusName")))
                adm_taskstatus.TaskStatusName = (string)record["TaskStatusName"];

            if (!record.IsDBNull(record.GetOrdinal("IsActive")))
                adm_taskstatus.IsActive = (bool)record["IsActive"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                adm_taskstatus.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                adm_taskstatus.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                adm_taskstatus.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                adm_taskstatus.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                adm_taskstatus.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}