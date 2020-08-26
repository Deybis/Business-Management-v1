using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryCXP_ExpenseTypes
    {
        private static Entities.CXP_ExpenseTypes cxp_expensetypes;
        private static Entities.CXP_ExpenseTypesCollection CXP_ExpenseTypesCollection;

        /// <summary>
        /// Elimina un registro de la tabla CXP_ExpenseTypes a traves del procedimiento  [CXP].[up_CXP_ExpenseTypesDelete] para este objeto, pasando como parametro un valor para el campo  ExpenseTypesID
        /// </summary>
        /// <param name="expenseTypesID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteCXP_ExpenseTypes(int expenseTypesID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpenseTypesDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "ExpenseTypesID", expenseTypesID, DbType.Int32, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [CXP].[CXP_ExpenseTypes] 
        /// a traves del procedimiento almacenado  [CXP].[up_CXP_ExpenseTypes] Insert para este proposito.
        /// </summary>
        /// <param name="cxp_expensetypes"> Objeto del tipo Entities.cCXP_ExpenseTypes con la informacion del registro actual en CXP_ExpenseTypesBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo ExpenseTypesID al momento del INSERT</returns>
        public static int saveCXP_ExpenseTypes(Entities.CXP_ExpenseTypes cxp_expensetypes)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpenseTypesInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "ExpenseTypesID", cxp_expensetypes.ExpenseTypesID, DbType.Int32, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"ExpenseTypesName", cxp_expensetypes.ExpenseTypesName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expensetypes.ExpenseTypesName))
                    Helper.createParameter(comando, "ExpenseTypesName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseTypesName", cxp_expensetypes.ExpenseTypesName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"Note", cxp_expensetypes.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expensetypes.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", cxp_expensetypes.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", cxp_expensetypes.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expensetypes.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", cxp_expensetypes.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", cxp_expensetypes.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxp_expensetypes.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", cxp_expensetypes.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", cxp_expensetypes.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxp_expensetypes.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", cxp_expensetypes.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", cxp_expensetypes.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxp_expensetypes.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", cxp_expensetypes.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@ExpenseTypesID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla CXP_ExpenseTypes
        /// desde la base de datos a traves del procedimiento almacenado CXP.up_CXP_ExpenseTypesSelect y devolver el objeto de entidad  Entities.CXP_ExpenseTypes con el resultado.
        /// </summary>
        /// <param name="expenseTypesID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.CXP_ExpenseTypes</returns>
        public static object getCXP_ExpenseTypes(int expenseTypesID, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[CXP].[up_CXP_ExpenseTypesSelect]");

                if (expenseTypesID != 0)
                    Helper.createParameter(comando, "ExpenseTypesID", expenseTypesID, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ExpenseTypesID", DBNull.Value, DbType.Int32, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                cxp_expensetypes = null;
                CXP_ExpenseTypesCollection = new Entities.CXP_ExpenseTypesCollection();
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
                            cxp_expensetypes = new Entities.CXP_ExpenseTypes();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, cxp_expensetypes);

                            CXP_ExpenseTypesCollection.Add(cxp_expensetypes);
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
                        retObject = cxp_expensetypes;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = CXP_ExpenseTypesCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.CXP_ExpenseTypes]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.CXP_ExpenseTypes]</returns>
        public static Entities.CXP_ExpenseTypesCollection getCXP_ExpenseTypesCollectionFromXML(string xmlString)
        {

            Entities.CXP_ExpenseTypesCollection entityCollection = new Entities.CXP_ExpenseTypesCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.CXP_ExpenseTypesCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.CXP_ExpenseTypes cxp_expensetypes)
        {
            if (!record.IsDBNull(record.GetOrdinal("ExpenseTypesID")))
                cxp_expensetypes.ExpenseTypesID = (int)record["ExpenseTypesID"];

            if (!record.IsDBNull(record.GetOrdinal("ExpenseTypesName")))
                cxp_expensetypes.ExpenseTypesName = (string)record["ExpenseTypesName"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                cxp_expensetypes.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                cxp_expensetypes.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                cxp_expensetypes.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                cxp_expensetypes.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                cxp_expensetypes.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}