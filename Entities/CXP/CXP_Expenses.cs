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
    public class CXP_Expenses
    {
        public CXP_Expenses()
        { }

        public CXP_Expenses(long expenseID,string accountLoginUser)
        {

            CXP_Expenses cxp_expenses =
            (CXP_Expenses)factoryCXP_Expenses.getCXP_Expenses(expenseID,accountLoginUser, myEnums.EntityType.Entity);

            if (cxp_expenses != null)
            {
                this.ExpenseID = cxp_expenses.ExpenseID;
                this.ExpenseTypesID = cxp_expenses.ExpenseTypesID;
                this.ExpenseTypesName = cxp_expenses.ExpenseTypesName;
                this.AccountID = cxp_expenses.AccountID;
                this.ExpenseName = cxp_expenses.ExpenseName;
                this.ExpenseDescription = cxp_expenses.ExpenseDescription;
                this.ExpenseAmount = cxp_expenses.ExpenseAmount;
                this.Note = cxp_expenses.Note;
                this.CreatedBy = cxp_expenses.CreatedBy;
                this.CreatedDate = cxp_expenses.CreatedDate;
                this.ModifiedBy = cxp_expenses.ModifiedBy;
                this.ModifiedDate = cxp_expenses.ModifiedDate;

            }
        }

        public CXP_Expenses(String xmlString)
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

        [DisplayName("Expense")]
        [Required(ErrorMessage = "Expense es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public long ExpenseID { get; set; }

        [DisplayName("Expense Types")]
        [Required(ErrorMessage = "Expense Types es un campo obligatorio")]
        [ScaffoldColumn(true)]
        public int ExpenseTypesID { get; set; }

       public string ExpenseTypesName { get; set; }   

        [DisplayName("Cuenta")]
        [ScaffoldColumn(true)]
        public long AccountID { get; set; }

        [DisplayName("Expense Name")]
        [Required(ErrorMessage = "Expense Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Expense Name no debe ser mayor de 80 caracteres")]
        public string ExpenseName { get; set; }

        [DisplayName("Expense Description")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Expense Description no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string ExpenseDescription { get; set; }

        [DisplayName("Expense Amount")]
        [ScaffoldColumn(true)]
        public decimal ExpenseAmount { get; set; }

        [DisplayName("Note")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Note no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

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


        #region Métodos de la entidad CXP_Expenses


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase factorys.factoryCXP_Expenses representado por Entities.CXP_Expenses como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo CXP_Expenses</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXP_Expenses Select(long expenseID,string accountLoginUser)
        {
            return Factories.factoryCXP_Expenses.getCXP_Expenses(expenseID,accountLoginUser, myEnums.EntityType.Entity) as Entities.CXP_Expenses;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase factorys.factoryCXP_Expenses persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(CXP_Expenses cxp_expenses)
        {
            return Factories.factoryCXP_Expenses.saveCXP_Expenses(cxp_expenses);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase Factories.factoryCXP_Expenses persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(CXP_Expenses cxp_expenses)
        {
            return Factories.factoryCXP_Expenses.saveCXP_Expenses(cxp_expenses);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase factorys.factoryCXP_Expenses
        /// </summary>
        /// <param name="cxp_expenses"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(CXP_Expenses cxp_expenses)
        {
            return Factories.factoryCXP_Expenses.deleteCXP_Expenses(cxp_expenses.ExpenseID);
        }

        /// <summary>
        /// Devuelve el Objeto CXP_Expenses a una cadena formateada XML
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
            CXP_Expenses cxp_expenses = (CXP_Expenses)obj;

            this.ExpenseID = cxp_expenses.ExpenseID;
            this.ExpenseTypesID = cxp_expenses.ExpenseTypesID;
            this.ExpenseTypesName = cxp_expenses.ExpenseTypesName;            
            this.AccountID = cxp_expenses.AccountID;
            this.ExpenseName = cxp_expenses.ExpenseName;
            this.ExpenseDescription = cxp_expenses.ExpenseDescription;
            this.ExpenseAmount = cxp_expenses.ExpenseAmount;
            this.Note = cxp_expenses.Note;
            this.CreatedBy = cxp_expenses.CreatedBy;
            this.CreatedDate = cxp_expenses.CreatedDate;
            this.ModifiedBy = cxp_expenses.ModifiedBy;
            this.ModifiedDate = cxp_expenses.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class CXP_ExpensesCollection : List<Entities.CXP_Expenses>
    {
        public CXP_ExpensesCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de CXP_Expenses a traves de la clase  factorys.factoryCXP_Expenses
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.CXP_ExpensesCollection Select()
        {
            return Factories.factoryCXP_Expenses.getCXP_Expenses(0,string.Empty, myEnums.EntityType.EntityCollection) as Entities.CXP_ExpensesCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo CXP_ExpensesCollection con un solo registro  a traves de la clase  factorys.factoryCXP_Expenses
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXP_ExpensesCollection Select(long expenseID,string accountLoginUser)
        {
            return Factories.factoryCXP_Expenses.getCXP_Expenses(expenseID,accountLoginUser, myEnums.EntityType.EntityCollection) as Entities.CXP_ExpensesCollection;
        }
    }
}