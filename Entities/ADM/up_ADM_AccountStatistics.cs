using System;
using System.Xml;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusinessManagment.Factories;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class up_ADM_AccountStatistics
    {
        public up_ADM_AccountStatistics()
        { }
        public up_ADM_AccountStatistics(string xmlString)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());

            //Hacemos xml el texto recibido en formato xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlString);

            XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement);
            Object obj = x.Deserialize(reader);

            // Inicializamos/Construimos la clase con los valores de las propiedades 
            InitializeComponent(obj);
        }

        [DisplayName("IncomeName")]
        public string IncomeName { get; set; }

        [DisplayName("IncomeAmount")]
        public decimal IncomeAmount { get; set; }

        [DisplayName("ExpenseName")]
        public string ExpenseName { get; set; }

        [DisplayName("ExpenseAmount")]
        public decimal ExpenseAmount { get; set; }



        #region Procedimientos/Metodos CRUD de up_ADM_AccountStatistics
        /// <summary>
        /// Devuelve los registros resultantes de la ejecucion del procedimiento almacenado ADM_up_ADM_AccountStatistics 
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.up_ADM_AccountStatisticsCollection Select(Int32 day, Int32 month, Int32 year, String accountLoginUser, Int32 accountID)
        {
            return factoryADM_up_ADM_AccountStatistics.execute_ADM_up_ADM_AccountStatisticsCollection(day, month, year, accountLoginUser, accountID);
        }

        /// <summary>
        /// Devuelve el Objeto ADM_up_ADM_AccountStatistics a una cadena formateada XML
        /// </summary>
        /// <returns></returns>
        public string ToXMLString()
        {
            System.IO.StringWriter xmlString = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            x.Serialize(xmlString, this);

            return xmlString.ToString();
        }
        private void InitializeComponent(Object obj)
        {
            up_ADM_AccountStatistics up_adm_accountstatistics = (up_ADM_AccountStatistics)obj;

            this.IncomeName = up_adm_accountstatistics.IncomeName;
            this.IncomeAmount = up_adm_accountstatistics.IncomeAmount;
            this.ExpenseName = up_adm_accountstatistics.ExpenseName;
            this.ExpenseAmount = up_adm_accountstatistics.ExpenseAmount;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class up_ADM_AccountStatisticsCollection : List<Entities.up_ADM_AccountStatistics>
    {
        public up_ADM_AccountStatisticsCollection()
        { }

        /// <summary>
        /// Devuelve los registros resultantes de la ejecucion del procedimiento almacenado ADM_up_ADM_AccountStatistics
        /// </summary>
        /// <returns>Coleccion de Entities.up_ADM_AccountStatistics</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.up_ADM_AccountStatisticsCollection Select(Int32 day, Int32 month, Int32 year, String accountLoginUser, Int64 accountID)
        {
            return factoryADM_up_ADM_AccountStatistics.execute_ADM_up_ADM_AccountStatisticsCollection(day, month, year, accountLoginUser, accountID);
        }
    }
}