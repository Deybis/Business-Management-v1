using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BusinessManagment
{
    public class Helper
    {
        public static myEnums.SQLEngineType CurrentSQLEngine
        {
            get
            {
                string SQLEngineType = Global.SQLEngineType;

                if (SQLEngineType.Contains("My"))
                    return myEnums.SQLEngineType.MySQL;
                else
                    return myEnums.SQLEngineType.SQLServer;
            }
            set { CurrentSQLEngine = value; }
        }

        public static void createParameter(ref IDbCommand comando, string parameterName, object parameterValue, DbType parameterType, ParameterDirection parameterDirection)
        {
            IDataParameter parameter = comando.CreateParameter();
            parameter.ParameterName = getComposedParameterName(parameterName);
            parameter.Value = (parameterType == DbType.DateTime && parameterValue.ToString().Contains("01/01/0001 12:00:00") ? DateTime.Now : parameterValue);
            parameter.DbType = parameterType;
            parameter.Direction = parameterDirection;

            comando.Parameters.Add(parameter);
        }

        public static void createParameter(IDbCommand comando, string parameterName, object parameterValue, DbType parameterType, ParameterDirection parameterDirection)
        {
            IDataParameter parameter = comando.CreateParameter();
            parameter.ParameterName = getComposedParameterName(parameterName);
            parameter.Value = (parameterType == DbType.DateTime && parameterValue.ToString().Contains("01/01/0001 12:00:00") ? DateTime.Now : parameterValue);
            parameter.DbType = parameterType;
            parameter.Direction = parameterDirection;

            comando.Parameters.Add(parameter);
        }

        private static string getComposedParameterName(string parameterName)
        {
            string prefijo = "@";
            string retValue = "";
            if (parameterName.Substring(0, 1).Contains("@"))
                retValue = parameterName;
            else
                retValue = string.Format("{0}{1}", prefijo, parameterName);

            return retValue;
        }

        public static string parseCommandText(String commandText)
        {
            string cmt = "";
            if (CurrentSQLEngine == myEnums.SQLEngineType.MySQL)
                cmt = commandText.Replace("[dbo]", "").Replace("dbo", "").Replace("__", "_").Replace("[", "").Replace("]", "").Replace("..", "");
            else
                cmt = commandText.Trim();

            return cmt;
        }      

        public static string Encrypt(string password)
        {
            string EncryptionKey = "SD_BusinessManagment";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }
        public static string Decrypt(string password)
        {
            
            string EncryptionKey = "SD_BusinessManagment";
            password = password.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return password;
        }
    }


}