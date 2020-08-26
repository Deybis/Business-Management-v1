using System;
using System.Data;
using System.Xml;
using BusinessManagment.Factories;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessManagment.Entities
{
    [DataObject]
    [Serializable]
    public class SEG_Accounts
    {
        public SEG_Accounts()
        { }

        public SEG_Accounts(long accountID, string accountLoginUser,string companyEmail)
        {

            SEG_Accounts seg_accounts =
            (SEG_Accounts)factorySEG_Accounts.getSEG_Accounts(accountID, accountLoginUser,companyEmail, myEnums.EntityType.Entity);

            if (seg_accounts != null)
            {
                this.AccountID = seg_accounts.AccountID;
                this.StatusID = seg_accounts.StatusID;
                this.AccountLoginUser = seg_accounts.AccountLoginUser;
                this.AccountLoginPassword = seg_accounts.AccountLoginPassword;
                this.CompanyName = seg_accounts.CompanyName;
                this.CompanyImage = seg_accounts.CompanyImage;
                this.CompanyPhoneNumber = seg_accounts.CompanyPhoneNumber;
                this.CompanyEmail = seg_accounts.CompanyEmail;
                this.AccountActive = seg_accounts.AccountActive;
                this.AccountIdentifyToken = seg_accounts.AccountIdentifyToken;
                this.Note = seg_accounts.Note;
                this.CreatedBy = seg_accounts.CreatedBy;
                this.CreatedDate = seg_accounts.CreatedDate;
                this.ModifiedBy = seg_accounts.ModifiedBy;
                this.ModifiedDate = seg_accounts.ModifiedDate;

            }
        }

        public SEG_Accounts(String xmlString)
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
        [Required(ErrorMessage = "Account es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public long AccountID { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Estado es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public int StatusID { get; set; }

        [DisplayName("Account Login User")]
        [Required(ErrorMessage = "Account Login User es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Account Login User no debe ser mayor de 50 caracteres")]
        public string AccountLoginUser { get; set; }

        [DisplayName("Account Login Password")]
        [Required(ErrorMessage = "Account Login Password es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Account Login Password no debe ser mayor de 80 caracteres")]
        public string AccountLoginPassword { get; set; }

        public string AccountLoginPasswordDecrypt { get; set; }

        [DisplayName("Company Name")]
        [Required(ErrorMessage = "Company Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Company Name no debe ser mayor de 50 caracteres")]
        public string CompanyName { get; set; }

        [DisplayName("Company Image")]
        [ScaffoldColumn(true)]
        public byte[] CompanyImage { get; set; }

        [DisplayName("Company Phone Number")]
        [ScaffoldColumn(true)]
        [StringLength(25, ErrorMessage = "Company Phone Number no debe ser mayor de 25 caracteres")]
        public string CompanyPhoneNumber { get; set; }

        [DisplayName("Company Email")]
        [Required(ErrorMessage = "Company Email es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Company Email no debe ser mayor de 50 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Direccion de correo no es valida")]
        [EmailAddress]
        public string CompanyEmail { get; set; }

        [DisplayName("Note")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Note no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        [DisplayName("Cuenta Activa")]
        [ScaffoldColumn(true)]
        public bool AccountActive { get; set; }

        [DisplayName("Token Activación")]
        [ScaffoldColumn(true)]
        public string AccountIdentifyToken { get; set; }

        [DisplayName("Created By")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Created By no debe ser mayor de 50 caracteres")]
        public string CreatedBy { get; set; }

        [DisplayName("Created Date")]
        [ScaffoldColumn(true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Modified By")]
        [ScaffoldColumn(true)]
        [StringLength(50, ErrorMessage = "Modified By no debe ser mayor de 50 caracteres")]
        public string ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        [ScaffoldColumn(true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedDate { get; set; }

        [DisplayName("Autenticado")]
        [ScaffoldColumn(true)]
        public bool isAuthenticated { get; set; }

        [DisplayName("Error")]
        [ScaffoldColumn(true)]
        public string LoginError { get; set; }


        #region Métodos de la entidad SEG_Accounts


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factorySEG_Accounts representado por Entities.SEG_Accounts como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo SEG_Accounts</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.SEG_Accounts Select(long accountID, string accountLoginUser,string CompanyEmail)
        {
            return Factories.factorySEG_Accounts.getSEG_Accounts(accountID, accountLoginUser,CompanyEmail, myEnums.EntityType.Entity) as Entities.SEG_Accounts;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factorySEG_Accounts persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(SEG_Accounts seg_accounts)
        {
            return Factories.factorySEG_Accounts.saveSEG_Accounts(seg_accounts);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase factorys.factorySEG_Accounts persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(SEG_Accounts seg_accounts)
        {
            return Factories.factorySEG_Accounts.saveSEG_Accounts(seg_accounts);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factorySEG_Accounts
        /// </summary>
        /// <param name="seg_accounts"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(SEG_Accounts seg_accounts)
        {
            return Factories.factorySEG_Accounts.deleteSEG_Accounts(seg_accounts.AccountID);
        }

        /// <summary>
        /// Devuelve el Objeto SEG_Accounts a una cadena formateada XML
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
            SEG_Accounts seg_accounts = (SEG_Accounts)obj;

            this.AccountID = seg_accounts.AccountID;
            this.StatusID = seg_accounts.StatusID;
            this.AccountLoginUser = seg_accounts.AccountLoginUser;
            this.AccountLoginPassword = seg_accounts.AccountLoginPassword;
            this.CompanyName = seg_accounts.CompanyName;
            this.CompanyImage = seg_accounts.CompanyImage;
            this.CompanyPhoneNumber = seg_accounts.CompanyPhoneNumber;
            this.CompanyEmail = seg_accounts.CompanyEmail;
            this.AccountActive = seg_accounts.AccountActive;
            this.AccountIdentifyToken = seg_accounts.AccountIdentifyToken;
            this.Note = seg_accounts.Note;
            this.CreatedBy = seg_accounts.CreatedBy;
            this.CreatedDate = seg_accounts.CreatedDate;
            this.ModifiedBy = seg_accounts.ModifiedBy;
            this.ModifiedDate = seg_accounts.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class SEG_AccountsCollection : List<Entities.SEG_Accounts>
    {
        public SEG_AccountsCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de SEG_Accounts a traves de la clase  factorys.factorySEG_Accounts
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.SEG_AccountsCollection Select()
        {
            return Factories.factorySEG_Accounts.getSEG_Accounts(0, string.Empty,string.Empty, myEnums.EntityType.EntityCollection) as Entities.SEG_AccountsCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo SEG_AccountsCollection con un solo registro  a traves de la clase  factorys.factorySEG_Accounts
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.SEG_AccountsCollection Select(long accountID, string accountLoginUser,string companyEmail)
        {
            return Factories.factorySEG_Accounts.getSEG_Accounts(accountID, accountLoginUser,companyEmail, myEnums.EntityType.EntityCollection) as Entities.SEG_AccountsCollection;
        }
    }
}