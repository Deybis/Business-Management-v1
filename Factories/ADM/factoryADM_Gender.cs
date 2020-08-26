using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;

namespace BusinessManagment.Factories
{
    public static class factoryADM_Gender
    {
       private static Entities.ADM_Gender adm_gender;      
       private static Entities.ADM_GenderCollection ADM_GenderCollection;
         
        public static int deleteADM_Gender(int genderID)
        {
            
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
            {
                comando.CommandText = Helper.parseCommandText("[ADM].[up_ADM_GenderDelete]");
                comando.CommandType = CommandType.StoredProcedure;

                Helper.createParameter(comando, "GenderID",  genderID, DbType.Int32, ParameterDirection.Input);

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

        public static int saveADM_Gender(Entities.ADM_Gender adm_gender)
        {
            
            using (IDbConnection conn = new SqlConnection(Global.ConnectionString))
            using (IDbCommand comando = conn.CreateCommand())
           {
                    comando.CommandText = Helper.parseCommandText( "[ADM].[up_ADM_GenderInsert]");
                    comando.CommandType = CommandType.StoredProcedure;

            		Helper.createParameter( comando,"GenderID", adm_gender.GenderID,DbType.Int32, ParameterDirection.InputOutput);
                    #region Helper.createParameter( comando,"GenderName", adm_gender.GenderName,DbType.String, ParameterDirection.Input)
                    if (string.IsNullOrEmpty(adm_gender.GenderName))
                            Helper.createParameter( comando,"GenderName", DBNull.Value, DbType.String, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"GenderName", adm_gender.GenderName,DbType.String, ParameterDirection.Input);
                    #endregion

                    #region Helper.createParameter( comando,"Note", adm_gender.Note,DbType.String, ParameterDirection.Input)
                    if (string.IsNullOrEmpty(adm_gender.Note))
                            Helper.createParameter( comando,"Note", DBNull.Value, DbType.String, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"Note", adm_gender.Note,DbType.String, ParameterDirection.Input);
                    #endregion

                    #region Helper.createParameter( comando,"CreatedBy", adm_gender.CreatedBy,DbType.String, ParameterDirection.Input)
                    if (string.IsNullOrEmpty(adm_gender.CreatedBy))
                            Helper.createParameter( comando,"CreatedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"CreatedBy", adm_gender.CreatedBy,DbType.String, ParameterDirection.Input);
                    #endregion

                    #region Helper.createParameter( comando,"CreatedDate", adm_gender.CreatedDate,DbType.DateTime, ParameterDirection.Input)
                    if (adm_gender.CreatedDate.Year == 1)
                            Helper.createParameter( comando,"CreatedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"CreatedDate", adm_gender.CreatedDate,DbType.DateTime, ParameterDirection.Input);
                    #endregion

                    #region Helper.createParameter( comando,"ModifiedBy", adm_gender.ModifiedBy,DbType.String, ParameterDirection.Input)
                    if (string.IsNullOrEmpty(adm_gender.ModifiedBy))
                            Helper.createParameter( comando,"ModifiedBy", DBNull.Value, DbType.String, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"ModifiedBy", adm_gender.ModifiedBy,DbType.String, ParameterDirection.Input);
                    #endregion

                    #region Helper.createParameter( comando,"ModifiedDate", adm_gender.ModifiedDate,DbType.DateTime, ParameterDirection.Input)
                    if (adm_gender.ModifiedDate.Year == 1)
                            Helper.createParameter( comando,"ModifiedDate", DBNull.Value, DbType.DateTime, ParameterDirection.Input);
                    else
                            Helper.createParameter( comando,"ModifiedDate", adm_gender.ModifiedDate,DbType.DateTime, ParameterDirection.Input);
                    #endregion

            

            var result = 0;            
            try
            {
                if (comando.Connection.State == ConnectionState.Closed)
                    comando.Connection.Open();

                result = comando.ExecuteNonQuery();
                result = Convert.ToInt32(((System.Data.SqlClient.SqlParameter)comando.Parameters["@GenderID"]).Value);
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

        public static object getADM_Gender(int genderID, myEnums.EntityType entityType)
        {
            using (IDbConnection conn =  new SqlConnection(Global.ConnectionString))
            using( IDbCommand comando = conn.CreateCommand())
          {

           #region Customize Command Options
           
           comando.CommandType = CommandType.StoredProcedure;
           comando.CommandText = Helper.parseCommandText( "[ADM].[up_ADM_GenderSelect]");

           if (genderID != 0)
            Helper.createParameter(comando, "GenderID",  genderID, DbType.Int32, ParameterDirection.Input);
           else
            Helper.createParameter(comando, "GenderID",  DBNull.Value, DbType.Int32, ParameterDirection.Input);

            #endregion

            #region Customize Data Retrive Execution
            
            adm_gender = null;
            ADM_GenderCollection = new Entities.ADM_GenderCollection();
            try
            {
                if (comando.Connection.State == ConnectionState.Closed)
                    comando.Connection.Open();

             #region Llenado de reader a traves de comando.ExecuteReader

               IDataReader reader = null;
               using ( reader = comando.ExecuteReader(CommandBehavior.CloseConnection))
                {
                 while (reader.Read())
                 {
                            adm_gender = new Entities.ADM_Gender();

                            IDataRecord record = ((IDataRecord) reader);
                            mapDataRecords(record, adm_gender);
                    
                           ADM_GenderCollection.Add(adm_gender);
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
                        retObject = adm_gender;
                        break;
                    case myEnums.EntityType.EntityCollection:
                        retObject = ADM_GenderCollection;
                        break;
                }
                #endregion

            return retObject;
        }
        }
            
    

        private static void mapDataRecords(IDataRecord record, Entities.ADM_Gender adm_gender)
        {
            if (!record.IsDBNull(record.GetOrdinal("GenderID")))
                adm_gender.GenderID =  (int)record["GenderID"];

            if (!record.IsDBNull(record.GetOrdinal("GenderName")))
                adm_gender.GenderName =  (string)record["GenderName"];

            if (!record.IsDBNull(record.GetOrdinal("Note")))
                adm_gender.Note =  (string)record["Note"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedBy")))
                adm_gender.CreatedBy =  (string)record["CreatedBy"];

            if (!record.IsDBNull(record.GetOrdinal("CreatedDate")))
                adm_gender.CreatedDate =  Convert.ToDateTime(record["CreatedDate"]);

            if (!record.IsDBNull(record.GetOrdinal("ModifiedBy")))
                adm_gender.ModifiedBy =  (string)record["ModifiedBy"];

            if (!record.IsDBNull(record.GetOrdinal("ModifiedDate")))
                adm_gender.ModifiedDate =  Convert.ToDateTime(record["ModifiedDate"]);
        }
    }
}