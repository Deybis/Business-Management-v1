using System;
using System.Xml;
using System.Data;
using System.Text;
using BusinessManagment;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryCXC_IncomeTypes
    {
        private static Entities.CXC_IncomeTypes cxc_incometypes;
        private static Entities.CXC_IncomeTypesCollection CXC_IncomeTypesCollection;

        /// <summary>
        /// Elimina un registro de la tabla CXC_IncomeTypes a traves del procedimiento  [CXC].[up_CXC_IncomeTypesDelete] para este objeto, pasando como parametro un valor para el campo  IncomeTypesID
        /// </summary>
        /// <param name="incomeTypesID">Campo llave de la tabla por el cual se eliminara el registro</param>
        /// <returns>Devuelve un valor positivo que indica si el procediento se efectuo correctamente</returns>
        public static int deleteCXC_IncomeTypes(int incomeTypesID)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomeTypesDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "IncomeTypesID", incomeTypesID, DbType.Int32, ParameterDirection.Input);

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
        ///  Guarda registros en la tabla [CXC].[CXC_IncomeTypes] 
        /// a traves del procedimiento almacenado  [CXC].[up_CXC_IncomeTypes] Insert para este proposito.
        /// </summary>
        /// <param name="cxc_incometypes"> Objeto del tipo Entities.cCXC_IncomeTypes con la informacion del registro actual en CXC_IncomeTypesBindingSource</param>
        /// <returns>Devuelve el valor IDENTITY generado por la base de datos para el campo IncomeTypesID al momento del INSERT</returns>
        public static int saveCXC_IncomeTypes(Entities.CXC_IncomeTypes cxc_incometypes)
        {

            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomeTypesInsert]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "IncomeTypesID", cxc_incometypes.IncomeTypesID, DbType.Int32, ParameterDirection.InputOutput);
                #region Helper.createParameter( comando,"IncomeTypesName", cxc_incometypes.IncomeTypesName,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incometypes.IncomeTypesName))
                    Helper.createParameter(comando, "IncomeTypesName", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeTypesName", cxc_incometypes.IncomeTypesName, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"Note", cxc_incometypes.Note,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incometypes.Note))
                    Helper.createParameter(comando, "Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "Note", cxc_incometypes.Note, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedBy", cxc_incometypes.CreatedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incometypes.CreatedBy))
                    Helper.createParameter(comando, "CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedBy", cxc_incometypes.CreatedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"CreatedDate", cxc_incometypes.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxc_incometypes.CreatedDate.Year == 1)
                    Helper.createParameter(comando, "CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "CreatedDate", cxc_incometypes.CreatedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedBy", cxc_incometypes.ModifiedBy,DbType.String, ParameterDirection.Input)
                if (string.IsNullOrEmpty(cxc_incometypes.ModifiedBy))
                    Helper.createParameter(comando, "ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedBy", cxc_incometypes.ModifiedBy, DbType.String, ParameterDirection.Input);
                #endregion

                #region Helper.createParameter( comando,"ModifiedDate", cxc_incometypes.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                if (cxc_incometypes.ModifiedDate.Year == 1)
                    Helper.createParameter(comando, "ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "ModifiedDate", cxc_incometypes.ModifiedDate, DbType.DateTime, ParameterDirection.Input);
                #endregion



                var result = 0;
                try
                {
                    if (comando.Connection.State == ConnectionState.Closed)
                        comando.Connection.Open();

                    result = comando.ExecuteNonQuery();
                    result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@IncomeTypesID"]).Value);
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
        /// Metodo que permite obtener datos de la tabla CXC_IncomeTypes
        /// desde la base de datos a traves del procedimiento almacenado CXC.up_CXC_IncomeTypesSelect y devolver el objeto de entidad  Entities.CXC_IncomeTypes con el resultado.
        /// </summary>
        /// <param name="incomeTypesID">Valor del principal de la tabla </param>
        /// <param name="entityType"></param>
        /// <returns>Devuelve un registro como Entities.CXC_IncomeTypes</returns>
        public static object getCXC_IncomeTypes(int incomeTypesID, myEnums.EntityType entityType)
        {
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {

                #region Customize Command Options

                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Helper.parseCommandText("[CXC].[up_CXC_IncomeTypesSelect]");

                if (incomeTypesID != 0)
                    Helper.createParameter(comando, "IncomeTypesID", incomeTypesID, DbType.Int32, ParameterDirection.Input);
                else
                    Helper.createParameter(comando, "IncomeTypesID", DBNull.Value, DbType.Int32, ParameterDirection.Input);

                #endregion

                #region Customize Data Retrive Execution

                cxc_incometypes = null;
                CXC_IncomeTypesCollection = new Entities.CXC_IncomeTypesCollection();
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
                            cxc_incometypes = new Entities.CXC_IncomeTypes();

                            IDataRecord record = ((IDataRecord)reader);
                            mapDataRecords(record, cxc_incometypes);

                            CXC_IncomeTypesCollection.Add(cxc_incometypes);
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
                        retObject = cxc_incometypes;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = CXC_IncomeTypesCollection;
                        break;
                }
                #endregion

                return retObject;
            }
        }



        /// <summary>
        /// Devuelve un objeto List[Entities.CXC_IncomeTypes]  de tipo List
        /// </summary>
        /// <param name="xmlString">Definicion XML del List</param>
        /// <returns>List/Coleccion de tipo  [Entities.CXC_IncomeTypes]</returns>
        public static Entities.CXC_IncomeTypesCollection getCXC_IncomeTypesCollectionFromXML(string xmlString)
        {

            Entities.CXC_IncomeTypesCollection entityCollection = new Entities.CXC_IncomeTypesCollection();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(entityCollection.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Hacemos cast al objeto generado para deserealizar
            entityCollection = (Entities.CXC_IncomeTypesCollection)obj;

            return entityCollection;
        }

        private static void mapDataRecords(IDataRecord record, Entities.CXC_IncomeTypes cxc_incometypes)
        {
            if (!record.IsDBNull(record.GetOrdinal("IncomeTypesID")))
                cxc_incometypes.IncomeTypesID = (int)record["IncomeTypesID"];

            if (!record.IsDBNull(record.GetOrdinal("IncomeTypesName")))
                cxc_incometypes.IncomeTypesName = (string)record["IncomeTypesName"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                cxc_incometypes.Note = (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                cxc_incometypes.CreatedBy = (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                cxc_incometypes.CreatedDate = Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                cxc_incometypes.ModifiedBy = (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                cxc_incometypes.ModifiedDate = Convert.ToDateTime(record["ModifiedDate"]);


        }
    }
}