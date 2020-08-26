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
    public class CXC_Incomes
    {
        public CXC_Incomes()
        { }

        public CXC_Incomes(long incomeID,string accountLoginUser)
        {

            CXC_Incomes cxc_incomes =
            (CXC_Incomes)factoryCXC_Incomes.getCXC_Incomes(incomeID,accountLoginUser, myEnums.EntityType.Entity);

            if (cxc_incomes != null)
            {
                this.IncomeID = cxc_incomes.IncomeID;
                this.IncomeTypesID = cxc_incomes.IncomeTypesID;
                this.IncomeTypesName = cxc_incomes.IncomeTypesName;
                this.AccountID = cxc_incomes.AccountID;
                this.IncomeName = cxc_incomes.IncomeName;
                this.IncomeDescription = cxc_incomes.IncomeDescription;
                this.IncomeAmount = cxc_incomes.IncomeAmount;
                this.Note = cxc_incomes.Note;
                this.CreatedBy = cxc_incomes.CreatedBy;
                this.CreatedDate = cxc_incomes.CreatedDate;
                this.ModifiedBy = cxc_incomes.ModifiedBy;
                this.ModifiedDate = cxc_incomes.ModifiedDate;

            }
        }

        public CXC_Incomes(String xmlString)
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

        [DisplayName("Income")]
        [Required(ErrorMessage = "Income es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [DataObjectField(true, true, false)]
        public long IncomeID { get; set; }

        [DisplayName("Income Types")]
        [Required(ErrorMessage = "Income Types es un campo obligatorio")]
        [ScaffoldColumn(true)]
        public int IncomeTypesID { get; set; }

        [DisplayName("Tipo de ingreso")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Tipo de ingreso no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string IncomeTypesName { get; set; }

        [DisplayName("Cuenta")]
        [ScaffoldColumn(true)]
        public long AccountID { get; set; }

        [DisplayName("Income Name")]
        [Required(ErrorMessage = "Income Name es un campo obligatorio")]
        [ScaffoldColumn(true)]
        [StringLength(80, ErrorMessage = "Income Name no debe ser mayor de 80 caracteres")]
        public string IncomeName { get; set; }

        [DisplayName("Income Description")]
        [ScaffoldColumn(true)]
        [StringLength(250, ErrorMessage = "Income Description no debe ser mayor de 250 caracteres")]
        [DataType(DataType.MultilineText)]
        public string IncomeDescription { get; set; }

        [DisplayName("Income Amount")]
        [Required(ErrorMessage = "Income Amount es un campo obligatorio")]
        [ScaffoldColumn(true)]
        public decimal IncomeAmount { get; set; }

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

        public string error { get; set; }


        #region Métodos de la entidad CXC_Incomes


        /// <summary>
        /// Obtiene un registro desde la base de datos a través
        /// de la clase Factories.factoryCXC_Incomes representado por Entities.CXC_Incomes como objeto de datos.
        /// </summary>
        /// <returns>Objeto de tipo CXC_Incomes</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXC_Incomes Select(long incomeID, string accountLoginUser)
        {
            return Factories.factoryCXC_Incomes.getCXC_Incomes(incomeID,accountLoginUser, myEnums.EntityType.Entity) as Entities.CXC_Incomes;
        }

        /// <summary>
        /// Update/Actualiza/Guarda un registro en la base de datos a través
        /// de la clase Factories.factoryCXC_Incomes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public int Update(CXC_Incomes cxc_incomes)
        {
            return Factories.factoryCXC_Incomes.saveCXC_Incomes(cxc_incomes);
        }

        /// <summary>
        /// Insert/Nuevo/Guardar el registro actual en la base de datos a través
        /// de la clase Factories.factoryCXC_Incomes persistiendo las propiedades de la entidad.
        /// </summary>
        /// <returns></returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public int Insert(CXC_Incomes cxc_incomes)
        {
            return Factories.factoryCXC_Incomes.saveCXC_Incomes(cxc_incomes);
        }

        /// <summary>
        /// Elimina un registro representado por esta entidad a traves de la clase Factories.factoryCXC_Incomes
        /// </summary>
        /// <param name="cxc_incomes"></param>
        /// <returns>Valor positivo indicando que el registro fue eliminado, negativo indicando lo contrario</returns>
        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public int Delete(CXC_Incomes cxc_incomes)
        {
            return Factories.factoryCXC_Incomes.deleteCXC_Incomes(cxc_incomes.IncomeID);
        }

        /// <summary>
        /// Devuelve el Objeto CXC_Incomes a una cadena formateada XML
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
            CXC_Incomes cxc_incomes = (CXC_Incomes)obj;

            this.IncomeID = cxc_incomes.IncomeID;
            this.IncomeTypesID = cxc_incomes.IncomeTypesID;
            this.IncomeTypesName = cxc_incomes.IncomeTypesName;
            this.AccountID = cxc_incomes.AccountID;
            this.IncomeName = cxc_incomes.IncomeName;
            this.IncomeDescription = cxc_incomes.IncomeDescription;
            this.IncomeAmount = cxc_incomes.IncomeAmount;
            this.Note = cxc_incomes.Note;
            this.CreatedBy = cxc_incomes.CreatedBy;
            this.CreatedDate = cxc_incomes.CreatedDate;
            this.ModifiedBy = cxc_incomes.ModifiedBy;
            this.ModifiedDate = cxc_incomes.ModifiedDate;

        }
        #endregion
    }

    [DataObject]
    [Serializable]
    public class CXC_IncomesCollection : List<Entities.CXC_Incomes>
    {
        public CXC_IncomesCollection()
        { }

        /// <summary>
        /// Obtiene la coleccion de registros de CXC_Incomes a traves de la clase  Factories.factoryCXC_Incomes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Entities.CXC_IncomesCollection Select()
        {
            return Factories.factoryCXC_Incomes.getCXC_Incomes(0,string.Empty, myEnums.EntityType.EntityCollection) as Entities.CXC_IncomesCollection;
        }

        /// <summary>
        /// Obtiene un objeto de tipo CXC_IncomesCollection con un solo registro  a traves de la clase  Factories.factoryCXC_Incomes
        /// </summary>
        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public Entities.CXC_IncomesCollection Select(long incomeID,string accountLoginUser)
        {
            return Factories.factoryCXC_Incomes.getCXC_Incomes(incomeID,accountLoginUser, myEnums.EntityType.EntityCollection) as Entities.CXC_IncomesCollection;
        }
    }
}