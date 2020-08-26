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
    public class up_ADM_DashBoardSelect
    {
        public up_ADM_DashBoardSelect()
        { }
        public up_ADM_DashBoardSelect(string xmlString)
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

        [DisplayName("Account")]
        public long AccountID { get; set; }

        [DisplayName("Company Name")]
        [StringLength(50, ErrorMessage = "Company Name no debe ser mayor de 50 caracteres")]
        public string CompanyName { get; set; }

        [DisplayName("Company Image")]
        public byte[] CompanyImage { get; set; }

        [DisplayName("Company Phone Number")]
        [StringLength(25, ErrorMessage = "Company Phone Number no debe ser mayor de 25 caracteres")]
        public string CompanyPhoneNumber { get; set; }

        [DisplayName("Company Email")]
        [StringLength(50, ErrorMessage = "Company Email no debe ser mayor de 50 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Direccion de correo no es valida")]
        [EmailAddress]
        public string CompanyEmail { get; set; }

        [DisplayName("Total Ingresos")]
        public decimal IncomesTotal { get; set; }

        [DisplayName("Total Gastos")]
        public decimal ExpensesTotal { get; set; }

        [DisplayName("Task")]
        public long TaskID { get; set; }

        [DisplayName("Task Name")]
        [StringLength(200, ErrorMessage = "Task Name no debe ser mayor de 200 caracteres")]
        public string TaskName { get; set; }

        [DisplayName("Task Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime TaskDate { get; set; }

        [DisplayName("Estatus")]
        public string TaskStatusName { get; set; }



        #region Procedimientos/Metodos CRUD de up_ADM_DashBoardSelect
        /// <summary>
        /// Devuelve los registros resultantes de la ejecucion del procedimiento almacenado ADM_up_ADM_DashBoardSelect 
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.up_ADM_DashBoardSelectCollection Select(UInt64 accountID, String accountLoginUser)
        {
            return factoryADM_up_ADM_DashBoardSelect.execute_ADM_up_ADM_DashBoardSelectCollection(accountID, accountLoginUser);
        }

        /// <summary>
        /// Devuelve el Objeto ADM_up_ADM_DashBoardSelect a una cadena formateada XML
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
            up_ADM_DashBoardSelect up_adm_dashboardselect = (up_ADM_DashBoardSelect)obj;

            this.AccountID = up_adm_dashboardselect.AccountID;
            this.CompanyName = up_adm_dashboardselect.CompanyName;
            this.CompanyImage = up_adm_dashboardselect.CompanyImage;
            this.CompanyPhoneNumber = up_adm_dashboardselect.CompanyPhoneNumber;
            this.CompanyEmail = up_adm_dashboardselect.CompanyEmail;
            this.IncomesTotal = up_adm_dashboardselect.IncomesTotal;
            this.ExpensesTotal = up_adm_dashboardselect.ExpensesTotal;
            this.TaskID = up_adm_dashboardselect.TaskID;
            this.TaskName = up_adm_dashboardselect.TaskName;
            this.TaskDate = up_adm_dashboardselect.TaskDate;
            this.TaskStatusName = up_adm_dashboardselect.TaskStatusName;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class up_ADM_DashBoardSelectCollection : List<Entities.up_ADM_DashBoardSelect>
    {
        public up_ADM_DashBoardSelectCollection()
        { }

        /// <summary>
        /// Devuelve los registros resultantes de la ejecucion del procedimiento almacenado ADM_up_ADM_DashBoardSelect
        /// </summary>
        /// <returns>Coleccion de Entities.up_ADM_DashBoardSelect</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.up_ADM_DashBoardSelectCollection Select(UInt64 accountID, String accountLoginUser)
        {
            return factoryADM_up_ADM_DashBoardSelect.execute_ADM_up_ADM_DashBoardSelectCollection(accountID, accountLoginUser);
        }
    }
}